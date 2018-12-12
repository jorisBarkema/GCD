from GCD import GCD
from ExtEuclid import ExtEuclid
from Stein import Stein
import time
import random

Euclid = ExtEuclid()
Stein = Stein()
values = []
results = []

for _ in range(10):
    randoms = (random.randrange(1, 2 ** 2048), random.randrange(1, 2 ** 2048))
    values.append(randoms)

begin_time = time.time()

for i in range(10):
    results.append(Euclid.standard(values[i][0], values[i][1]))
    #results.append(Stein.bitops(values[i][0], values[i][1]))

end_time = time.time()

"""
For result verification of gcd, s, t from extended euclidian algorithm
"""


for i in range(len(results)):
    # s * p + t * q = gcd
    #if not ((results[i][1] * values[i][0] + results[i][2] * values[i][1]) == results[i][0]):
        print("p:   " + str(values[i][0]))
        print("q:   " + str(values[i][1]))
        print("GCD: " + str(results[i][0]))
        print("S:   " + str(results[i][1]))
        print("T:   " + str(results[i][2]))
        print()
        print("s * p + t * q:" + str(results[i][1] * values[i][0] + results[i][2] * values[i][1]))
        print("gcd: " + str(results[i][0]))
        
        #Euclid.standard(values[i][0], values[i][1], True)
        #raise Exception("GCD is not equal to the extended euclid test")


"""
For result verification of Stein's algorithm
"""

"""
for i in range(len(results)):
    print("p:   " + str(values[i][0]))
    print("q:   " + str(values[i][1]))
    print("GCD: " + str(results[i]))
    print()

    #divide both by GCD, if result is not 1 there is another common factor wich means the gcd is not the greatest common divisor
    if not (Stein.bitops(values[i][0] // results[i], values[i][1] // results[i]) == 1):
        print("p / gcd: " + str(values[i][0] // results[i]))
        print("q / gcd: " + str(values[i][1] // results[i]))
        print("gcd of those two: " + str(Stein.bitops(values[i][0] // results[i], values[i][1] // results[i])))
        print()
        raise Exception("GCD is not equal to the bitops stein test")
"""

print("duration (ms): " + str((end_time - begin_time) * 1000))
