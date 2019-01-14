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
    }
}
