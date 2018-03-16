import cv2
import math
import numpy as np
import sys

def non_maximal_supression(x):
    for f in features:
        distx = f.pt[0] - x.pt[0]
        disty = f.pt[1] - x.pt[1]
        dist = math.sqrt(distx*distx + disty*disty)
        if (f.size > x.size) and (dist<f.size/2):
            return True

thresh = 70
img = cv2.imread('1.jpg')
bw = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

detector = cv2.FeatureDetector_create('MSER')
features = detector.detect(bw)
features.sort(key = lambda x: -x.size)

features = [ x for x in features if x.size > 70]
reduced_features = [x for x in features if not non_maximal_supression(x)]

for rf in reduced_features:
    cv2.circle(img, (int(rf.pt[0]), int(rf.pt[1])), int(rf.size/2), (0,0,255), 3)

cv2.imshow("iris detection", img)
cv2.waitKey()