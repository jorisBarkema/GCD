import time
import random

from Euclid import Euclid
from ExtEuclid import ExtEuclid
#from SimpleStein import SimpleStein
#from BitOpsStein import BitOpsStein
from IterativeStein import IterativeStein
from ExtendedStein import ExtendedStein

class Test:
    def __init__(self, GCD, verifier, size):
        self.GCD = GCD
        self.verifier = verifier
        self.size = size
        self.values = []
        self.newvalues()
        self.results = []
        self.time = -1

    def perform(self, newvalues = True):
        begin_time = time.time()

        for i in range(self.size):
            #TODO: maybe rework to compute((p, q), debug ) instead of compute(p, q, debug)
            self.results.append(self.GCD.compute(self.values[i][0], self.values[i][1]))
            #results.append(Stein.iterative(values[i][0], values[i][1]))

        end_time = time.time()

        # time the method took in milliseconds
        self.time = (end_time - begin_time) * 1000
        #print(self.GCD.name + ": " + str(self.time) + " ms")

        count = 0
        if type(self.GCD) is ExtendedStein or type(self.GCD) is ExtEuclid:
            for i in range(self.size):
                count += self.results[i][3]
        elif type(self.GCD) is Euclid or type(self.GCD) is IterativeStein:
            for i in range(self.size):
                count += self.results[i][1]
        
        count /= self.size

        print(self.GCD.name + ": " + str(self.time) + " ms\t\t" + str(count) + " steps")
        self.verify()
        if (newvalues): self.newvalues()
    
    def newvalues(self):
        self.values = []
        self.results = []
        for _ in range(self.size):
            randoms = (random.randrange(1, 2 ** 100), random.randrange(1, 2 ** 100))
            self.values.append(randoms)
    
    def verify(self):
        for i in range(len(self.values)):
            self.verifier.verify(self.values[i], self.results[i])
