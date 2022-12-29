import os
from PIL import Image

# Set the directory containing the images
directory = '/Users/sid/Desktop/Code/siddu1998.github.io/CCI/Weapons'

# Iterate through all the files in the directory
for filename in os.listdir(directory):
  # Check if the file is an image
  if filename.endswith(".jpg") or filename.endswith(".png"):
    # Open the image
    image = Image.open(os.path.join(directory, filename))
    # Flip the image horizontally
    image = image.transpose(Image.FLIP_LEFT_RIGHT)
    # Save the flipped image
    saved_image = f"flipped_{filename}.png"
    image.save(os.path.join(directory, saved_image))
  else:
    continue

print('DONE')
