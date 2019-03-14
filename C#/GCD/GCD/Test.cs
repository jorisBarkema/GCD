using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
        private int bitSize;

        public int BitSize
        {
            set
            {
                this.bitSize = value;
            }
        }

        public Test(GCD gcd, Verifier verifier, int size, int bitSize = 10000)
        {
            this.GCD = gcd;
            this.Verifier = verifier;
            this.size = size;
            this.bitSize = 10000;
            this.NewValues();
        }

        public void PerformSeveral(int times, bool newvalues = true, bool debug = false)
        {
            this.Perform(true, newvalues, debug);
            Console.WriteLine(this.GCD.Name + ", " + this.bitSize + " bits (ms)");
            for (int i = 0; i < times; i++) this.Perform(false, newvalues, debug);
            Console.WriteLine();
        }

        public void Perform(bool warmup = false, bool newvalues = true, bool debug = false)
        {
            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            Stopwatch stopwatch = new Stopwatch();

            // warm up
            this.results[0] = this.GCD.compute(this.values[0][0], this.values[0][1], false);

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            stopwatch.Start();

            for (int i = 0; i < this.size; i++)
            {
                this.results[i] = this.GCD.compute(this.values[i][0], this.values[i][1], debug);
            }

            stopwatch.Stop();

            long elapsedTime = stopwatch.ElapsedMilliseconds;
            if (!warmup) Console.WriteLine(elapsedTime);

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
            //byte[] bytes = new byte[256];

            for (int i = 0; i < this.values.Length; i++)
            {
                this.values[i] = new BigInteger[2];
                this.values[i][0] = Utils.CreateBigInteger(this.bitSize);
                this.values[i][1] = Utils.CreateBigInteger(this.bitSize);
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
