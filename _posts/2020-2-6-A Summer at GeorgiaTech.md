---
layout: post
title: What, When, How A Summer at GeorgiaTech
---

![config.yml](/images/Gtech.jpeg)

After nearly 200 emails to professors and labs, applying to 3 international internship programs. Around 12 PM
on 22nd January 2019, a professor who I had been interviewing with at GeorgiaTech for nearly 3 months wrote back to me
saying "Congratulations on being selected as a Summer Intern 2019 at Georgia Tech". My excitement knew no bounds,
I was jumping around the hostel corridors. Fast forward 2 months I was busy getting my paperwork done for a J1 visa 
(Will have a separate blog on how to go about this process). I finally made it to Atlanta on 15th June 2019 to work at the "AI and Transportation lab" at GeorgiaTech.

GeorgiaTech is a world leader in research and leading professors in the verticals of Computer Vision and AI have their labs here.
Cracking an Intern at GerogiaTech, was not something done overnight, one email or one interview. Right from drafting the initial email, clearing 3 coding assignments and 2 telephonic interviews, I was constantly on my toes giving my best at it.

This blog primarily deals with my approach towards those assignments, interviews and of course my work and time at GeorgiaTech. 
If this experience interests you, please make sure to keep looking for the next set of very important blogs on how to write the 
perfect email and curate a resume matching to the position you are applying to.

My first assignment was pretty straight forward. It required me to develop a deep learning model, to detect various traffic signs. There were tons of tutorials on how to do this. I guess they used this assignment as an initial filter. Though the assignment was easy, I made sure I showed no signs of taking it easy and made
an excellent report sharing all my findings, how I tuned the hyperparameters and also explained my choices of choosing certain neural networks over others. The second set of the assignment was where it started getting tougher. The first and second assignment was not comparable, this was tougher it tested the basics of camera model dealing with intrinsic parameters, extrinsic parameters, converting image coordinates to 3D world coordinates and estimating distances from a series of monocular images. I had studied the camera model from various photometry courses online and eventually developed an easy to use GUI to let users submit a sequence of images, choose a point of interest

The third assignment dealt with SLAM and breaking down LiDAR data. It involved me studying research papers on LiDAR and 3D Object detection, point clouds, SFM. Based on these papers I was given a coding assignment that involved generating point clouds and performing analysis on it. This was brand new for me and was unable to generate a satisfactory solution within the stipulated deadline since I parallelly had my academic examinations. Nearly after a week, my professor had shared he would be interviewing me over skype. The interview went well and was a discussion of my submissions and how I crafted some nice solutions to certain problems, and areas he wanted me to improve on before landing in Atlanta. We discussed a stipend and I could say this interview sealed the deal for me.

I believe the following things helped in my application.

* Writing clean and modular code. 

* Submitting reports with detailed experiments and results.

* Always suggesting areas that can be improved on and other approaches I would like to try.

* During my interview, I maintained a very clear stance on what I am good at and what I would add to the lab.

Once in Atlanta, I had my logistics like a bank account, phone number, accommodation all set, I joined the lab on 16th June 2019. The initial few days weeks were tough. I went through what people call 'Imposter Syndrome', people doing their Ph.D.'s and Masters were present in the same lab, they were doing all sorts of things, things which appeared like bread and butter to them sounded Latin to me. I was scared and did not feel in the right place. One of the simplest solutions which worked for me was to talk to people. I was constantly talking about what I am doing in the lab about my work with my dad and friends and at the end of each conversation I just felt "Yeah, I am not doing that bad". My assigned Ph.D. buddy was extremely friendly. He was from NIT Trichy and we connected well, He allowed me to settle in easily and slowly started pushing the bar higher. I spent a lot of time in understanding the project and getting a bigger picture of it so I would be able to contribute even more efficiently. I was working on a project sponsored by GDOT (Georgia Department of Transportation) where we were looking to dynamically map and asses the quality of traffic signs in an efficient manner. 

This project had been running for nearly 2 months before my arrival. On my arrival, I spent a good time in understanding the existing codebase. The existing systems for mapping traffic signs in the lab adopted a deep learning-based approach, where they had trained a model to detect traffic signs and then estimate the location of the traffic sign, using triangulation. The quality of the sign was assessed based on visual inspection. This was time-consuming since each traffic needed human inspection to asses quality and was not an objective approach. The Transportation Lab at GeorgiaTech has a state of the art data collection vehicle. It is equipped with 3 LiDARs, multiple High Definition Cameras, Ground Scanners, and very accurate IMU devices. Check it out!

![config.yml](/images/car.jpeg)


The van was taken across various interstates (national highways) across Atlanta, to collect laser scans and images.
I started working on developing algorithms to identify and asses traffic sign health quality using LiDAR point cloud data. 
I was very uncertain how to start since this was out of my comfort zone, there was a parallel project running on computer vision and was willing to shift to that. But after discussions with my parents, seniors and friends I wanted to move out of my comfort zone and develop registration algorithms for point clouds and monocular images. I studied various papers dealing with LiDAR data processing, LiDAR querying, and GPS clustering techniques. Eventually, in time I was able to develop extremely fast LiDAR querying algorithms that filter out all the traffic signs from GigaBytes of LiDAR data. For assessing the traffic sign health quality, I harnessed the retro reflective value LiDAR point clouds returns and was able to filter and intimate the signs which required attention. To check out the work in more detail, feel free to check out the below GitHub Repositories and ofcourse give it a star.

* https://github.com/siddu1998/colorizer-lidar-integration

* https://github.com/siddu1998/LiDAR-filtering-tool

I had prioir worked on many projects, and wrote code for various purposes. But never did my code ever take volumes of data as input. At GeorgiaTech the way I wrote code become further modular, handling data, handling data structres the data needed to be stored in, optimizing code. I was happy to read papers, extract motivations and come up with novel ideas such as using 
KD-Tree for LiDAR querying. Today the research tools I developed at GeorgiaTech, are being used by the lab to process, handle, filter, analyse and do all sorts of things with LiDAR data collected. 

There is another dimension to interning as an undergraduate abroad. If research, technical knowledge are one side of the coin, the flip side is the amount of cultural exchange you undergo. My lab had people from India, Korea, China, Malaysia and America. Every alternate Friday, we had Ice Cream parties, gatherings over pizza and lots of free food! Other labs and other departments had interns coming from Europe, Austalia, Canada. Intern Outing were amazing where, all the interns for that summer at GeorgiaTech would be going out together and spend a crazy night. I made some really good friends among the interns, my flatmates. I suppose pictures make more sense, 



![config.yml](/images/lab.jpg)
![config.yml](/images/ice.jpg)
![config.yml](/images/aman.jpg)
![config.yml](/images/local.jpg)
![config.yml](/images/me_board.jpg)









