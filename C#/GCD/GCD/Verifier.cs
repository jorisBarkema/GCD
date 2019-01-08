using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    abstract class Verifier
    {
        protected GCD GCD;

        public abstract void verify(BigInteger p, BigInteger q, BigInteger r);
    }
}
