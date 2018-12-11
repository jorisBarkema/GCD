"""
static Tuple<BigInteger, BigInteger> ExtEuclides(BigInteger p, BigInteger q)
        {
            // Used https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm as reference
            BigInteger newR = q, oldR = p;
            BigInteger newS = 0, oldS = 1;
            BigInteger newT = 1, oldT = 0;
            
            BigInteger quotient;

            while(newR != 0)
            {
                quotient = oldR / newR;

                BigInteger temp = newR;
                newR = oldR - quotient * temp;
                oldR = temp;

                temp = newS;
                newS = oldS - quotient * temp;
                oldS = temp;

                temp = newT;
                newT = oldT - quotient * temp;
                oldT = temp;
            }

            return new Tuple<BigInteger, BigInteger>(oldS, oldT);
        }
        """

from GCD import GCD
import time

class ExtEuclid(GCD):
    def __init__(self):
        return
    
    def compute(self, p, q, debug = False):
        # Used https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm as reference

        old_r = p
        new_r = q

        old_s = 1
        new_s = 0

        old_t = 0
        new_t = 1

        if debug:
            i = 0
            print("iteration: " + str(i))

            print("old r: " + str(old_r))
            print("new r: " + str(new_r))

            print("old s: " + str(old_s))
            print("new s: " + str(new_s))

            print("old t: " + str(old_t))
            print("new t: " + str(new_t))

        while (new_r is not 0):
            quotient = old_r // new_r

            temp_r = new_r
            new_r = old_r - quotient * temp_r
            old_r = temp_r

            temp_s = new_s
            new_s = old_s - quotient * temp_s
            old_s = temp_s

            temp_t = new_t
            new_t = old_t - quotient * temp_t
            old_t = temp_t

            if debug:
                i += 1
                print("iteration: " + str(i))
                
                print("old r: " + str(old_r))
                print("new r: " + str(new_r))

                print("old s: " + str(old_s))
                print("new s: " + str(new_s))

                print("old t: " + str(old_t))
                print("new t: " + str(new_t))
        
        return (old_r, old_s, old_t)
        
