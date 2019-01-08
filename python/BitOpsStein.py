from GCD import GCD

class BitOpsStein(GCD):
    def __init__(self):
        super(BitOpsStein, self).__init__("Bitwise operators Recursive Stein")
    
    # note: both recursive methods do not work on very large numbers because of the recursion limit. When this is changed, for some reason nothing happens.
    #TODO: look into why bitwise is slower, implement iterative versions self.simple(q, (q - p) // 2)

    def compute(self, p, q, debug = False):

        #terminating cases
        if (p == q): return p
        if (p == 0): return q
        if (q == 0): return p
        
        if ((p & 1) == 0):
            #p and q even
            if ((q & 1) == 0): return self.bitops(p >> 1, q >> 1) << 1
            #p even, q odd
            else: return self.bitops(p >> 1, q)
        
        #p odd, q even
        if ((q & 1) == 0): return self.bitops(p, q >> 1)
        
        #both odd
        if (p > q): return self.bitops((p - q) >> 1, q)
        return self.bitops(q, (q - p) >> 1)



        
