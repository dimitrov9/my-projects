# import the necessary packages
import numpy as np
import cv2
import countDots
import masks
import sledenje_pshero as ss
import allMasksMatrix as aMM
import astar
import math
import sphero
import agolMegu3Tocki
from math import degrees
import time
import imutils
import tsp2
import pygame.camera
from skimage.measure import compare_ssim
from matplotlib.pyplot import imshow, show

# Connect sphero
sph = sphero.Sphero('68:86:E7:07:1F:F8')
sph.set_rgb(0, 255, 0)  # give sphero some color(GREEN)
time.sleep(5)

# Inicijalizacija na kamera
pygame.camera.init()
DEVICE = pygame.camera.list_cameras()[1]
SIZE = (640, 480)
pygame.init()
pygame.camera.init()
camera = pygame.camera.Camera(DEVICE, SIZE)
camera.start()
screen = pygame.surface.Surface(SIZE, 0)
screen = camera.get_image(screen)
capture = True

while capture:
    image = pygame.surfarray.array3d(screen)
    time.sleep(5)

    # Rotacija na slikata i BGR
    image_bgr = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
    image_bgr_rotate = imutils.rotate_bound(image_bgr, 90)

    # Rotacija i HSV
    hsv = cv2.cvtColor(image, cv2.COLOR_RGB2HSV)
    hsv = imutils.rotate_bound(hsv, 90)

    # Visina i sirina
    height, width, channels = hsv.shape

    # Find blue mask
    uu_blue = ([80, 100, 50], [125, 255, 255])
    maskClose_blue = masks.findMask(uu_blue, hsv)

    # Koordinati na sphero od image
    y, x, r = ss.initialPointSphero(image_bgr_rotate)

    # Count Blue dots
    blue_dots = countDots.countBlue(maskClose_blue)

    # Find red mask and dilatate
    uu_red = ([0, 100, 50], [10, 255, 255])
    mask_red1 = cv2.inRange(hsv, np.array(uu_red[0]), np.array(uu_red[1]))

    up_red = ([170, 100, 50], [180, 255, 255])
    mask_red2 = cv2.inRange(hsv, np.array(up_red[0]), np.array(up_red[1]))

    mask_red = cv2.add(mask_red1, mask_red2)

    kernelOpen = np.ones((5, 5))
    kernelClose = np.ones((5, 5))

    maskOpen_red = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernelOpen)
    maskClose_red1 = cv2.morphologyEx(maskOpen_red, cv2.MORPH_CLOSE, kernelClose)

    kernel = np.ones((int(r * 1.5), int(r * 1.5)), np.uint8)
    maskClose_red = cv2.dilate(maskClose_red1, kernel, iterations=1)

    # Order blue dots
    print("blue dots unordered:")
    print(blue_dots)
    #blue_dots = blue_dots.insert(0, (int(y/4), int(x/4)))
    blue_dots_list = [list(elem) for elem in blue_dots]
    blue_dots_list.append([int(y/4), int(x/4)])
    blue_dots_new = tsp2.optimized_travelling_salesman(blue_dots_list, [int(y/4), int(x/4)])
    print("blue dots ordered:")
    print(blue_dots_new)

    # Konecna matrica so dvete maski
    final_matrix = aMM.finalMatrix(height, width, maskClose_red, maskClose_blue)

    imshow(final_matrix)
    show()
    cv2.imshow('final_matrix', final_matrix)
    cv2.waitKey(0)

    h, w = final_matrix.shape

    blue_old = maskClose_blue.copy()
    print(blue_old)

    while len(blue_dots_new) != 0:

        # Momentalna lokacija na spheroto
        image = pygame.surfarray.array3d(screen)
        image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
        image = imutils.rotate_bound(image, 90)
        time.sleep(10)
        y, x, r = ss.initialPointSphero(image)

        # Najdi A* od spheroto do slednata precka
        path = astar.find_path(final_matrix, blue_dots_new[0], (int(y / 4), int(x / 4)))
        path = [list(elem) for elem in path]  # Komentirano e za da printa

        xs = [item[0] for item in path]
        ys = [item[1] for item in path]

        # Najdi gi tockite na prekrsuvanje
        new_path = []
        new_path.append([int(y / 4), int(x / 4)])

        items = range(len(path))
        items = items[1::1]

        for j in items:
            if 0 <= j + 1 < len(path):
                if agolMegu3Tocki.findAngle(path[j - 1], path[j], path[j + 1]):
                    new_path.append(path[j])

        new_path.append(path[len(path) - 1])

        xs_new = [item[0] for item in new_path]
        ys_new = [item[1] for item in new_path]

        # presmetaj agli i dolzina na patekata
        for i in range(len(xs_new) - 1):

            # get element from tuple
            y_distance = ys_new[i + 1] - ys_new[i]
            x_distance = xs_new[i + 1] - xs_new[i]

            r = math.sqrt((x_distance ** 2) + (y_distance ** 2))

            theta = math.atan2(y_distance, x_distance)
            theta = degrees(theta)
            theta = (theta + 360) % 360

            distance = r * 1.25
            print(theta)

            sph.roll(30, theta)
            time.sleep(4)

            if int(round(distance,1)) == 5:
                sph.roll(30, int(round(theta)))
                time.sleep(0.55)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==10:
                sph.roll(30, int(round(theta)))
                time.sleep(0.7)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==15:
                sph.roll(30, int(round(theta)))
                time.sleep(0.85)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==20:
                sph.roll(30, int(round(theta)))
                time.sleep(1.05)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==25:
                sph.roll(30, int(round(theta)))
                time.sleep(1.15)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==30:
                sph.roll(30, int(round(theta)))
                time.sleep(1.5)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==35:
                sph.roll(30, int(round(theta)))
                time.sleep(1.6)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==40:
                sph.roll(30, int(round(theta)))
                time.sleep(1.8)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==45:
                sph.roll(30, int(round(theta)))
                time.sleep(2)
                sph.roll(0, int(round(theta)))
            elif int(round(distance,1)) ==50:
                sph.roll(30, int(round(theta)))
                time.sleep(2.05)
                sph.roll(0, int(round(theta)))

            # ili ovde da proveri dali e butnata (ama ke treba da presmeta nova pateka

        image = pygame.surfarray.array3d(screen)
        hsv = cv2.cvtColor(image, cv2.COLOR_RGB2HSV)
        hsv = imutils.rotate_bound(hsv, 90)

        # Find blue mask
        uu_blue = ([100, 30, 20], [125, 255, 255])
        mask_blue_new = masks.findMask(uu_blue, hsv)

        score = 0
        for i in range(len(blue_old)):
            for j in range(len(blue_old[0])):
                if blue_old[i, j] == mask_blue_new:
                    score+=1

        h, w = mask_blue_new.size
        res = h*w
        if (100/res)*score <= 80:
            blue_dots_new = blue_dots_new[1:]

        # mask blue old - mask blue new
        # ako e butnata delete from blue_dots
        # contunue
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            capture = False

print(len(blue_dots))
print("Finish")
camera.stop()
pygame.quit()




