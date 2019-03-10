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
            this.Name = "Iterative Stein";
        }

        public override BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false)
        {
            int shift = 0;
            BigInteger sp = 1, sq = 0;
            BigInteger tp = 0, tq = 1;

            if (p == 0) return new BigInteger[] { q, 0, 1 };
            if (q == 0) return new BigInteger[] { p, 1, 0 };

            while (((p | q) & 1 << shift) == 0)
            {
                shift += 1;
            }

            p >>= shift;
            q >>= shift;

            BigInteger p0 = p, q0 = q;

            while ((p & 1) == 0)
            {
                if (!(((sp | sq) & 1) == 0))
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
                    if (!(((tp | tq) & 1) == 0))
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

                q = (q - p);
                tp = tp - sp;
                tq = tq - sq;
            }

            return new BigInteger[] { p << shift, sp, sq };
        }
    }
}
