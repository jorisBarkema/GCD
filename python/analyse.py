from GCD import GCD

from Euclid import Euclid
from ExtEuclid import ExtEuclid
#from SimpleStein import SimpleStein
#from BitOpsStein import BitOpsStein
from IterativeStein import IterativeStein
from ExtendedStein import ExtendedStein

from Test import Test

from Verifier import Verifier
from GCDVerifier import GCDVerifier
from BezoutVerifier import BezoutVerifier

EuclidTest = Test(Euclid(), GCDVerifier(Euclid()), 100000)
ExtEuclidTest = Test(ExtEuclid(), BezoutVerifier(ExtEuclid()), 100000)
IterativeSteinTest = Test(IterativeStein(), GCDVerifier(IterativeStein()), 100)
#SimpleSteinTest = Test(SimpleStein(), GCDVerifier(SimpleStein()), 100)
ExtendedSteinTest = Test(ExtendedStein(), BezoutVerifier(ExtEuclid()), 100)
"""
#for _ in range(10):
#    ExtendedSteinTest.perform()

for _ in range(10):
    ExtEuclidTest.perform()

#for _ in range(10):
#    IterativeSteinTest.perform()

for _ in range(10):
    EuclidTest.perform()

# Recursion depth exceeded
#for _ in range(10):
#    SimpleSteinTest.perform()

"""

# importing the required module 
import timeit 
  
# code snippet to be executed only once 
mysetup = '''
import random
values = []

for i in range(1000):
    values.append((random.randrange(1, 2 ** 9000), random.randrange(1, 2 ** 9000)))
    if (values[i][0] < values[i][1]):
        values[i] = (values[i][1], values[i][0])
'''
  
# code snippet whose execution time is to be measured 
mycode = ''' 
for v in values: x = v[0] % v[1]
'''
  
# timeit statement
# tijd in seconden voor number keer mycode
for _ in range(10):
    print(timeit.timeit(setup = mysetup, 
                    stmt = mycode, 
                    number = 10000))


#https://www.geeksforgeeks.org/timeit-python-examples/
