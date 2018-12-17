class Verifier:
    def __init__(self, values, results, GCD):
        self.values = values
        self.results = results
        self.GCD = GCD

    def verify(self):
        raise("Trying to use abstract superclass")