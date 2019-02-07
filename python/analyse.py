from GCD import GCD

from Euclid import Euclid
from ExtEuclid import ExtEuclid
from SimpleStein import SimpleStein
from BitOpsStein import BitOpsStein
from IterativeStein import IterativeStein
from ExtendedStein import ExtendedStein

from Test import Test

from Verifier import Verifier
from GCDVerifier import GCDVerifier
from BezoutVerifier import BezoutVerifier

EuclidTest = Test(Euclid(), GCDVerifier(Euclid()), 100)
ExtEuclidTest = Test(ExtEuclid(), BezoutVerifier(ExtEuclid()), 100)
IterativeSteinTest = Test(IterativeStein(), GCDVerifier(IterativeStein()), 100)
SimpleSteinTest = Test(SimpleStein(), GCDVerifier(SimpleStein()), 100)
ExtendedSteinTest = Test(ExtendedStein(), BezoutVerifier(ExtEuclid()), 100)

for _ in range(10):
    ExtendedSteinTest.perform()

for _ in range(10):
    ExtEuclidTest.perform()

for _ in range(10):
    IterativeSteinTest.perform()

for _ in range(10):
    EuclidTest.perform()

# Recursion depth exceeded
#for _ in range(10):
#    SimpleSteinTest.perform()

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
