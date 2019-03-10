using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class BuiltInGCD : GCD
    {
        public BuiltInGCD()
        {
            this.Name = "BigInteger built-in GCD method";
        }

        public override BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false)
        {
            return new BigInteger[] { BigInteger.GreatestCommonDivisor(p, q) };
        }
    }
}
