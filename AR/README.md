1. Create a html page (COPY the index.html in this directory)

2.  Choose your image target

3. Visit https://carnaux.github.io/NFT-Marker-Creator/#/

4. Convert your image target to a NFT marker using the above

5. You will get 3 files. Host those three files on github. (Refer https://github.com/siddu1998/ResilienceAR/tree/main/Clue-02-03-HD   where the UCSC logo NFT has been hosted)

6. visit the .fset file on github of your image target (for example https://github.com/siddu1998/ResilienceAR/blob/main/Clue-02-03-HD/Clue-02-03-HD.fset) copy the url and go to https://raw.githack.com/ 

7. Paste the URL and get the Development Link. COPY the development Link

8. In your newly created HTML page (step 1) replace line number 54 as follows

      url="https://arjs-cors-proxy.herokuapp.com/<COPIED LINK IN STEP 7>" (REMOVE the .fset extenstion)
      For example       
      url="https://arjs-cors-proxy.herokuapp.com/https://raw.githack.com/siddu1998/ResilienceAR/main/Clue-02-03-HD/Clue-02-03-HD"


9. Change Line 26-36 to whatever you want to do after finding the target. 

10. push to a repository and share the link. For example here it would be siddu1998.github.io/AR/index.html (make sure its a hosted webpage like glitch, github.io, to test locally you can run python -m http.server in your current repository)
