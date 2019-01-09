using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class GCDVerifier : Verifier
    {
        public GCDVerifier(GCD gcd)
        {
            this.GCD = gcd;
        }

        public override void verify(BigInteger p, BigInteger q, BigInteger r)
        {
            if (r == 0)
            {
                Console.WriteLine("Result is 0.");
                return;
            }

            BigInteger vres = this.GCD.compute(p / r, q / r);
            if (vres != 1)
            {
                Console.WriteLine("Result               : " + r);
                Console.WriteLine("Result of p/r and q/r: " + vres);
            }
        }
    }
}
