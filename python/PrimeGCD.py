from GCD import GCD
import numpy as np

class PrimeGCD(GCD):
    def __init__(self):
        super(PrimeGCD, self).__init__("Prime GCD")
    
    def compute(self, p, q, debug = False):
        primes = [3, 5, 7, 11]
        multipliers = [0, 0, 0, 0]

        shift = 0
        # remove common factors of 2
        #"""
        while (((p | q) & (1 << shift)) == 0):
            shift += 1
        
        p >>= shift
        q >>= shift
        
        for i in range(len(primes)):
            while (p % primes[i] == 0 and q % primes[i] == 0):
                multipliers[i] += 1
                p //= primes[i]
                q //= primes[i]

        count = 0
        while(p != q):
            if (p == 0): return (q, count)
            if (q == 0): return (p, count)
            if (p > q): 
                p = p % q
                #count += 1
            else: 
                q = q % p
                #count += 1
        
        for m in multipliers:
            p *= m
        
        return (p << shift, count)