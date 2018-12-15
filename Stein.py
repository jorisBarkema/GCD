from GCD import GCD

class Stein(GCD):
    def __init__(self):
        return
    
    # note: both recursive methods do not work on very large numbers because of the recursion limit. When this is changed, for some reason nothing happens.
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

    def iterative(self, p, q, debug = False):
        shift = 0

        # simple cases
        if (p == 0): return q
        if (q == 0): return p

        # remove common factors of 2
        while (((p | q) & 1) == 0):
            shift += 1
            p >>= 1
            q >>= 1
        
        # make p odd
        while ((p & 1) == 0):
            p >>= 1
        
        while (q != 0):
            # make q odd
            while ((q & 1) == 0):
                q >>= 1
            
            # swap p and q to make sure p <= q
            if (p > q):
                p, q = q, p
            
            q = (q - p) >> 1
        
        return p << shift
        """
        /* From here on, u is always odd. */
        do {
            /* remove all factors of 2 in v -- they are not common */
            /*   note: v is not zero, so while will terminate */
            while ((v & 1) == 0)  /* Loop X */
                v >>= 1;

            /* Now u and v are both odd. Swap if necessary so u <= v,
                then set v = v - u (which is even). For bignums, the
                swapping is just pointer movement, and the subtraction
                can be done in-place. */
            if (u > v) {
                unsigned int t = v; v = u; u = t; // Swap u and v.
            }
            
            v = v - u; // Here v >= u.
            } while (v != 0);

        /* restore common factors of 2 */
        return u << shift;
        """
    #TODO: look into why bitwise is slower, implement iterative versions



        
