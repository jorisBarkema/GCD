using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Euclid : GCD
    {
        public Euclid()
        {
            this.Name = "Simple Euclid";
        }

        public override BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false)
        {
            while (p != q)
            {
                if (p == 0) return new BigInteger[] { q };
                if (q == 0) return new BigInteger[] { p };
                if (p > q) p = p % q;
                else { q = q % p; }
            }

            return new BigInteger[] { p };
        }

        public Dictionary<BigInteger, int> computeFractions(BigInteger p, BigInteger q, bool debug = false)
        {
            Dictionary<BigInteger, int> dict = new Dictionary<BigInteger, int>();

            while (p != q)
            {
                if (p == 0) return dict;
                if (q == 0) return dict;
                if (p > q)
                {
                    p = p % q;
                    dict[p / q] += 1;
                }
                else
                {
                    q = q % p;
                    dict[q / p] += 1;
                }
            }

            return dict;
        }

    }
}
