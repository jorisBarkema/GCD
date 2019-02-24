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

        # remove common factors of 2
        #"""
        while (((p & 1) & (q & 1)) == 0):
            shift += 1
            p >>= 1
            q >>= 1
            #count += 1
        #"""
        """ zou sneller moeten zijn, maar lijkt langzamer te zijn
        while (((p & 1) & (q & 1)) == 0):
            if (((p & 2) & (q & 2)) == 2):
                shift += 1
                p >>= 1
                q >>= 1
                #count += 1
                #print("test 1")
                break
            if (((p & 4) & (q & 4)) == 4):
                shift += 2
                p >>= 2
                q >>= 2
                #count += 1
                #print("test 2")
                break
            if (((p & 8) & (q & 8)) == 8):
                shift += 3
                p >>= 3
                q >>= 3
                #count += 1
                #print("test 3")
                break
            if (((p & 16) & (q & 16)) == 16):
                shift += 4
                p >>= 4
                q >>= 4
                #count += 1
                #print("test 4")
                break
            if (((p & 32) & (q & 32)) == 32):
                shift += 5
                p >>= 5
                q >>= 5
                #count += 1
                #print("test 5")
                break
            if (((p & 64) & (q & 64)) == 64):
                shift += 6
                p >>= 6
                q >>= 6
                #count += 1
                #print("test 6")
                break
            if (((p & 128) & (q & 128)) == 128):
                shift += 7
                p >>= 7
                q >>= 7
                #count += 1
                #print("test 7")
                break
            if (((p & 256) & (q & 256)) == 256):
                shift += 8
                p >>= 8
                q >>= 8
                #count += 1
                #print("test 8")
                break
            
            shift += 8
            p >>= 8
            q >>= 8
            #count += 1
            #print("test end")
        """

        # make p odd
        """
        k = 0
        while ((p & (1 << k)) == 0):
            k += 1
        
        p >>= k
        #count += 1
        """

        while ((p & 1) == 0):
            p >>= 1
            #count += 1
        
        while (q != 0):
            # make q odd
            """
            k = 0
            while ((q & (1 << k)) == 0):
                k += 1
            
            q >>= k
            #count += 1
            """
            
            while ((q & 1) == 0):
                q >>= 1
                #count += 1
            
            # swap p and q to make sure p <= q
            if (p > q):
                p, q = q, p
            
            q = (q - p) >> 1
            # 2 stappen in de extended versie
            #count += 1
        
        return (p << shift, count)



        
