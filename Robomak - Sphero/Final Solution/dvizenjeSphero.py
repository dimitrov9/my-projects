import timeit
import numpy as np


def control_sphero(dist, groundspeed, Kp, Ki, Kd, stopRadius, maxspeed, minspeed, restartspeed, clearvars):
    #persistent = []
    init = []
    prevu = []
    preve = []
    prevt = []
    prev2e = []
    prev2t = []

#Initialize
    if len(init) == 0:
     prevu = 0
     preve = 0
     prev2e = 0
     prev2t = timeit.default_timer()
     prevt = timeit.default_timer()
     init = 1;


    #PID Control
    t = timeit.default_timer()
    dt = t - prevt;
    dt2 = prevt - prev2t;

    eps = np.finfo(float).eps
    if dist < stopRadius:
        u = 0;
    else:
        if (dt < eps) or (dt2 < eps):
            u = prevu + Kp * (dist - preve) + Ki * dt * dist;
        else:
            u = prevu + Kp * (dist - preve) + Ki * dt * dist + Kd * ((dist - preve) / dt - (preve - prev2e) / dt2);


        if groundspeed < 2 and u < restartspeed:
            u = restartspeed;




    prevu = u
    prev2e = preve
    preve = dist
    prev2t = prevt
    prevt = t

#Saturate
    if u > maxspeed:
        speed = maxspeed;
    elif u < minspeed:
        speed = minspeed;
    else:
        speed = u;

    return speed



