# import the necessary packages
import numpy as np
import argparse
import cv2


# load the image
image = cv2.imread('2.jpg', cv2.IMREAD_COLOR)
height, width, channels = image.shape
hsv = cv2.cvtColor(image, cv2.COLOR_BGR2HSV)


# define the list of boundaries
boundaries = [
	([164, 50, 45], [359, 359, 359]),
	([217, 50, 50], [260, 359, 359]),
	([75, 50, 50], [160, 359, 359])
     ]

uu_red = ([0, 40, 20], [10, 255, 255])
mask_red1 = cv2.inRange(hsv, np.array(uu_red[0]), np.array(uu_red[1]))

up_red = ([170, 40, 20], [180, 255, 255])
mask_red2 = cv2.inRange(hsv, np.array(up_red[0]), np.array(up_red[1]))

mask_red = cv2.add(mask_red1, mask_red2)
#cv2.imshow("img_r", mask_red)

uu_blue = ([100, 30, 20], [130, 255, 255])
mask_blue = cv2.inRange(hsv, np.array(uu_blue[0]), np.array(uu_blue[1]))
#cv2.imshow("img_b", mask_blue)

uu_green = ([30, 30, 20], [90, 255, 255])
mask_green = cv2.inRange(hsv, np.array(uu_green[0]), np.array(uu_green[1]))
cv2.imshow("img_g", mask_green)

kernelOpen = np.ones((5,5))
kernelClose = np.ones((5,5))
maskOpen_red = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernelOpen)
maskClose_red = cv2.morphologyEx(maskOpen_red, cv2.MORPH_CLOSE, kernelClose)

kernelOpen = np.ones((5,5))
kernelClose = np.ones((5,5))
maskOpen_blue = cv2.morphologyEx(mask_blue, cv2.MORPH_OPEN, kernelOpen)
maskClose_blue = cv2.morphologyEx(maskOpen_blue, cv2.MORPH_CLOSE, kernelClose)


kernelOpen = np.ones((5,5))
kernelClose = np.ones((5,5))
maskOpen_green = cv2.morphologyEx(mask_green, cv2.MORPH_OPEN, kernelOpen)
maskClose_green = cv2.morphologyEx(maskOpen_green, cv2.MORPH_CLOSE, kernelClose)
cv2.imshow("img_g2", maskClose_green)

# Final Matrix
final_matrix = np.zeros([height, width])
for i in range(height):
    for j in range(width):
        if maskClose_red[i,j] == 0 and maskClose_blue[i,j]==0:
            final_matrix[i,j] = 0
        elif maskClose_red[i, j] == 255:
            final_matrix[i, j] = 0.5
        elif maskClose_blue[i,j] == 255:
            final_matrix[i, j] = 1

cv2.imshow('img',final_matrix)



kernelOpen = np.ones((5,5))
kernelClose = np.ones((5,5))
maskOpen = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernelOpen)
maskClose = cv2.morphologyEx(maskOpen, cv2.MORPH_CLOSE, kernelClose)
output1 = cv2.bitwise_and(image, image, mask=maskClose)
#cv2.imshow("images", np.hstack([image, output]))
cv2.imshow("images", np.hstack([image, output1]))
cv2.waitKey(0)




