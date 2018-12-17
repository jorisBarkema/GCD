import time
import random

class Test:
    def __init__(self, GCD, verifier, size):
        self.GCD = GCD
        self.verifier = verifier
        self.size = size
        self.values = []

        for _ in range(size):
            randoms = (random.randrange(1, 2 ** 2048), random.randrange(1, 2 ** 2048))
            self.values.append(randoms)
        
        self.results = []
        self.time = -1

    def perform(self):
        begin_time = time.time()

        for i in range(self.size):
            #TODO: maybe rework to compute((p, q), debug ) instead of compute(p, q, debug)
            self.results.append(self.GCD.compute(self.values[i][0], self.values[i][1]))
            #results.append(Stein.iterative(values[i][0], values[i][1]))

        end_time = time.time()

        # time the method took in milliseconds
        self.time = (end_time - begin_time) * 1000
        print(self.GCD.name + ": " + str(self.time) + " ms")

        self.verify()
    
    def verify(self):
        for i in range(len(self.values)):
            self.verifier.verify(self.values[i], self.results[i])
