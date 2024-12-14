function drawGraph() {
  var tooltip = d3.select("body").append("div")
    .attr("class", "tooltip")
    .style("opacity", 0);

  var transitions = JSON.parse(document.getElementById('json-input').value);

  var nodes = [];
  var links = [];

  for (var key in transitions) {
    nodes.push({ id: key, description: transitions[key].description, imagePrompt: transitions[key].imagePrompt });
    for (var subkey in transitions[key].options) {
      links.push({ source: key, target: transitions[key].options[subkey], name: subkey });
    }
  }

  // remove any previous graph
  d3.select("#graph").select("svg").remove();

  var width = 800;
  var height = 800;


  var svg = d3.select("#graph").append("svg")
    .attr("width", width)
    .attr("height", height);

  var simulation = d3.forceSimulation(nodes)
    .force("link", d3.forceLink(links).id(d => d.id).distance(100).strength(1))
    .force("charge", d3.forceManyBody().strength(-500))
    .force("center", d3.forceCenter(width / 2, height / 2));


  var link = svg.append("g")
    .attr("class", "links")
    .selectAll("line")
    .data(links)
    .join("line")
    .attr("stroke-width", d => Math.sqrt(d.value))
    //   .on('mouseover', function (d, i) {
    //     tooltip.transition()
    //         .duration(200)
    //         .style("opacity", .9);
    //     tooltip.html("Option: " + d.name + "<br/>" + 
    //                  "From: " + d.source.id + "<br/>" + 
    //                  "To: " + d.target.id)
    //         .style("left", (d3.event.pageX) + "px")
    //         .style("top", (d3.event.pageY - 28) + "px");
    // })      
    //   .on('mouseout', function (d, i) {
    //     tooltip.transition()
    //       .duration(500)
    //       .style("opacity", 0);
    //   })
    .attr("marker-end", "url(#end)") // Add this line;

  // var node = svg.append("g")
  //     .attr("class", "nodes")
  //     .selectAll("circle")
  //     .data(nodes)
  //     .join("circle")
  //     .attr("r", 06)
  //     .attr("fill", function() { return "hsl(" + Math.random() * 360 + ",100%,50%)"; }) // random color
  //     .call(drag(simulation))
  //     .on('mouseover', function (event, d) {
  //         tooltip.transition()
  //           .duration(200)
  //           .style("opacity", .9);
  //         tooltip.html(d.name)
  //           .style("left", (d3.pointer(event, d3.select('body').node())[0]) + "px")
  //           .style("top", (d3.pointer(event, d3.select('body').node())[1] - 28) + "px");
  //       })
  //       .on('mouseover', function (event, d) {
  //         tooltip.transition()
  //           .duration(200)
  //           .style("opacity", .9);
  //         tooltip.html(d.description)
  //           .style("left", (d3.pointer(event, d3.select('body').node())[0]) + "px")
  //           .style("top", (d3.pointer(event, d3.select('body').node())[1] - 28) + "px");
  //       })
  //       .on('mouseout', function (d, i) {
  //       tooltip.transition()
  //         .duration(500)
  //         .style("opacity", 0);
  //     })
  //     .on('click', function (d, i) {
  //       document.getElementById('details').innerHTML = d.description;
  //     });
  var node = svg.append("g")
    .attr("class", "nodes")
    .selectAll("circle")
    .data(nodes)
    .join("circle")
    .attr("r", 5)
    .attr("fill", function () { return "hsl(" + Math.random() * 360 + ",100%,50%)"; })
    .call(drag(simulation))
    .on('mouseover', function (event, d) {
      tooltip.transition()
        .duration(200)
        .style("opacity", .9);
      tooltip.html(d.description)
        .style("left", (event.pageX) + "px")
        .style("top", (event.pageY - 28) + "px");
    })
    .on('mouseout', function (event, d) {
      tooltip.transition()
        .duration(500)
        .style("opacity", 0);
    })
    .on('click', function (event, d) {
      document.getElementById('details').innerHTML = d.description;
      document.getElementById('imagePrompt').innerHTML = d.imagePrompt;
      const options = {
        method: 'POST',
        headers: {
          accept: 'application/json',
          'content-type': 'application/json',
          authorization: 'Bearer 14827c36-6893-4d4d-b249-0bea818c5d68'
        },
        body: JSON.stringify({
          prompt: d.imagePrompt,
          negativePrompt: 'asymmetric, watermarks',
          steps: 50,
          width: 512,
          height: 512,
          numberOfImages: 1,
          promptStrength: 7,
          seed: 4523184,
          enhancePrompt: false,
          upscaleBy: 'x1',
          sampler: 'ddim'
        })
      };

      fetch('https://api.tryleap.ai/api/v1/images/models/1e7737d7-545e-469f-857f-e4b46eaa151d/inferences', options)
        .then(response => response.json())
        .then(response => {
          console.log(response)
          // modelId = response.json()["modelId"]
          // jobId   = response.json()["jobId"]
          console.log(response.id)
          const settings = {
            async: true,
            crossDomain: true,
            url: 'https://api.tryleap.ai/api/v1/images/models/1e7737d7-545e-469f-857f-e4b46eaa151d/inferences/' + response.id,
            method: 'GET',
            headers: {
              accept: 'application/json',
              authorization: 'Bearer 14827c36-6893-4d4d-b249-0bea818c5d68'
            }
          };

          var intervalId = setInterval(function () {
            $.ajax(settings).done(function (response) {
              console.log(response);
              if (response.state === 'finished') {
                clearInterval(intervalId);  // stop the interval
                // Do something with the response here, like accessing the image URI
                console.log(response.images[0].uri);
                $('#myImage').attr('src', response.images[0].uri);
              }
            });
          }, 10000);  // run every 5 seconds






        }
        )
        .catch(err => console.error(err));
    });


  svg.append("svg:defs").selectAll("marker")
    .data(["end"])
    .enter().append("svg:marker")
    .attr("id", String)
    .attr("viewBox", "0 -5 10 10")
    .attr("refX", 15)
    .attr("refY", -1.5)
    .attr("markerWidth", 6)
    .attr("markerHeight", 6)
    .attr("orient", "auto")
    .append("svg:path")
    .attr("d", "M0,-5L10,0L0,5");

  var label = svg.append("g")
    .attr("class", "labels")
    .selectAll("text")
    .data(nodes)
    .join("text")
    .attr("class", "label")
    .text((d) => d.id);

  node.append("title")
    .text(d => d.id);

  simulation.on("tick", () => {
    link
      .attr("x1", d => d.source.x)
      .attr("y1", d => d.source.y)
      .attr("x2", d => d.target.x)
      .attr("y2", d => d.target.y);

    node
      .attr("cx", d => d.x)
      .attr("cy", d => d.y);

    label
      .attr("x", d => d.x)
      .attr("y", d => d.y);
  });

  return svg.node();
}

function drag(simulation) {
  function dragstarted(event) {
    if (!event.active) simulation.alphaTarget(0.3).restart();
    event.subject.fx = event.subject.x;
    event.subject.fy = event.subject.y;
  }

  function dragged(event) {
    event.subject.fx = event.x;
    event.subject.fy = event.y;
  }

  function dragended(event) {
    if (!event.active) simulation.alphaTarget(0);
    event.subject.fx = null;
    event.subject.fy = null;
  }

  return d3.drag()
    .on("start", dragstarted)
    .on("drag", dragged)
    .on("end", dragended);
}
