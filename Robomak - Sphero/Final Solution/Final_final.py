# import the necessary packages
import numpy as np
import cv2
import countDots
import masks
import sledenje_pshero as ss
import allMasksMatrix as aMM
import astar
import math
import sphero  #it allows you to conect with your sphero, you have this library in your RBMS folder
import agolMegu3Tocki
from math import degrees
import time
import tsp
import imutils
from matplotlib.pyplot import imshow, show
import tsp2
import pygame.camera

#sph = sphero.Sphero('68:86:E7:07:1F:F8')
#sph.set_rgb(0,255,0) # give sphero some color

#time.sleep(10)

pygame.camera.init()
DEVICE = pygame.camera.list_cameras()[0]
SIZE = (640, 480)
pygame.init()
pygame.camera.init() # simplest case of opening a camera and capturing a frame as a surface, moreover, the surface called image is whatever the camera was seeing when get_image() was called.
#display = pygame.display.set_mode(SIZE, 0) #represents from now on the window on screen; it is a pygame.Surface object (SIZE is the resolution,and 0 are the flags )
camera = pygame.camera.Camera(DEVICE, SIZE) #loads your camera (device is your camera at list 1, size is the resolution)
camera.start() #the camera starts
screen = pygame.surface.Surface(SIZE, 0) #pygame object for representing images
capture = True #we going to use this variable to make a infinity while cycle
screen = camera.get_image(screen)
image = pygame.surfarray.array3d(screen)



#print(image.dtype)
#display.blit(screen, (0, 0))
#pygame.display.flip()
# connect sphero


time.sleep(3)
#cap = cv2.VideoCapture(0)
#print(cap.isOpened())
#cap.open(1)
# load the image
#image = cv2.imread('7.jpg', cv2.IMREAD_COLOR)

#ret,image = cap.read()
#print(ret)
#cv2.imshow('g',image)
#cv2.waitKey(0)

image_bgr = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
image_bgr_rotate = cv2.flip(imutils.rotate_bound(image_bgr, 90),0)
#cv2.imshow('d',image_bgr_rotate)
#cv2.waitKey(0)

hsv = cv2.cvtColor(image, cv2.COLOR_RGB2HSV)
hsv = cv2.flip(imutils.rotate_bound(hsv, 90),0)
#cv2.imshow('img',hsv)
#cv2.waitKey(0)
height, width, channels = hsv.shape
# Find blue mask
uu_blue = ([100, 50, 50], [125, 255, 255])
maskClose_blue = masks.findMask(uu_blue, hsv)

#cv2.imshow('g',maskClose_blue)
#cv2.waitKey(0)
#cv2.imshow('plava', maskClose_blue)
#cv2.waitKey(0)

#cv2.imshow('slika', image_bgr_rotate)
#cv2.waitKey(0)

y, x, r = ss.initialPointSphero(image_bgr_rotate)
'''
uu_sphero = ([30, 30, 30], [80, 255, 255])
maskClose_shpero = masks.findMask(uu_sphero, hsv)

cv2.imshow('d',maskClose_shpero)
cv2.waitKey(0)

sphero_dots = countDots.countBlue(maskClose_shpero)
x = sphero_dots[0][0]
y = sphero_dots[0][1]

'''
# Count Blue dots
blue_dots = countDots.countBlue(maskClose_blue)


# initial Sphero DA BARA DODEKA NE NAJDE



# Find red mask
uu_red = ([0, 40, 20], [10, 255, 255])
mask_red1 = cv2.inRange(hsv, np.array(uu_red[0]), np.array(uu_red[1]))
up_red = ([170, 40, 20], [180, 255, 255])
mask_red2 = cv2.inRange(hsv, np.array(up_red[0]), np.array(up_red[1]))
mask_red = cv2.add(mask_red1, mask_red2)
kernelOpen = np.ones((5,5))
kernelClose = np.ones((5,5))
maskOpen_red = cv2.morphologyEx(mask_red, cv2.MORPH_OPEN, kernelOpen)
maskClose_red1 = cv2.morphologyEx(maskOpen_red, cv2.MORPH_CLOSE, kernelClose)

#cv2.imshow('d',maskClose_red1)
#cv2.waitKey(0)

# Scale RED mask for better obsticle avoidance
# NE RABOTI ZA 2.jpg!!!!
kernel = np.ones((int(r*1.5), int(r*1.5)),np.uint8)
maskClose_red = cv2.dilate(maskClose_red1, kernel, iterations = 1)

#cv2.imshow('red', maskClose_red)
#cv2.waitKey(0)

blue_old = maskClose_blue.copy

# Order blue dots
print("blue dots unordered:")
print(blue_dots)
# blue_dots = blue_dots.insert(0, (int(y/4), int(x/4)))
blue_dots_list = [list(elem) for elem in blue_dots]
blue_dots_list.append([int(x / 4), int(y / 4)])
blue_dots_new = tsp2.optimized_travelling_salesman(blue_dots_list, [int(x / 4), int(y / 4)])
print("blue dots ordered:")
print(blue_dots_new)



final_matrix = aMM.finalMatrix(height, width, maskClose_red, maskClose_blue)

def UpdateSpheroPosition() :
    # Replace the previus point
    # Find it in the matrix and replace it with 0
    # then add the new position to the matrix
    # return matrix??
    return None

