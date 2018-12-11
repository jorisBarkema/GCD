from GCD import GCD
from ExtEuclid import ExtEuclid
import time
import random

Euclid = ExtEuclid()
values = []
results = []

begin_time = time.time()

for _ in range(10000):
    randoms = (random.randrange(1, 1000), random.randrange(1, 1000))
    values.append(randoms)
    results.append(Euclid.compute(randoms[0], randoms[1]))

end_time = time.time()

"""
For result verification
"""

for i in range(len(results)):
    print("p:   " + str(values[i][0]))
    print("q:   " + str(values[i][1]))
    print("GCD: " + str(results[i][0]))
    print("S:   " + str(results[i][1]))
    print("T:   " + str(results[i][2]))
    print()

    # s * p + t * q = gcd
    if not ((results[i][1] * values[i][0] + results[i][2] * values[i][1]) == results[i][0]):
        print("s * p + t * q:" + str(results[i][1] * values[i][0] + results[i][2] * values[i][1]))
        print("gcd: " + str(results[i][0]))

        
        Euclid.compute(values[i][0], values[i][1], True)
        raise Exception("GCD is not equal to the extended euclid test")


print("duration (ms): " + str((end_time - begin_time) * 1000))
