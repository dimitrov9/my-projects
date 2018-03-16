# import the necessary packages
import numpy as np
import cv2
import sledenje_pshero as ss
import astar
import PIL
import imutils
from matplotlib.pyplot import imshow, show


# load the image
image = cv2.imread('5.jpg', cv2.IMREAD_COLOR)
height, width, channels = image.shape
hsv = cv2.cvtColor(image, cv2.COLOR_BGR2HSV)


# define the boundaries
uu_red = ([0, 40, 20], [10, 255, 255])
mask_red1 = cv2.inRange(hsv, np.array(uu_red[0]), np.array(uu_red[1]))

up_red = ([170, 40, 20], [180, 255, 255])
mask_red2 = cv2.inRange(hsv, np.array(up_red[0]), np.array(up_red[1]))

mask_red = cv2.add(mask_red1, mask_red2)

uu_blue = ([100, 30, 20], [125, 255, 255])
mask_blue = cv2.inRange(hsv, np.array(uu_blue[0]), np.array(uu_blue[1]))


kernelOpen = np.ones((5,5))
kernelClose = np.ones((5,5))
#kernelClose2 = np.ones((50,50))
maskOpen_red = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernelOpen)
maskClose_red = cv2.morphologyEx(maskOpen_red, cv2.MORPH_CLOSE, kernelClose)
#maskClose_red = cv2.morphologyEx(maskClose_red, cv2.MORPH_CLOSE, kernelClose2)
kernel = np.ones((12, 12),np.uint8)
maskClose_red = cv2.dilate(maskClose_red, kernel, iterations = 1)

kernelOpen = np.ones((5,5))
kernelClose = np.ones((5,5))
maskOpen_blue = cv2.morphologyEx(mask_blue, cv2.MORPH_OPEN, kernelOpen)
maskClose_blue = cv2.morphologyEx(maskOpen_blue, cv2.MORPH_CLOSE, kernelClose)


blue_dots = []
# find contours in the thresholded image
cnts = cv2.findContours(maskClose_blue.copy(), cv2.RETR_EXTERNAL,
	cv2.CHAIN_APPROX_SIMPLE)
cnts = cnts[0] if imutils.is_cv2() else cnts[1]

# loop over the contours
for c in cnts:
    # compute the center of the contour
    M = cv2.moments(c)
    try:
        cX = int(M["m10"] / M["m00"])
    except ZeroDivisionError:
        cX = 0

    try:
        cY = int(M["m01"] / M["m00"])
    except ZeroDivisionError:
        cY = 0
    if cY!=0 and cX!=0:
        blue_dots.append((int(cY/4), int(cX/4)))
        #blue_dots.append((cY, cX))

    #cv2.drawContours(maskClose_blue, [c], -1, (0, 255, 0), 2)
    #cv2.circle(maskClose_blue, (cX, cY), 7, (255, 255, 255), -1)

    # show the image
    #cv2.imshow("Image", maskClose_blue)
    #cv2.waitKey(0)
#print(len(blue_dots))

final_matrix = np.zeros([height, width])
#final_matrix = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

for i in range(height):
    for j in range(width):
        if maskClose_red[i,j] == 255:
            final_matrix[i,j] = int(1)
        elif maskClose_blue[i, j] == 255:
            final_matrix[i, j] = int(0)

#print(final_matrix)

final_matrix_small = cv2.resize(final_matrix,(0, 0),fx=0.25,fy=0.25, interpolation = cv2.INTER_CUBIC)

h, w = final_matrix_small.shape
print(h, w)
#cv2.imshow("blue", final_matrix_small)
#cv2.waitKey(0)

y, x, r = ss.initialPointSphero(image)

final_matrix_small = (final_matrix_small>=0.5).astype(int)
np.set_printoptions(threshold=np.nan)



#print(final_matrix_small)
print(blue_dots)

path = astar.find_path(final_matrix_small, (int(y/4), int(x/4)), blue_dots[0])
#path = astar.find_path(final_matrix_small, (20,20 ), (50,50))
#path = astar.find_path(final_matrix, (x, y), blue_dots[0])
print (path)
print(len(path))

for i in range(height):
    for j in range(width):
        if (j,i) in path:
            final_matrix_small[j,i] = 1
            #final_matrix[i,j] = 255

imshow(final_matrix_small)
show()

cv2.imshow('pateka', final_matrix_small)
#cv2.imshow('pateka', final_matrix)
cv2.waitKey(0)