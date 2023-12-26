let micIn;

// Variables for microphone amplitude values
let avgSamples = 30;
let avgArray = [];
let avgStep = 0;
let micTotal;
let micAvg;

let shloka;
let ocean;


var micSensitivity = 0.02;

function preload(){
  shloka = loadImage('assets/sholka.png');
  ocean = loadImage('assets/poisoncave.png');
  cloud = loadImage('assets/poisoncloud.png')
  dbox = loadImage('assets/dboxpixel.png')

}

function setup() {
  createCanvas(1000, 600);
  imageMode(CENTER);

  micIn = new p5.AudioIn();
  shlokaX = width/10;
  cloud1X = width/2;
  cloud1Y = height/2;
  cloud2X = width/5;
  cloud2Y = height/10;
  cloud3X = width/1.5;
  cloud3Y = height/1.5;
  cloud4X = width/2.5;
  cloud4Y = height/1.1;
  cloudscaleW = cloud.width/6
  cloudscaleH = cloud.height/6  


  
}

function draw() {
  background(220);
  image(ocean, width/2,height/2);
  image(cloud, cloud1X,cloud1Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud2X,cloud2Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud3X,cloud3Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud3X,cloud3Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud4X,cloud4Y, cloudscaleW,cloudscaleH);
  image(shloka,shlokaX,height/1.5, shloka.width/4,shloka.height/4)



  if (micIn.getLevel() > micSensitivity){
    console.log("hey");
    cloud1X+=5
    cloud2X-=5
    cloud3X+=5
    cloud4X-=5;  
  }

  if (cloud1X>=width && cloud2X<=width && cloud3X >=width && cloud4X <= width){
    image(dbox,width/4, height/5, dbox.width/7, dbox.height/7);
  }

  image(cloud, cloud1X,cloud1Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud2X,cloud2Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud3X,cloud3Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud3X,cloud3Y, cloudscaleW,cloudscaleH);
  image(cloud, cloud4X,cloud4Y, cloudscaleW,cloudscaleH);

}
function mousePressed() {
  userStartAudio();
  micIn.start();

}