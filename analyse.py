from GCD import GCD
from ExtEuclid import ExtEuclid
from Stein import Stein
import time
import random

Euclid = ExtEuclid()
Stein = Stein()

numtests = 10
testsize = 100

for _ in range(numtests):
    values = []
    results = []

    for _ in range(testsize):
        randoms = (random.randrange(1, 2 ** 2048), random.randrange(1, 2 ** 2048))
        values.append(randoms)

    begin_time = time.time()

    for i in range(testsize):
        results.append(Euclid.compute(values[i][0], values[i][1]))
        #results.append(Stein.iterative(values[i][0], values[i][1]))

    end_time = time.time()

    print("duration (ms): " + str((end_time - begin_time) * 1000))

# below a small test to test multiplication, division and bitoperator speeds
"""
values = []

for _ in range(10000):
    values.append(random.randrange(1, 2 ** 2048))

for _ in range(10):
    begin_time = time.time()

    #for v in values: v = v >> 1
    #for v in values: v = v << 1
    #for v in values: v = v // 2
    for v in values: v = v * 2

    end_time = time.time()
    print("duration (ms): " + str((end_time - begin_time) * 1000))
"""
