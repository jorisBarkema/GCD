from Verifier import Verifier

class BezoutVerifier(Verifier):
    def __init__(self, GCD):
        super(BezoutVerifier, self).__init__(GCD)
    
    def verify(self, values, result):

        # s * p + t * q = gcd
        # values = (p, q), result = (gcd, s, t)
        if (len(result) != 3 | len(values) != 2): raise Exception("Wrong data format in Bezout Verifier")

        if not ((result[1] * values[0] + result[2] * values[1]) == result[0]):
            print("p:   " + str(values[0]))
            print("q:   " + str(values[1]))
            print("GCD: " + str(result[0]))
            print("S:   " + str(result[1]))
            print("T:   " + str(result[2]))
            print()
            print("s * p + t * q:" + str(result[1] * values[0] + result[2] * values[1]))
            print("gcd: " + str(result[0]))
            
            # run algorithm again with debug = True
            self.GCD.compute(values[0], values[1], True)
            raise Exception("GCD is not equal to the extended euclid test")