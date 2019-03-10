using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class ExtStein : GCD
    {
        public ExtStein()
        {
            this.Name = "Extended Stein";
        }

        public override BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false)
        {
            int shift = 0;

            if (p == 0) return new BigInteger[] { q, 0, 1 };
            if (q == 0) return new BigInteger[] { p, 1, 0 };

            // zolang p en q beide even zijn
            // while (((p | q) & 1 << shift) == 0)
            while (((p & (1 << shift)) | (q & (1 << shift))) == 0)
            {
                shift += 1;
            }

            p >>= shift;
            q >>= shift;

            // pas na de gemeenschappelijke factoren van twee er uit halen dit doen zodat er minstens eentje oneven is
            BigInteger p0 = p, q0 = q;

            // sp * p0 + sq * q0 = p
            // tp * p0 + tq * q0 = q

            BigInteger sp = 1, sq = 0;
            BigInteger tp = 0, tq = 1;

            while ((p & 1) == 0)
            {
                // als sp en sq beide even zijn kunnen we die ook door twee delen

                /*
                 * de volgende gevallen zijn allemaal hetzelfde! laat ik er nu nog even in staan voor wanneer
                 * ik het bewijs ga opschrijven

                 * als sp oneven is en sq even
                 * p is even, dus p0 is even want sq even -> sq * q0 altijd even
                 * dan is q0 dus oneven want ze zijn niet allebei even
                 * dus sq + p0 blijft even en sp - q0 wordt even
                 * if(sp & 1 == 1) and (sq & 1 == 0):
                 *    sp -= q0
                 *    sq += p0
                 *
                 * als sp even is en sq oneven
                 * p is even, dus q0 is even want sp * p0 altijd even en sq is oneven dus moet met even verminigvuldigd worden
                 * dus sp - q0 blijft even en sq + p0 wordt even
                 * if(sp & 1 == 0) and (sq & 1 == 1):
                 *    sp -= q0
                 *    sq += p0
                 * anders als allebei oneven, terwijl p even is
                 * we hebben gemeenschappelijke factoren van 2 uit p0 en q0 gedeeld
                 * dus minstens 1 daarvan is oneven
                 * dus als oneven veelvouden van die 2 even zijn moeten ze allebei oneven zijn
                 * dus +/- maakt sp en sq even
                 * else:
                 *    sp -= q0
                 *    sq += p0
                 */

                // als een van de twee niet even is
                //if (!(((sp | sq) & 1) == 0))
                if (((sp & 1) | (sq & 1)) != 0)
                {
                    sp -= q0;
                    sq += p0;
                }
                p >>= 1;
                sp >>= 1;
                sq >>= 1;
            }

            while (q != 0)
            {
                while ((q & 1) == 0)
                {
                    if (((tp & 1) | (tq & 1)) != 0)
                    {
                        tp -= q0;
                        tq += p0;
                    }

                    q >>= 1;
                    tp >>= 1;
                    tq >>= 1;
                }

                if (p > q)
                {
                    BigInteger t = p;
                    p = q;
                    q = t;

                    t = sp;
                    sp = tp;
                    tp = t;

                    t = sq;
                    sq = tq;
                    tq = t;
                }

                q = q - p;
                tp = tp - sp;
                tq = tq - sq;
            }

            return new BigInteger[] { p << shift, sp, sq };
        }
    }
}
