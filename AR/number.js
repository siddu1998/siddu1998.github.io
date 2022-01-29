<script src="https://cdn.jsdelivr.net/gh/aframevr/aframe@1c2407b26c61958baa93967b5412487cd94b290b/dist/aframe-master.min.js"></script>
<script src="https://raw.githack.com/AR-js-org/AR.js/master/aframe/build/aframe-ar-nft.js"></script>

<style>
  .arjs-loader {
    height: 100%;
    width: 100%;
    position: absolute;
    top: 0;
    left: 0;
    background-color: rgba(0, 0, 0, 0.8);
    z-index: 9999;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .arjs-loader div {
    text-align: center;
    font-size: 1.25em;
    color: white;
  }

  /* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 100px; /* Location of the box */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(70, 41, 1); /* Fallback color */
  background-color: rgba(120, 72, 12, 0.9); /* Black w/ opacity */
}

/* Modal Content (image) */
.modal-content {
  margin: auto;
  display: block;
  width: 80%;
  max-width: 700px;
}

/* Caption of Modal Image */
#caption {
  margin: auto;
  display: block;
  width: 80%;
  max-width: 700px;
  text-align: center;
  color: #ccc;
  padding: 10px 0;
  height: 150px;
}

/* Add Animation */
.modal-content, #caption {  
  -webkit-animation-name: zoom;
  -webkit-animation-duration: 0.6s;
  animation-name: zoom;
  animation-duration: 0.6s;
}

@-webkit-keyframes zoom {
  from {-webkit-transform:scale(0)} 
  to {-webkit-transform:scale(1)}
}

@keyframes zoom {
  from {transform:scale(0)} 
  to {transform:scale(1)}
}

/* The Close Button */
.close {
  position: absolute;
  top: 15px;
  right: 35px;
  color: #f1f1f1;
  font-size: 40px;
  font-weight: bold;
  transition: 0.3s;
}

.close:hover,
.close:focus {
  color: #bbb;
  text-decoration: none;
  cursor: pointer;
}

/* 100% Image Width on Smaller Screens */
@media only screen and (max-width: 700px){
  .modal-content {
    width: 100%;
  }
}


.scanning::after {
  content: '';
  position: absolute;
  width: 100vh;
  height: 5%;
  background-image: linear-gradient(to bottom,
    rgba(255, 0, 0, 0.315),
    rgba(214, 2, 2, 0.164));
  animation: scanning 1.8s linear infinite;
  
}

@keyframes scanning {
    100% { transform: translate(0, 1000px); }
}


.topnav {
  position: relative;
  overflow: hidden;
  background-color: #333;
}

.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #ddd;
  color: black;
}

.topnav a.active {
  background-color:#ad6a6c;
  color: white;
}

.topnav-centered a {
  float: none;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}

.topnav-right {
  float: right;
}

/* Responsive navigation menu (for mobile devices) */
@media screen and (max-width: 600px) {
  .topnav a, .topnav-right {
    float: none;
    display: block;
  }
  
  .topnav-centered a {
    position: relative;
    top: 0;
    left: 0;
    transform: none;
  }
}
.footer {
   position: fixed;
   left: 0;
   bottom: 0;
   width: 100%;
   background-color: rgb(0, 0, 0);
   color: #ad6a6c;
   text-align: center;
}

</style>


<script>

