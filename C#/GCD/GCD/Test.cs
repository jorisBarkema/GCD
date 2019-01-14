using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Test
    {
        private GCD GCD;
        private Verifier Verifier;
        private int size;
        private BigInteger[][] values;
        private BigInteger[][] results;

        public Test(GCD gcd, Verifier verifier, int size)
        {
            this.GCD = gcd;
            this.Verifier = verifier;
            this.size = size;

            this.NewValues();
        }

        public void Perform(bool newvalues = true, bool debug = false)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < this.size; i++)
            {
                this.results[i] = this.GCD.compute(this.values[i][0], this.values[i][1], debug);
            }

            stopwatch.Stop();

            long elapsedTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(this.GCD.Name + ": " + elapsedTime + " ms");

            this.Verify();
            if (newvalues) this.NewValues();
        }

        private void NewValues()
        {
            // set the results to 0
            this.results = new BigInteger[this.size][];
            this.values = new BigInteger[this.size][];

            Random random = new Random();
            // 256 bytes is 2048 bits
            byte[] bytes = new byte[256];

            for (int i = 0; i < this.values.Length; i++)
            {
                this.values[i] = new BigInteger[2];
                random.NextBytes(bytes);
                this.values[i][0] = new BigInteger(bytes);
                if (this.values[i][0] < 0) this.values[i][0] *= -1;
                random.NextBytes(bytes);
                this.values[i][1] = new BigInteger(bytes);
                if (this.values[i][1] < 0) this.values[i][1] *= -1;
            }
        }

        private void Verify()
        {
            for (int i = 0; i < this.values.Length; i++)
            {
                if (this.results[i].Length < 3) this.Verifier.verify(this.values[i][0], this.values[i][1], this.results[i][0], 0, 0);
                else { this.Verifier.verify(this.values[i][0], this.values[i][1], this.results[i][0], this.results[i][1], this.results[i][2]); }
            }
        }
    }
}
