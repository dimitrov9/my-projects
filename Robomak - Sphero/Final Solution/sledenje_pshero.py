# import the necessary packages
import numpy as np
import argparse
import cv2

def initialPointSphero(image):
    # load the image, clone it for output, and then convert it to grayscale
    #image = cv2.imread('7.jpg', cv2.IMREAD_GRAYSCALE)
    image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    output = image.copy()
    cv2.imshow('im', image)
    # detect circles in the image
    circles = cv2.HoughCircles(image, cv2.HOUGH_GRADIENT, 1, 1000, param1=50, param2=30, minRadius=5, maxRadius=30)

    # ensure at least some circles were found
    if circles is not None:
        # convert the (x, y) coordinates and radius of the circles to integers
        circles = np.round(circles[0, :]).astype("int")

        # loop over the (x, y) coordinates and radius of the circles
        for (x, y, r) in circles:
            # draw the circle in the output image, then draw a rectangle
            # corresponding to the center of the circle
            cv2.circle(output, (x, y), r, (0, 255, 0), 2)
            #cv2.rectangle(output, (x - r, y - r), (x + r, y + r), (0, 128, 255), -1)

            # show the output image
            #cv2.imshow('sphero', output)
            #cv2.waitKey(0)
        return x, y, r