using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class ExtEuclid : GCD
    {
        public ExtEuclid()
        {
            this.Name = "Extended Euclid";
        }
        
        public override BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false)
        {
            BigInteger oldR = p, newR = q,
                       oldS = 1, newS = 0,
                       oldT = 0, newT = 1;

            while (newR != 0)
            {
                BigInteger quotient = oldR / newR;

                BigInteger temp = newR;
                newR = oldR - quotient * temp;
                oldR = temp;

                temp = newS;
                newS = oldS - quotient * temp;
                oldS = temp;

                temp = newT;
                newT = oldT - quotient * temp;
                oldT = temp;
            }

            // Bezout coefficients oldS and oldT
            return new BigInteger[] { oldR, oldS, oldT } ;
        }
    }
}
