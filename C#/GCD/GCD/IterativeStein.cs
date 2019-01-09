using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class IterativeStein : GCD
    {
        public IterativeStein()
        {
            this.Name = "Iterative Stein";
        }

        public override BigInteger compute(BigInteger p, BigInteger q, bool debug = false)
        {
            int shift = 0;

            if (p == 0) return q;
            if (q == 0) return p;

            while(((p | q) & 1) == 0)
            {
                shift++;
                p >>= 1;
                q >>= 1;
            }

            while((p & 1) == 0)
            {
                p >>= 1;
            }

            while(q != 0)
            {
                while ((q & 1) == 0)
                {
                    q >>= 1;
                }

                if (p > q)
                {
                    BigInteger t = p;
                    p = q;
                    q = t;
                }

                q = (q - p) >> 1;
            }

            return p << shift;
        }
    }
}
