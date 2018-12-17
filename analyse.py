from GCD import GCD

from ExtEuclid import ExtEuclid
from SimpleStein import SimpleStein
from BitOpsStein import BitOpsStein
from IterativeStein import IterativeStein

from Test import Test

from Verifier import Verifier
from GCDVerifier import GCDVerifier
from BezoutVerifier import BezoutVerifier

ExtEuclidTest = Test(ExtEuclid(), BezoutVerifier(ExtEuclid()), 10)

for _ in range(10):
    ExtEuclidTest.perform()

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
