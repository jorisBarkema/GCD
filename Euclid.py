from GCD import GCD

class Euclid(GCD):
    def __init__(self):
        super(Euclid, self).__init__("Extended Euclid")
    
    def compute(self, p, q, debug = False):
        """
        if (a==0) return b;
        if (b==0) return a;
        while (a!=b)
        if (a>b)
            a-=b;
        else
            b-=a;
        return a;
        """
        if (p == 0): return p
        if (q == 0): return q

        while(p != q):
            if (p == 0): return q
            if (q == 0): return p
            if (p > q): p = p % q
            else: q = q % p
        
        return p