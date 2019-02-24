from GCD import GCD

class Euclid(GCD):
    def __init__(self):
        super(Euclid, self).__init__("Simple Euclid")
    
    def compute(self, p, q, debug = False):
        
        count = 0
        fractions = {}

        while(p != q):
            if (p == 0): return (q, count, fractions)
            if (q == 0): return (p, count, fractions)
            if (p > q): 
                fractions[p // q] = fractions.get(p // q, 0) + 1
                #print("p       : " + str(p))
                #print("q       : " + str(q))
                #print("fraction: " + str(p // q))
                #count += 1
                p = p % q
            else: 
                q = q % p
                #count += 1
        
        return (p, count, fractions)