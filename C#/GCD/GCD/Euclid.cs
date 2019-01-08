﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Euclid : GCD
    {
        public Euclid(string name)
        {
            this.Name = name;
        }

        public override BigInteger compute(BigInteger p, BigInteger q, bool debug = false)
        {
            while(p != q)
            {
                if (p == 0) return q;
                if (q == 0) return p;
                if (p > q) p = p % q;
                else { q = q % p; }
            }

            return p;
        }
    }
}
