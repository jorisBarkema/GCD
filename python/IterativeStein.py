from GCD import GCD

class IterativeStein(GCD):
    def __init__(self):
        super(IterativeStein, self).__init__("Iterative Stein")
    
    def compute(self, p, q, debug = False):
        shift = 0
        count = 0

        # simple cases
        if (p == 0): return (q, 1)
        if (q == 0): return (p, 1)

        """
        # remove common factors of 2
        while (((p | q) & 1) == 0):
            shift += 1
            p >>= 1
            q >>= 1
            count += 1
        """
        while (((p | q) & (1 << shift)) == 0):
            shift += 1
        
        p >>= shift
        q >>= shift
        count += 1


        # make p odd
        while ((p & 1) == 0):
            p >>= 1
            count += 1
        
        while (q != 0):
            # make q odd
            while ((q & 1) == 0):
                q >>= 1
                count += 1
            
            # swap p and q to make sure p <= q
            if (p > q):
                p, q = q, p
            
            q = (q - p) >> 1
            # 2 in de extended versie
            count += 1
        
        return (p << shift, count)



        
