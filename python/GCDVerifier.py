from Verifier import Verifier

class GCDVerifier(Verifier):
    def __init__(self, GCD):
        super(GCDVerifier, self).__init__(GCD)
    
    def verify(self, values, result):

        # values = (p, q), result = gcd
        if (len(values) != 2): raise Exception("Wrong data format in GCD Verifier")
        gcd = result[0]
        #divide both by GCD, if gcd result of those two is not 1 there is another common factor wich means the gcd is not the greatest common divisor
        if not (self.GCD.compute(values[0] // gcd, values[1] // gcd)[0] == 1):
            print("p / gcd: " + str(values[0] // gcd))
            print("q / gcd: " + str(values[1] // gcd))
            print("gcd of those two: " + str(self.GCD.compute(values[0] // gcd, values[1] // gcd)))
            print()
            self.GCD.compute(values[0], values[1], True)
            raise Exception("GCD is not equal to the GCD test")