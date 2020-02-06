---
layout: post
title: Towards Extensible and Adaptable Methods in Computing 2018
---

Solving the global issue of crop vandalism using Neural Networks, Sounds Cool.This is going to be a really long one so gear up!

They say destiny is predefined, sounds true in the case of me and my team. I hardly knew a twenty day Human centric software internship back in May 2017, will set tone for a full reserach paper in March 2018. If anyone asks me what is one of the most productive phases in my life without doubt it has to be SRISTI 2017. Got to know about it from my super-senior and eventually made through their selection procedure.

So what is Sristi?! Sristi in non-profit organization which itself is division of Honeybee Network which was founded by a super human, Padma Shri Prof.Anil Gupta. He is the heart and soul of bringing up grassroot innovation in India. Spend twenty days with him you will understand the mere purpose of engineering. World class mentors were bought to guide and mentor throught the 20 days which involved in solving real life rural challanges. Oh, meet professor below!

![config.yml](/images/anilsir.jpeg)

                                                   The Guru!

One must read book, for all software engineers in “Hit Refresh” by Satya Nadella, In the book he makes a statement to develop with empathy, and professor has been doing it since half a century. So me and my friend (team mate) went to Ahmedabad to be part of Sristi and at the end of twenty days I will list a fraction of what we learnt.
Emapthy
Compassion
Human Centric Design


![config.yml](/images/newspaper.jpeg)


My problem statement revolved around bringing the whole crop feedback and review system digital using android applications. Thanks to a wonderful team we were able to meet the deadline and wrap things of.

One important problem which was drawing a lot of attraction is crop vandalsim and the great loss due to it. One amazing set of people worked in developing a sensor based detection system and perform appropriate triggering actions. It solved the issue by a great extend prone to a few errors. I have kept the problem at the back of my mind and as time progressed we had to part away from this wonderful organization. Great memories and greater friends were made. 

Fast forward December 2017 when Teamc 2018 journey started. TEAMC chaired by Dr.Shampa Madam, had a very novel idea while conducting the hackathon. The hackathon was not there to develop any solution but actually allowed us to move out and develop solutions for serious issues out there in the country. Having spent nearly a month with the farming community in Gujarat, we knew most of their problems, because we just did not see their problems but lived with them. This was the instance when my team decided to dig out the of crop vandalism issue from sristi and use computer science to come up with a possible solution.
Fast forward February 11th 2017, We packed our bags and were on the move to Delhi to give life to a brand new idea. We started of with proximity based sensors which we just learned at school! But unfortunatley the trade off between cost and result was not satisfactory and hence had to give up the method. With the world going behind Computer Vision we started reading computer science papers related to Computer Vision and that is when we were hit by the Paul Viola paper. Which in simple terms has pixel based features and runs a sliding window with certain stride rate to extract pixel features and find the required features. These features are encoded in the files called “Haar”, the Haar is loadead and frames are extracted from OpenCV and final detections are performed. Anyone intrested in the Paul Viola Jones paper should check the paper out for the implementation perspective do consider going through the following courses.

1. OpenCV last few sessions by Sentdex at https://pythonprogramming.net/haar-cascade-face-eye-detection-python-opencv-tutorial/
2. Computer Vision A-Z by Hadelin de Ponteves atUdemy
https://www.udemy.com/computer-vision-a-z/

Both the courses contain really nice material and the second one covers a perfect combination of intuition and practical. Personal call the second one is better, since it also covers topics on GAN’s and SSD. But considering the trade of between money and output people tend to go for Sentdex. I had a taste of both and you can treat the second one as a super set of sentdex.

But since we were not able to obtain the best results with Paul Viola implementation we had to search for new method. But we were pretty sure we were heading in the correct direction by trying to apply neopythic concepts of Computer Vision. The buzz word in the computer science currently is Cognitive Support Powered Solutions. My team and me decided to use cognitive support based systems to come up with better results. Now the question came how good are we in the domain of cognitive intelligence? Well hardly knew the basics. So what did we do!

This is where we pushed the gas hard and did some extensive literature review to actually understand how these services are being used in the market. We came across this really interesting paper in CVF 2016, which dealt with object detection in real time. The idea seemed to work out but, the toughest part still reamined! That is actually implementing the whole paper. Now before we even got started, my team decided to pick up our tools to build. We found the best implentation of the paper is achieved using the best deep learning frame work out there called TensorFlow. 

