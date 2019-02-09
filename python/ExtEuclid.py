from GCD import GCD

class ExtEuclid(GCD):
    def __init__(self):
        super(ExtEuclid, self).__init__("Extended Euclid")
    
    def compute(self, p, q, debug = False):
        # Used https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm as reference

        old_r = p
        new_r = q

        old_s = 1
        new_s = 0

        old_t = 0
        new_t = 1
        count = 0
        
        while (new_r is not 0):
            quotient = old_r // new_r

            old_r, new_r = new_r, old_r - quotient * new_r
            old_s, new_s = new_s, old_s - quotient * new_s
            old_t, new_t = new_t, old_t - quotient * new_t

            count += 1

        return (old_r, old_s, old_t, count)
        
