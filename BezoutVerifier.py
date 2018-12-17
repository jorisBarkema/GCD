from Verifier import Verifier

class BezoutVerifier(Verifier):
    def __init__(self):
        super(Author, self).__init__(values, results, GCD)
    
    def verify(self):
        results = self.results
        values = self.values

        for i in range(len(results)):
            # s * p + t * q = gcd
            # values = [(p, q)], results = [(gcd, s, t)]
            if (len(results[i]) != 3 | len(values[i]) != 2): raise Exception("Wrong data format in Bezout Verifier")

            if not ((results[i][1] * values[i][0] + results[i][2] * values[i][1]) == results[i][0]):
                print("p:   " + str(values[i][0]))
                print("q:   " + str(values[i][1]))
                print("GCD: " + str(results[i][0]))
                print("S:   " + str(results[i][1]))
                print("T:   " + str(results[i][2]))
                print()
                print("s * p + t * q:" + str(results[i][1] * values[i][0] + results[i][2] * values[i][1]))
                print("gcd: " + str(results[i][0]))
                
                # run algorithm again with debug = True
                self.GCD.compute(values[i][0], values[i][1], True)
                raise Exception("GCD is not equal to the extended euclid test")

        print("all values are correct.")