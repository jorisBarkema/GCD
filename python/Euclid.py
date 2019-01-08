from GCD import GCD

class Euclid(GCD):
    def __init__(self):
        super(Euclid, self).__init__("Simple Euclid")
    
    def compute(self, p, q, debug = False):
        
        while(p != q):
            if (p == 0): return q
            if (q == 0): return p
            if (p > q): p = p % q
            else: q = q % p
        
        return p