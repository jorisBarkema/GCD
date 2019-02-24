from GCD import GCD

class ExtendedStein(GCD):
    def __init__(self):
        super(ExtendedStein, self).__init__("Extended Stein")
    
    def compute(self, p, q, debug = False):
        shift = 0
        count = 0
        # sp * p0 + sq * q0 = p
        # tp * p0 + tq * q0 = q
        sp = 1
        sq = 0

        tp = 0
        tq = 1

        # simple cases
        if (p == 0): return (q, 0, 1, 1)
        if (q == 0): return (p, 1, 0, 1)

        """
        while (((p & 1) & (q & 1)) == 0):
            shift += 1
            p >>= 1
            q >>= 1
            #count += 1
        """
        
        while (((p & (1 << shift)) | (q & (1 << shift))) == 0):
            shift += 1
        #while (((p | q) & (1 << shift)) == 0):
        #    shift += 1
        
        p >>= shift
        q >>= shift
        #count += 1

        # merk op pas na de gemeenschappelijke factoren van 2 dit doen zodat er minstens eentje oneven is
        # de shift maakt het toch wel goed op het einde
        p0 = p
        q0 = q

        # make sure p is odd
        while ((p & 1) == 0):
            # als de sp en sq allebei even zijn kunnen we die ook zo door twee delen
            if not (((sp | sq) & 1) == 0):
                sp -= q0
                sq += p0
            """
            # de volgende gevallen zijn allemaal hetzelfde! laat ik er nu nog even in staan voor wanneer
            # ik het bewijs ga opschrijven

            # als sp oneven is en sq even
            # p is even, dus p0 is even want sq even -> sq * q0 altijd even
            # dan is q0 dus oneven want ze zijn niet allebei even
            # dus sq + p0 blijft even en sp - q0 wordt even
            elif (sp & 1 == 1) and (sq & 1 == 0):
                sp -= q0
                sq += p0

            # als sp even is en sq oneven
            # p is even, dus q0 is even want sp * p0 altijd even en sq is oneven dus moet met even verminigvuldigd worden
            # dus sp - q0 blijft even en sq + p0 wordt even
            elif (sp & 1 == 0) and (sq & 1 == 1):
                sp -= q0
                sq += p0
            # anders als allebei oneven, terwijl p even is
            # we hebben gemeenschappelijke factoren van 2 uit p0 en q0 gedeeld
            # dus minstens 1 daarvan is oneven
            # dus als oneven veelvouden van die 2 even zijn moeten ze allebei oneven zijn
            # dus +/- maakt sp en sq even
            else:
                sp -= q0
                sq += p0
            """
            sp >>= 1
            sq >>= 1

            p >>= 1
            #count += 1
        
        while (q != 0):
            # make q odd
            # en doe hetzelfde met tp en tq wat boven met sp en sq gedaan werd
            # zelfde redenaties
            while ((q & 1) == 0):
                
                if not (((tp | tq) & 1) == 0):
                    tp -= q0
                    tq += p0
                
                tp >>= 1
                tq >>= 1

                q >>= 1
                #count += 1
            
            # swap p and q to make sure p <= q
            if (p > q):
                p, q = q, p
                # swap ook de s en t waardes
                sp, tp = tp, sp
                sq, tq = tq, sq
            
            q = (q - p)
            tp = tp - sp
            tq = tq - sq
            #count += 1
        
        return (p << shift, sp, sq, count)



        
