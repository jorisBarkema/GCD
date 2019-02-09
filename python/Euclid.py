from GCD import GCD

class Euclid(GCD):
    def __init__(self):
        super(Euclid, self).__init__("Simple Euclid")
    
    def compute(self, p, q, debug = False):
        
        count = 0
        while(p != q):
            if (p == 0): return (q, count)
            if (q == 0): return (p, count)
            if (p > q): 
                p = p % q
                count += 1
            else: 
                q = q % p
                count += 1
        
        return (p, count)