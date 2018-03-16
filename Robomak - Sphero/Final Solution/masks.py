import cv2
import numpy as np

def findMask(uu, hsv):

    mask = cv2.inRange(hsv, np.array(uu[0]), np.array(uu[1]))

    kernelOpen = np.ones((5,5))
    kernelClose = np.ones((5,5))
    maskOpen = cv2.morphologyEx(mask, cv2.MORPH_OPEN, kernelOpen)
    maskClose = cv2.morphologyEx(maskOpen, cv2.MORPH_CLOSE, kernelClose)
    return maskClose
