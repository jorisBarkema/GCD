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
    public class Utils
    {
        public static void PerformanceTest()
        {
            // Test method from
            // https://stackoverflow.com/questions/1047218/benchmarking-small-code-samples-in-c-can-this-implementation-be-improved
            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            for (int t = 1; t <= 10; t++)
            {
                Console.WriteLine("Times for " + 1000 * t + " with " + 500 * t + " bits");
                for (int k = 0; k < 10; k++)
                {
                    // setup and warm up
                    Tuple<BigInteger, BigInteger>[] testValues = new Tuple<BigInteger, BigInteger>[1000];
                    //BigInteger[] testValues = new BigInteger[1000];
                    for (int i = 0; i < testValues.Length; i++)
                    {
                        //testValues[i] = euclidTest.CreateBigInteger(1000 * t);
                        testValues[i] = Tuple.Create(Utils.CreateBigInteger(1000 * t), Utils.CreateBigInteger(500 * t));
                    }

                    BigInteger x = testValues[0].Item1 % testValues[0].Item2;
                    //BigInteger x = testValues[0] >> 1;
                    var watch = new Stopwatch();

                    // clean up
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    watch.Start();
                    for (int i = 0; i < 100; i++)
                    {
                        for (int j = 0; j < testValues.Length; j++)
                        {
                            x = testValues[j].Item1 % testValues[j].Item2;
                            //Console.WriteLine("tested " + i);
                        }
                    }
                    watch.Stop();
                    Console.WriteLine(" Time Elapsed {0} s", watch.Elapsed.TotalSeconds);
                }
            }
        }

        /// <summary>
        /// will round the bits number to multiple of 8.
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static BigInteger CreateBigInteger(int bits = 2048)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[bits / 8];

            provider.GetBytes(bytes);
            BigInteger b = new BigInteger(bytes);
            if (b < 0) b *= -1;
            if (b == 0) b = 1;
            return b;
        }
    }
}
