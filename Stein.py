from GCD import GCD

class Stein(GCD):
    def __init__(self):
        return
    
    def simple(self, p, q, debug = False):

        #terminating cases
        if (p == q): return p
        if (p == 0): return q
        if (q == 0): return p
        
        if (p % 2 == 0):
            #p and q even
            if (q % 2 == 0): return self.simple(p // 2, q // 2) * 2
            #p even, q odd
            else: return self.simple(p // 2, q)
        
        #p odd, q even
        if (q % 2 == 0): return self.simple(p, q // 2)
        
        #both odd
        if (p > q): return self.simple((p - q) // 2, q)
        return self.simple(q, (q - p) // 2)

    def bitops(self, p, q, debug = False):

        #terminating cases
        if (p == q): return p
        if (p == 0): return q
        if (q == 0): return p
        
        if not (p & 1):
            #p and q even
            if not (q & 1): return self.bitops(p >> 1, q >> 1) << 1
            #p even, q odd
            else: return self.bitops(p >> 1, q)
        
        #p odd, q even
        if not (q & 1): return self.bitops(p, q >> 1)
        
        #both odd
        if (p > q): return self.bitops((p - q) >> 1, q)
        return self.bitops(q, (q - p) >> 1)



        