So here it started, since the hackathon was only a 24 hour period we had no chance to train the neural network on our own set of images. So we went in search of pretrained architecture and weights which we could propogate and get the neural network running. Once we found the appropriate architecture and the weights corresponding to it we stuffed it up in the deep learning framework. Now where and how do we get the streaming we want to predict what objects are there in the surroundings?!

Tada!! Hadelin to the rescue. Remember the course we were talking about (2) in the course there is a clear implementation how you can extract frames from a real time video using a simple camera. Now these frame one-by-one were passed into the network and we were able to generate the results with a good accuracy.

With that the hackathon phase had reached its end and the results did not go as planned. We stood 6th among the 55 teams. The hackathon which stood for a social cause allowed the first 10 teams to try and come up with a research paper on the same issue under the social impact section. Back home my team and myself took a good few days to recover from the results which did not go in our favour. But we recieved a great amount of appreciation from other participants which healed the wound. We wanted to come back hard this time and leave no stone unturned. We got our work split Tanuj deals with getting the GPU turned on so we achieve greater speed for demonstration and learn how to write a paper on LaTex.

Apart from that he is the only guy among us who knew a bit of graphic designing. So he along with a master editor named Parv made one killer poster to woo the audience and provide more information to the judges (sitting and reading this you have no clue what impact that poster had). Oh! just incase I forgot we use ZERO internet connectivity, and we were keen on intimating the farmers of an attack using a phone call or SMS. For that we needed to get our GSM module running, So on my shoulder was getting the GSM module running along with getting the paper and a killer presentation ready. 

Now the whole Neural Network is implemented in python, how do we trigger the arduino with python (this might sound easy but we were absolute proselytes in this domain) and then my third team mate Pandey, gets going. Once we were done with the paper and the presentation, we needed to integrate the work. Things did not seem to work out. The code was perfect, Hardware was fine but for some reasons actions were not being triggered. 

After a few good hours of struggle things started falling place and eventually Tanuj went back home and did the final rites and everything was set in place. On the 3rd Day of the conference (Yes I did skip writing on the first two days) we were all suited up and got ready for the last punch. The presentation was perfect, the demo worked smooth as butter and the judges were really happy. Eventually other teams went on to give their presentations and I learned so much from each one of them. The results were to come, with a perfect presentation and a perfect demo the final result went in our favour! I have the links to the presentation and paper below if you find the time and have the patience consider going through

Presentation
https://docs.google.com/presentation/d/1oeXfdfVYI0qwIQfRBPUkqjzISrrgltSBI04iebqNvLg/edit?usp=sharing

Paper
https://drive.google.com/file/d/192Q6LXuE3CoJVnNt27BsLma3SxfTvCS2/view?usp=sharing


Thats all from the research paper and implementation perspective. But we also attended the whole conference and there were people in the conference whose teaching expereience is (my age*2)+5. So it consisted of eminent people and we had some great learning we wanted to share. It did inspire me and might inspire you to.
1. Build adaptable solutions
2. Build extensible solutions
3. Best products are those whose ideas are simple
4. Dont bring in technology just for the sake of it
5. Be sure what tools you need for solving the issue
6. It is not important you see the pain of people to make a solution. The best solution comes out when you live with the pain
7. Ideas might pop at the craziest times, so never stop thinking about what you are solving.
Incase you had any take aways from the blog I would be really happy, but never the less I will try to summarize the journey
1. Sristi 2017 was my game changer

2. Always keep learning

3. Make a tribe of like minded people 

4. Learning should never be a private affair

5. Oh! the most important thing, have a visionuggle things started falling place and eventually Tanuj went back home and did the final rites and everything was set in place. On the 3rd Day of the conference (Yes I did skip writing on the first two days) we were all suited up and got ready for the last punch. The presentation was perfect, the demo worked smooth as butter and the judges were really happy. Eventually other teams went on to give their presentations and I learned so much from each one of them. The results were to come, with a perfect presentation and a perfect demo the final result went in our favour! I have the links to the presentation and paper below if you find the time and have the patience consider going through


![config.yml](/images/team.jpeg)

Team!


![config.yml](/images/rewards.jpeg)

After a toil!
