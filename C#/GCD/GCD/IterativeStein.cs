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

        public override BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false)
        {
            int shift = 0;

            if (p == 0) return new BigInteger[] { q };
            if (q == 0) return new BigInteger[] { p };
            
            while (p.IsEven && q.IsEven)
            {
                p >>= 1;
                q >>= 1;
                shift++;
            }

            while (p.IsEven) p >>= 1;

            while (!q.IsZero)
            {
                while (q.IsEven) q >>= 1;

                if (p > q)
                {
                    BigInteger swap = p;
                    p = q;
                    q = swap;
                }

                q = (q - p) >> 1;
            }

            return new BigInteger[] { p << shift };
        }
    }
}
