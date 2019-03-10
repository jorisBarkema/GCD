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

            // zolang p en q beide even zijn
            // while (((p | q) & 1 << shift) == 0)
            //while (((p & (1 << shift)) | (q & (1 << shift))) == 0)
            //{
            //    shift += 1;
            //}

            //p >>= shift;
            //q >>= shift;

            while (p.IsEven && q.IsEven)
            {
                p >>= 1;
                q >>= 1;
                shift++;
            }

            /*
            int temp = 0;

            while((p & (1 << temp)) == 0)
            {
                temp++;
            }

            p >>= temp;
            */
            while (p.IsEven)
            {
                p >>= 1;
            }
            while (q != 0)
            {
                //temp = 0;

                //while ((q & (1 << temp)) == 0)
                //{
                //    temp++;
                //

                //q >>= temp;
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
