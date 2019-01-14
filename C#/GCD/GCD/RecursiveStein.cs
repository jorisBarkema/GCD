using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class RecursiveStein : GCD
    {
        public RecursiveStein()
        {
            this.Name = "Recursive Stein";
        }

        public override BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false)
        {
            if (p == q) return new BigInteger[] { p };
            if (p == 0) return new BigInteger[] { q };
            if (q == 0) return new BigInteger[] { p };

            if (p % 2 == 0)
            {
                if (q % 2 == 0) return new BigInteger[] { compute(p / 2, q / 2)[0] * 2 };
                else { return compute(p / 2, q); }
            }

            if (q % 2 == 0) return compute(p, q / 2);

            if (p > q) return compute((p - q) / 2, q);

            return compute(q, (q - p) / 2);
        }
    }
}
