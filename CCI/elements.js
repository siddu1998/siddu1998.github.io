const container = $("download-button");
const weapon_container = document.getElementById('weapon-container');
// create an array of image file names
const imageFiles = ['cartoon-crocodile-isolated-on-white-background-free-vector 1.png', '56a58f54cea6dee62c95233476a51b95 1.png', 'Matsya 3 1.png', 'download (1) 1.png', '185736 1.png', 'Screen Shot 2022-10-03 at 9.20 1.png', 'cartoon-crocodile-isolated-on-white-background-free-vector 2.png', 'the-bull-icon-on-white-backgroundvector-Graphics-6514632-1-580x435 1.png', '22284-lizard-icon 1.png', 'Untitled 156 1.png', '8218627 1.png', '616689 1.png', '1303472 1.png', 'peacock-icon-cartoon-style-vector-22445686 3.png', 'Untitled 154 1.png', 'Animals_Mammals_Artboard_20-512 1.png', 'peacock-icon-cartoon-style-vector-22445686 2.png', 'Matsya 2 1.png', 'Untitled 151 1.png', 'lord-ganesha-1862329-1579259 1.png', 'male-figure-icon-human-body-front-view_53562-17129 1.png', 'Untitled 155 1.png', 'male-figure-icon-human-body-front-view_53562-17129 2.png', 'images (2) 1.png', '35a858deb255590500c72f10ea3827bd 1.png', 'Untitled 159 3.png', 'bengal-tiger-face-icon-cartoon-vector-illustration-graphic-design-bengal-tiger-face-icon-cartoon-151596609 1.png', 'turtle-icon-vector-22912829 1.png', 'elephant-vector-icons-shapes-set-icon-122803793 1.png', 'istockphoto-1302095908-612x612 1.png', 'download (2) 1.png', 'eaac308569030026267f542d978aef8d88f049ee 1.png', 'smite-vamana-womens-t-shirt 1.png', 'Untitled 159 4.png', 'download (2) 2.png', 'istockphoto-1202463006-612x612 1.png', 'istockphoto-472319507-612x612 2.png', 'images (1) 2.png', '62a596528d14276c40b967c533adb608fac3b1980ae6444da1204422938338ab 2.png', 'download (6) 1.png', 'elephant-head-icon-in-flat-design-vector-14477508 1.png', 'istockphoto-472319507-612x612 1.png', '62a596528d14276c40b967c533adb608fac3b1980ae6444da1204422938338ab 1.png', 'download (6) 2.png', '1864557 1.png', 'Screen Shot 2022-10-02 at 8.41 1.png', 'Untitled 153.png', 'Untitled 152.png']
const weaponFiles = ['199359 1.png', 'illustration-damru-vector-design-260nw-1677783889 1.png', 'wheel-cart-iconcartoon-icon-vector-28035672 1.png', '2764687 1.png', 'wheel-cart-iconcartoon-icon-vector-28035672 2.png', 'images 1.png', 'sun 1.png', 'sickle 1.png', 'arrow 1.png', '1922956-200 1.png', 'mace 1.png', 'spear 1.png', 'illustration-of-indian-musical-instrument-used-in-hindustani-classical-music-of-india-vector 1.png', 'bow 1.png', 'sword 1.png', 'axe 1.png', 'images (1) 1.png', 'Untitled 147 1.png', '1184632 1.png', 'image 1.png', 'stockgiu210802122 1.png', 'whip-icon-flat-isolated-vector-38616318 1.png']
// loop through the array of image file names
for (const fileName of imageFiles) {
  // create an image element for each file
  const image = document.createElement('img');
  image.src = 'Character_Features/'+fileName;
  // create a label element for the image
  const label = document.createElement('label');
  label.appendChild(image);
  // create a checkbox input element
  const checkbox = document.createElement('input');
  checkbox.type = 'checkbox';
  // add a change event listener to the checkbox
  checkbox.addEventListener('change', (event) => {
    // get the file name of the selected image
    const file = event.target.nextElementSibling.firstElementChild.src;
    // add the file name to the array of selected images if the checkbox is checked, or remove it if the checkbox is not checked
    if (event.target.checked) {
      selectedImages.push(file);
    } else {
      const index = selectedImages.indexOf(file);
      selectedImages.splice(index, 1);
    }
  });
  // add the checkbox and label to the container
  container.appendChild(checkbox);
  container.appendChild(label);
}


//add weapons
for (const fileName of weaponFiles) {
  // create an image element for each file
  const image = document.createElement('img');
  image.src = 'Weapons/'+fileName;
  // create a label element for the image
  const label = document.createElement('label');
  label.appendChild(image);
  // create a checkbox input element
  const checkbox = document.createElement('input');
  checkbox.type = 'checkbox';
  // add a change event listener to the checkbox
  checkbox.addEventListener('change', (event) => {
    // get the file name of the selected image
    const file = event.target.nextElementSibling.firstElementChild.src;
    // add the file name to the array of selected images if the checkbox is checked, or remove it if the checkbox is not checked
    if (event.target.checked) {
      selectedImages.push(file);
    } else {
      const index = selectedImages.indexOf(file);
      selectedImages.splice(index, 1);
    }
  });
  // add the checkbox and label to the container
  weapon_container.appendChild(checkbox);
  weapon_container.appendChild(label);
}

