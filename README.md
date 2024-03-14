# ImageDownsizer
Homework task for Parallel Programming in University of Plovdiv

## Overview
This WinForms application allows users to downsize images while preserving the aspect ratio. Users can select an image using the standard open file dialog, specify a down-scaling factor (as a percentage of the original size), and produce a new down-scaled image.

## Bilinear Interpolation
Bilinear interpolation is a method of interpolating the values of a function at arbitrary points in between known values. In the context of image processing, it is used to interpolate pixel values when scaling an image.

When downscaling an image using bilinear interpolation, each pixel in the output image is computed by averaging the values of the four nearest pixels in the original image. This interpolation technique results in smoother transitions and better image quality compared to simple averaging.

<img src="https://i.stack.imgur.com/t7z2N.png" width="70%"><br>

## Results
Please check the Results folder
