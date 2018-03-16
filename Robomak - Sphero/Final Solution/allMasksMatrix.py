import numpy as np
import cv2

def finalMatrix(height, width, mask_red, mask_blue):
    final_matrix = np.zeros([height, width])
    for i in range(height):
        for j in range(width):
            if mask_red[i, j] == 255:
                final_matrix[i, j] = 1
            elif mask_blue[i, j] == 255:
                final_matrix[i, j] = 0

    final_matrix_small = cv2.resize(final_matrix, (0, 0), fx=0.25, fy=0.25, interpolation=cv2.INTER_CUBIC)

    return final_matrix_small