import cv2

image = cv2.imread('6.jpg', cv2.IMREAD_GRAYSCALE)
cv2.imshow('img',image)
cv2.waitKey(0)