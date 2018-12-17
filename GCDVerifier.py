from Verifier import Verifier

class GCDVerifier(Verifier):
    def __init__(self):
        super(Author, self).__init__(values, results, GCD)
    
    def verify(self):
        results = self.results
        values = self.values

        # values = [(p, q)], results = [gcd]
            if (len(values[i]) != 2): raise Exception("Wrong data format in GCD Verifier")
        
        for i in range(len(results)):

            #divide both by GCD, if gcd result of those two is not 1 there is another common factor wich means the gcd is not the greatest common divisor
            if not (Stein.bitops(values[i][0] // results[i], values[i][1] // results[i]) == 1):
                print("p / gcd: " + str(values[i][0] // results[i]))
                print("q / gcd: " + str(values[i][1] // results[i]))
                print("gcd of those two: " + str(Stein.bitops(values[i][0] // results[i], values[i][1] // results[i])))
                print()
                self.GCD.compute(values[i][0], values[i][1], True)
                raise Exception("GCD is not equal to the bitops stein test")

        print("all values (of the last test) are correct.")