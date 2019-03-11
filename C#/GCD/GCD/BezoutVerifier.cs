using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class BezoutVerifier : Verifier
    {
        public BezoutVerifier(GCD gcd)
        {
            this.GCD = gcd;
        }

        public override void verify(BigInteger p, BigInteger q, BigInteger r, BigInteger s, BigInteger t)
        {
            if (p * s + q * t != r)
            {
                this.GCD.compute(p, q, true);
                Console.WriteLine("Wrong result from the BezoutVerifier");
                Console.WriteLine("p: " + p);
                Console.WriteLine("q: " + q);
                Console.WriteLine("r: " + r);
                Console.WriteLine();
                Console.WriteLine("s: " + s);
                Console.WriteLine("t: " + t);
                Console.WriteLine("p * s + q * t: " + p * s + q * t);
                Console.ReadLine();
            }
        }
    }
}
