using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GCD
{
    abstract class GCD
    {
        public string Name { get; protected set; }

        public abstract BigInteger[] compute(BigInteger p, BigInteger q, bool debug = false);
    }
}
