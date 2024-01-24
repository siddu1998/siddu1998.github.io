let micIn;
let audio1;
let audio2;

// Variables for microphone amplitude values
let avgSamples = 30;
let avgArray = [];
let avgStep = 0;
let micTotal;
let micAvg;

let shloka;
let ocean;
let cloud;
let dbox;
let text1;
let text2;
let nextbutton;

var micSensitivity = 0.02;

let currentState = "screen1"; // Variable to track the current state

function preload(){
  shloka = loadImage('assets/girl.png');
  ocean = loadImage('assets/poisoncave.png');
  cloud = loadImage('assets/poisoncloud.png');
  dbox = loadImage('assets/dboxpixel.png');
  text1 = loadImage('assets/text1.png');
  text2 = loadImage('assets/text2.png');
  text3 = loadImage('assets/text3.png');
  text4 = loadImage('assets/text4.png');
  text5 = loadImage('assets/text5.png');
  text7 = loadImage('assets/text7.png');
  text8 = loadImage('assets/text8.png');
  text9 = loadImage('assets/text9.png');
  text10 = loadImage('assets/text10.png');


  


  chakra = loadImage('assets/chakra.png')

  audio1 = loadSound('assets/audio/audio1.mp3');
  audio2 = loadSound('assets/audio/audio2.mp3');
  audio3 = loadSound('assets/audio/audio3.mp3');
  audio4 = loadSound('assets/audio/audio4.mp3');
  audio5 = loadSound('assets/audio/audio5.mp3');
  audio6 = loadSound('assets/audio/audio6.mp3');
  audio7 = loadSound('assets/audio/audio7.mp3');
  audio9 = loadSound('assets/audio/audio9.mp3');
  audio10 = loadSound('assets/audio/audio10.mp3');









  nextbutton = loadImage('assets/buttonPlay.png');
}

function setup() {
  createCanvas(1000, 600);
  imageMode(CENTER);

  micIn = new p5.AudioIn();
  shlokaX = width/10;
  shlokaY = height/1.2;

  cloud1X = width/2;
  cloud1Y = height/2;
  
  cloud2X = width/5;
  cloud2Y = height/3;
  cloud3X = width/1.5;
  cloud3Y = height/1.5;
  cloud4X = width/2.5;
  cloud4Y = height/1.1;
  cloud5X = width/1.4;
  cloud5Y = height/3.5;
  chakraX = width/2.5;
  chakraY = height/1.2;

  cloudscaleW = cloud.width/6;
  cloudscaleH = cloud.height/6;

  // Set up the event listener for the 'ended' event of audio1
  audio1.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen2";
  });
  audio2.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen3";
  });
  audio3.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen4";
  });
  audio4.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen5";
  });
  audio5.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen7.5";
  });

  
  audio9.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen7.75";
  });
  audio10.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen8";
  });


  audio7.onended(() => {
    // Transition to the next state when audio1 ends
    currentState = "screen10";
  });


}

function draw() {
  background(220);

  if (cloud1X-70 > width &&
    cloud2X < 0 &&
    cloud3X > width &&
    cloud4X < 0 &&
    cloud5X > width) {
  console.log("All clouds are off-screen");
  if (currentState === 'screen5') {
    currentState = 'screen6';
    console.log(currentState);
  }
}
  if (chakraX*2.5 < shlokaX){
    console.log("diff hey")
    if (currentState === 'screen8'){
      
      currentState = 'screen9'
      console.log(currentState);
    }

  


  }

  image(ocean, width/2, height/2);

  // Draw the appropriate screen based on the current state
  if (currentState === "screen1") {
    image(text1, width/4.5, height/5, dbox.width/4.5, dbox.height/4.5);
    if (!audio1.isPlaying()) {
      audio1.play();
    }
  } else if (currentState === "screen2") {
    image(text2, width/4.5, height/5, dbox.width/4.5, dbox.height/4.5);
    if (!audio2.isPlaying()) {
      audio2.play();
    }

  }

  else if (currentState === "screen3") {
    image(text3, width/4.5, height/5, dbox.width/4.5, dbox.height/4.5);
    if (!audio3.isPlaying()) {
      audio3.play();
    }

    
  }
  else if (currentState === "screen4") {
    image(text4, width/4.5, height/5, dbox.width/4.5, dbox.height/4.5);
    if (!audio4.isPlaying()) {
      audio4.play();
    }

    
  }
  else if (currentState === "screen5") {
    userStartAudio();
    micIn.start();
    image(text2, width/4.5, height-900, dbox.width/4.5, dbox.height/6);
  }

  else if (currentState === "screen6") {
    image(text5, width/4.5, height/5, dbox.width/4.5, dbox.height/4.5);
    if (!audio5.isPlaying()) {
      audio5.play();
    }
    
  }

  // else if (currentState === "screen7") {
  //   image(text7, width/4.5, height/5, dbox.width/4.5, dbox.height/4.5);
  //   // image(chakra, chakraX+90, chakraY, cloudscaleH/3, cloudscaleW/3);
  //   if (!audio6.isPlaying()) {
  //     audio6.play();
  //   }
    
  // }

  else if (currentState === "screen7.5") {
    image(text9, width/4, height/5, dbox.width/4, dbox.height/4);
    // image(chakra, chakraX+90, chakraY, cloudscaleH/3, cloudscaleW/3);
    if (!audio9.isPlaying()) {
      audio9.play();
    }
    
  }

  else if (currentState === "screen7.75") {
    image(text10, width/4, height/5, dbox.width/4, dbox.height/4);
    if (!audio10.isPlaying()) {
      audio10.play();
    }
    
  }

  


  else if (currentState === "screen8") {
    userStartAudio();
    micIn.start();
    image(text7, width/4, height/5, dbox.width/4, dbox.height/4);
    image(chakra, chakraX+200, chakraY, cloudscaleH/3, cloudscaleW/3);
    
    
  }

  else if (currentState === "screen9") {
    image(text8, width/4, height/5, dbox.width/4, dbox.height/4);
    image(chakra, chakraX, chakraY-9000, cloudscaleH/2, cloudscaleW/2);
    if (!audio7.isPlaying()) {
      audio7.play();
  }
    
   
  }

  else if (currentState === "screen10") {
    image(text8, width/4, height/5, dbox.width/4, dbox.height/4);
    image(chakra, chakraX, chakraY-9000, cloudscaleH/2, cloudscaleW/2);
   
    
   
  }

  // image(nextbutton, width/4, height/2, nextbutton.width/3, nextbutton.height/3);

  image(cloud, cloud1X, cloud1Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud2X, cloud2Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud3X, cloud3Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud4X, cloud4Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud5X, cloud5Y, cloudscaleW, cloudscaleH);

  image(shloka, shlokaX, shlokaY, shloka.width/17, shloka.height/17);

  if (micIn.getLevel() > micSensitivity && currentState === 'screen5'){
    console.log("hey");
    cloud1X += 0.3;
    cloud2X -= 0.4;
    cloud3X += 0.7;
    cloud4X -= 0.8;
    cloud5X += 0.214;

    
  }

  if (micIn.getLevel() > micSensitivity && currentState === 'screen8'){
    console.log("yyyy");
    chakraX-=0.7;
    
  }

  // Check for next button click
  

  image(cloud, cloud1X, cloud1Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud2X, cloud2Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud3X, cloud3Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud4X, cloud4Y, cloudscaleW, cloudscaleH);
  image(cloud, cloud5X, cloud5Y, cloudscaleW, cloudscaleH);
}

function mousePressed() {
  // Empty function to prevent triggering state changes multiple times
}
