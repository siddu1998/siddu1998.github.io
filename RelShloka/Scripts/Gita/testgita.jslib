mergeInto(LibraryManager.library, {
  StartRecording: function () {
    console.log("Starting audio recordng for gita");
    this.mediaRecorder = null;
    this.audioChunks = [];

    var self = this; // Store reference to 'this'

    navigator.mediaDevices.getUserMedia({ audio: true })
      .then(stream => {
        self.mediaRecorder = new MediaRecorder(stream);
        self.mediaRecorder.start();
        self.mediaRecorder.addEventListener("dataavailable", event => {
          self.audioChunks.push(event.data);
        });
      });
  },

  StopRecordingAndSendToAPI: function () {
    if (this.mediaRecorder) {
      var self = this; // Store reference to 'this'

      // Define the levenshteinDistance function
      function levenshteinDistance(s, t) {
        var d = [];
        for (var i = 0; i <= s.length; i++) {
          d[i] = [i];
        }
        for (var j = 1; j <= t.length; j++) {
          d[0][j] = j;
        }

        for (var j = 1; j <= t.length; j++) {
          for (var i = 1; i <= s.length; i++) {
            if (s.charAt(i - 1) === t.charAt(j - 1)) {
              d[i][j] = d[i - 1][j - 1];
            } else {
              d[i][j] = Math.min(
                d[i - 1][j] + 1, // deletion
                d[i][j - 1] + 1, // insertion
                d[i - 1][j - 1] + 1 // substitution
              );
            }
          }
        }

        return d[s.length][t.length];
      }

      this.mediaRecorder.addEventListener("stop", async () => {
        var audioBlob = new Blob(this.audioChunks, { 'type': 'audio/wav' });

        var formData = new FormData();
        formData.append("audio", audioBlob);
        var response = await fetch("https://shloka.herokuapp.com/process_wav_js", { method: "POST", body: formData });
        var data = await response.json();

        var returnStr = JSON.stringify(data);
        SendMessage('yourButtongita', 'ReceiveSimilarityResult', returnStr);
  

        console.log(JSON.stringify(data));
        return returnStr;
        //return false; // Return false if returnStr is empty
      });

      this.mediaRecorder.stop();
    }
  }
});




