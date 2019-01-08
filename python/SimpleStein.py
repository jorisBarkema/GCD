from GCD import GCD

class SimpleStein(GCD):
    def __init__(self):
        super(SimpleStein, self).__init__("Simple Recursive Stein")
    
    # note: both recursive methods do not work on very large numbers because of the recursion limit. When this is changed, for some reason nothing happens.
    def compute(self, p, q, debug = False):

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