var target_urls={
        "1":{
            //AR marker Team - Help
            "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/test/aku",
            //Puzzle Team - Help
            "redirect_url":"https://raw.githubusercontent.com/siddu1998/siddu1998.github.io/master/resilience/images/afunsudoku.png",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 1"
        },
        "2":{
            "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/test/test1_QR",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 2"
        },
        "3":{
            "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/QR_Test/qr1",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 3"
        },
        "4":{
            "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/QR_Test/qr2",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 4"
        },
        "5":{
          "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/QR_Test/qr3",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 5"
        },
        "6":{
          "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/QR_Test/qr4",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 6"
        },
        "7":{
          "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/QR_Test/qr5",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 7"
        },
        "8":{
          "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/QR_Test/qr6",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 8"
        },
        "9":{
          "object_url":"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/QR_Test/qr7",
          "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 9"
        },
        "10":{
            "object_url":"https://arjs-cors-proxy.herokuapp.com/https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/test/qr7",
            "redirect_url":"https://parade.com/wp-content/uploads/2021/08/albert-einstein-quotes.jpg",
            "unlock_text":"SOME TEXT FOR THIS TARGET IMAGE 10"
        },

    }

  AFRAME.registerComponent('markers_start', {
    init: function () {
            console.log('Registering Scenesss')
            console.log(target_urls)

            var sceneEl = document.querySelector('a-scene');
            console.log("HELLLLO")
            for(var item in target_urls){
              console.log("HEeeeeeeeee")
                var url=target_urls[item]['object_url'];
                var redirect_url = target_urls[item]['redirect_url'];
        
                var markerEl = document.createElement('a-nft');
                    markerEl.setAttribute('type','nft');
                    markerEl.setAttribute('url',url);
                    markerEl.setAttribute('id',item);
                    markerEl.setAttribute('smooth',true)
                    markerEl.setAttribute('smoothCount',10)
                    markerEl.setAttribute('smoothTolerance',.01)
                    markerEl.setAttribute('smoothThreshold','5');
                    markerEl.setAttribute('registerevents','');
            
                sceneEl.appendChild(markerEl);

                //Adding text to each marker
                var textEl = document.createElement('a-entity');
                
                    textEl.setAttribute('id','text');
                    textEl.setAttribute('gltf-model',"https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/AR-js-org/AR.js/master/aframe/examples/image-tracking/nft/trex/scene.gltf");
                    textEl.object3D.position.set(5 ,5 ,0);
                    textEl.object3D.scale.set(5, 5, 5);
                
                markerEl.appendChild(textEl);

            }
        
 
    }})



AFRAME.registerComponent('registerevents', {
    init: function () {
        const marker = this.el;

        marker.addEventListener("markerFound", ()=> {
            var audio = new Audio("ScanVoice.mp3");
            audio.play();
            var markerId = marker.id;
            console.log('ITEM FOUND', markerId)
            
            var modal = document.getElementById("myModal");
            var img = document.getElementById("myImg");
            var modalImg = document.getElementById("img01");
            var captionText = document.getElementById("caption");

            modal.style.display = "block";
            modalImg.src = target_urls[markerId]['redirect_url'];
            captionText.innerHTML = target_urls[markerId]['unlock_text'];
            var span = document.getElementsByClassName("close")[0];

            // When the user clicks on <span> (x), close the modal
            span.onclick = function() { 
            modal.style.display = "none";
            }

            // window.location = target_urls[markerId]['redirect_url'];
            // alert(markerId);

        });

    },
});



</script>


<body style="margin : 0px; overflow: hidden;">
  <!-- minimal loader shown until image descriptors are loaded -->
  
  
  <div class="topnav">
    <!-- Centered link -->
    <div class="topnav-centered">
      <a href="#home" class="active">LUX-AR</a>
    </div>
    
    <!-- Left-aligned links (default) -->

    
    <!-- Right-aligned links -->
    <div class="topnav-right">
  
    </div>
    
  </div> 
<div class="scanning"></div>
<br>
<button>Toggle Scan</button>
  
  <div class="arjs-loader">
    <div>Loading, please wait...</div>
  </div>

  <div id="myModal" class="modal">
    <span class="close">&times;</span>
    <img class="modal-content" id="img01">
    <div id="caption"></div>
  </div>

  <a-scene markers_start 
  vr-mode-ui="enabled: false;"
  renderer="logarithmicDepthBuffer: true;"
  embedded
  arjs="trackingMethod: best; sourceType: webcam;debugUIEnabled: false;"
>
    	<a-entity id='userCamera' camera>
      
		<a-cursor> </a-cursor>
    	</a-entity>
	</a-scene>

  

  <div class="footer">
    <p>Your Portal To Truth</p>
    <p> Emergency | About | Contact </p>

  </div>
  
</body>
