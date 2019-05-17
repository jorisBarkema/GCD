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

        public void verify(BigInteger p, BigInteger q, BigInteger r)
        {
            verify(p, q, r, new BigInteger(0), new BigInteger(0));
        }

        public override void verify(BigInteger p, BigInteger q, BigInteger r, BigInteger s, BigInteger t)
        {
            if (r == 0 && p != 0 && q != 0)
            {
                Console.WriteLine("Result is 0 when it should not be.");
                Console.ReadLine();
                return;
            }

            BigInteger vres = this.GCD.compute(p, q)[0];
            if (vres != r)
            {
                Console.WriteLine("Result           : " + r);
                Console.WriteLine("Result of builtin: " + vres);
                Console.ReadLine();
            }
        }
    }
}
