from Verifier import Verifier

class GCDVerifier(Verifier):
    def __init__(self, GCD):
        super(GCDVerifier, self).__init__(GCD)
    
    def verify(self, values, result):

        # values = (p, q), result = gcd
        if (len(values) != 2): raise Exception("Wrong data format in GCD Verifier")
        
        #divide both by GCD, if gcd result of those two is not 1 there is another common factor wich means the gcd is not the greatest common divisor
        if not (self.GCD.compute(values[0] // result, values[1] // result) == 1):
            print("p / gcd: " + str(values[0] // result))
            print("q / gcd: " + str(values[1] // result))
            print("gcd of those two: " + str(self.GCD.compute(values[0] // result, values[1] // result)))
            print()
            self.GCD.compute(values[0], values[1], True)
            raise Exception("GCD is not equal to the bitops stein test")