print(tuple(blue_dots_new[0]))
'''
path = astar.find_path(final_matrix, blue_dots_new[0], (int(x/4), int(y/4)))

print(path)
new_path = []
final_path = path
new_path.append((int(y / 4), int(x / 4)))
items = range(len(path))
items = items[1::1]
for j in items:
    if 0 <= j + 1 < len(path):
        if agolMegu3Tocki.findAngle(path[j - 1], path[j], path[j + 1]):
            new_path.append(path[j])

new_path.append(blue_dots_new[0])
'''
new_path =[]
final_path = []
for i in range(len(blue_dots_new)-1):
    path = astar.find_path(final_matrix, tuple(blue_dots_new[i+1]),tuple(blue_dots_new[i]))
    final_path += path
    items = range(len(path))
    items = items[1::1]
    for j in items:
        if 0 <= j + 1 < len(path):
            if agolMegu3Tocki.findAngle(path[j - 1], path[j], path[j + 1]):
                new_path.append(path[j])
    new_path.append(blue_dots_new[i+1])

# SLIKAAA
for i in range(height):
    for j in range(width):
        if (i, j) in final_path:
            final_matrix[i, j] = 1
            # final_matrix[i,j] = 255
        if (i, j) in new_path:
            final_matrix[i, j] = 0.5

imshow(final_matrix)
show()

# new_path should contain every step we should take

def calculateDistance(pt1,pt2):
    return math.sqrt((pt2[1] - pt1[1])^2 + (pt2[0] - pt1[0])^2)

# calculate angle
def calculateAngle(pt1,pt2):
    # check for formula
    angle = math.atan2(pt2[1] - pt1[1], pt2[0] - pt1[0]) * 180/math.pi
    angle = degrees(angle)
    if angle < 0:
        angle +=360
    return angle

while len(new_path)>0:
    screen = camera.get_image(screen)
    image = pygame.surfarray.array3d(screen)
    image = cv2.cvtColor(image, cv2.COLOR_RGB2HSV)
    image = imutils.rotate_bound(image, 90)
    '''
    uu_sphero = ([140, 100, 50], [160, 255, 255])
    maskClose_shpero = masks.findMask(uu_sphero, image)

    sphero_dots = countDots.countBlue(maskClose_shpero)
    x = sphero_dots[0][0]
    y = sphero_dots[0][1]
    '''
    time.sleep(3)
    x, y, r = ss.initialPointSphero(image)
    if (calculateDistance((x, y), new_path[0]) < 5):
        new_path = new_path[1::]
    angle = calculateAngle((x,y),new_path[0])

    print(angle)
    # calculate speed with distance
    #sph.rol(20,angle)
    #time.sleep(1)
    #sph.roll(0,angle)





'''
# PATEKA NA SPHEROTO
while len(blue_dots_new) != 0:
    #print(len(blue_dots))
    # najdi mask close blue na novata slika
    # ne e potrebno samo Spheroto da se locira treba
    #final_matrix = aMM.finalMatrix(height, width, maskClose_red, maskClose_blue)
    h, w = final_matrix.shape

    # momentalna lokacija na spheroto
    x, y, r = ss.initialPointSphero(image)


    # Obratno???
    path = astar.find_path(final_matrix, blue_dots[0], (int(y/4), int(x/4)))
    #path = [list(elem) for elem in path] # Komentirano e za da printa
    print(path)
    print('path')
    #xs = [item[0] for item in path]
    #ys = [item[1] for item in path]


    # Najdi gi tockite na prekrsuvanje
    new_path = []
    new_path.append([int(y/4), int(x/4)])

    items = range(len(path))
    items = items[1::1]

    """for j in items:
        if 0 <= j+2 < len(path):
            agol = agolMegu3Tocki.findAngle(path[j-2], path[j], path[j+2])
            if abs(agol) not in range(180-30, 180+30): #Opseg za da ja smeta linijata za prava
                new_path.append(path[j])"""

    for j in items:
        if 0 <= j+1 < len(path):
            if agolMegu3Tocki.findAngle(path[j-1],path[j],path[j+1]):
                new_path.append(path[j])



    new_path.append(path[len(path)-1])

    print(new_path)
    print(len(new_path))


    # SLIKAAA
    for i in range(height):
        for j in range(width):
            if (i, j) in path:
                final_matrix[i, j] = 1
                #final_matrix[i,j] = 255
            if (i, j) in new_path:
                final_matrix[i, j] = 0.5

    imshow(final_matrix)
    show()

    xs_new = [item[0] for item in new_path]
    ys_new = [item[1] for item in new_path]
    print(len(xs_new))

    # presmetaj pateka od sphero do edna precka
    for i in range(len(xs_new)-1):
    #for i in range(len(xs)-1):
        # get element from tuple
        y_distance = ys_new[i+1] - ys_new[i]
        #y_distance = ys[i+1] - ys[i]
        x_distance = xs_new[i+1] - xs_new[i]
        #x_distance = xs[i+1] - xs[i]
        r = math.sqrt((x_distance**2)+(y_distance**2))
        try:
            div = y_distance/x_distance
        except ZeroDivisionError:
            div = 0
        theta = math.atan2(y_distance, x_distance)
        #theta = np.arctan2(x_distance, y_distance)
        theta = degrees(theta)
        if theta < 0:
            theta += 360
        #theta = theta+180
        distance = r*1.25
        print(theta)
        sph.roll(int(distance), int(theta))
        time.sleep(4)

        #ili ovde da proveri dali e butnata (ama ke treba da presmeta nova pateka
    blue_dots_new.pop()

    # proveri dali preckata e butnata

    # mask blue old - mask blue new
    # ako e butnata delete from blue_dots
    # contunue

print(len(blue_dots))
print("Finish")

'''



