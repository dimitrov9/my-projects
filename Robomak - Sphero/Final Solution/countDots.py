import cv2, imutils

def countBlue(maskClose_blue):
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
        if cY != 0 and cX != 0:
            blue_dots.append((int(cY / 4), int(cX / 4)))

    return blue_dots

