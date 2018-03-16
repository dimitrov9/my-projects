import numpy as np
from math import degrees
import math

def findAngle(a, b, c):

    a = np.array(a)
    b = np.array(b)
    c = np.array(c)

    ba = a - b
    bc = c - b

    first = np.arctan2(b[0] - a[0],b[1]-a[1])
    second = np.arctan2(c[0] - b[0],c[1]-b[1])

    return abs((first - second)) > 0

    """cosine_angle = np.dot(ba, bc) / (np.linalg.norm(ba) * np.linalg.norm(bc))
    #angle = np.arccos(cosine_angle)
    if round(cosine_angle,1) == 1.0 or round(cosine_angle,1) == -1.0:
        cosine_angle = int(cosine_angle)
    angle = np.arccos(cosine_angle)
    return degrees(angle)"""


a = [0, 0]
b = [2, 4]
c = [6, 6]
print(findAngle(a, b, c))

