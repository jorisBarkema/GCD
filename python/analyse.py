from GCD import GCD

from Euclid import Euclid
from ExtEuclid import ExtEuclid
#from SimpleStein import SimpleStein
#from BitOpsStein import BitOpsStein
from IterativeStein import IterativeStein
from ExtendedStein import ExtendedStein
from PrimeGCD import PrimeGCD

from Test import Test

from Verifier import Verifier
from GCDVerifier import GCDVerifier
from BezoutVerifier import BezoutVerifier

"""
EuclidTest = Test(Euclid(), GCDVerifier(Euclid()), 100, 1000)
ExtEuclidTest = Test(ExtEuclid(), BezoutVerifier(ExtEuclid()), 100, 1000)
IterativeSteinTest = Test(IterativeStein(), GCDVerifier(IterativeStein()), 100, 1000)
#SimpleSteinTest = Test(SimpleStein(), GCDVerifier(SimpleStein()), 100)
ExtendedSteinTest = Test(ExtendedStein(), BezoutVerifier(ExtEuclid()), 100, 1000)
PrimeGCDTest = Test(PrimeGCD(), GCDVerifier(PrimeGCD()), 100, 1000)
"""

"""
for t in range(1, 11):
    EuclidTest = Test(Euclid(), GCDVerifier(Euclid()), 100, t * 1000)
    print("Euclid, " + str(t * 1000) + " bits")
    for _ in range(10):
        EuclidTest.perform()

    IterativeSteinTest = Test(IterativeStein(), GCDVerifier(IterativeStein()), 100, t * 1000)
    print("Stein, " + str(t * 1000) + " bits")
    for _ in range(10):
        IterativeSteinTest.perform()
"""

EuclidTest = Test(Euclid(), GCDVerifier(Euclid()), 100, 1000)
print("Euclid, " + str(1000) + " bits")
for _ in range(1):
    EuclidTest.perform()

"""
IterativeSteinTest = Test(IterativeStein(), GCDVerifier(IterativeStein()), 100, 15000)
print("Stein, " + str(15000) + " bits")
for _ in range(10):
    IterativeSteinTest.perform()

EuclidTest = Test(Euclid(), GCDVerifier(Euclid()), 100, 20000)
print("Euclid, " + str(20 * 1000) + " bits")
for _ in range(10):
    EuclidTest.perform()

IterativeSteinTest = Test(IterativeStein(), GCDVerifier(IterativeStein()), 100, 20000)
print("Stein, " + str(20 * 1000) + " bits")
for _ in range(10):
    IterativeSteinTest.perform()

EuclidTest = Test(Euclid(), GCDVerifier(Euclid()), 100, 30000)
print("Euclid, " + str(30 * 1000) + " bits")
for _ in range(10):
    EuclidTest.perform()

IterativeSteinTest = Test(IterativeStein(), GCDVerifier(IterativeStein()), 100, 30000)
print("Stein, " + str(30 * 1000) + " bits")
for _ in range(10):
    IterativeSteinTest.perform()

"""
#print("Extended Stein")
#for _ in range(10):
#    ExtendedSteinTest.perform()

#print("Extended Euclid")
#for _ in range(10):
#    ExtEuclidTest.perform()

#print("Stein")
#for _ in range(10):
#    IterativeSteinTest.perform()

#print("Euclid")
#for _ in range(10):
#    EuclidTest.perform()

# Recursion depth exceeded
#for _ in range(10):
#    SimpleSteinTest.perform()

#print("Prime GCD")
#for _ in range(10):
#    PrimeGCDTest.perform()

"""
# importing the required module 
import timeit 
  
# code snippet to be executed only once 
mysetup = '''
import random
values = []

for i in range(1000):
    values.append((random.randrange(1, 2 ** 1000), random.randrange(1, 2 ** 1000)))
    if (values[i][0] < values[i][1]):
        values[i] = (values[i][1], values[i][0])
'''

# code snippet whose execution time is to be measured 
mycode = ''' 
for v in values: x = v[0] % v[1]
'''
  
# timeit statement
# tijd in seconden voor number keer mycode
print("results for 1000 bits")
for _ in range(10):
    print(timeit.timeit(setup = mysetup, 
                    stmt = mycode, 
                    number = 10000))

#https://www.geeksforgeeks.org/timeit-python-examples/
"""