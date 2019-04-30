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
                int size1 = 10000;
                int size2 = 9900 + 10 * t;

                Console.WriteLine("Division of " + size1 + " with " + size2 + " bits");
                for (int k = 0; k < 10; k++)
                {
                    // setup and warm up
                    Tuple<BigInteger, BigInteger>[] testValues = new Tuple<BigInteger, BigInteger>[100];
                    for (int i = 0; i < testValues.Length; i++)
                    {
                        testValues[i] = Tuple.Create(Utils.CreateBigInteger(size1), Utils.CreateBigInteger(size2));
                    }

                    BigInteger x = testValues[0].Item1 / testValues[0].Item2;

                    var watch = new Stopwatch();

                    // clean up
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    watch.Start();
                    // do it 1.000 times for clock inaccuracies
                    for (int i = 0; i < 1000; i++)
                    {
                        for (int j = 0; j < testValues.Length; j++)
                        {
                            x = testValues[j].Item1 / testValues[j].Item2;
                            //Console.WriteLine("tested " + i);
                        }
                    }
                    watch.Stop();
                    Console.WriteLine(watch.ElapsedMilliseconds);
                }
            }
        }

        public static void CalculateFractions()
        {
            Euclid euc = new Euclid();
            Dictionary<BigInteger, int> dict = new Dictionary<BigInteger, int>();

            for (int i = 0; i < 100; i++)
            {
                Dictionary<BigInteger, int> r = euc.computeFractions(Utils.CreateBigInteger(10000), Utils.CreateBigInteger(10000));
                foreach(KeyValuePair<BigInteger, int> kvp in r)
                {
                    if (kvp.Key == null) continue;
                    if (dict.ContainsKey(kvp.Key))
                    {
                        dict[kvp.Key] += kvp.Value;
                    } else
                    {
                        dict.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            foreach (KeyValuePair<BigInteger, int> kvp in dict)
            {
                Console.WriteLine("{0};{1}", kvp.Key, kvp.Value);
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
            byte[] bytes = null;
            bool rest = false;

            if (bits % 8 == 0) bytes = new byte[bits / 8];
            else
            {
                bytes = new byte[bits / 8 + 1];
                rest = true;
            }

            provider.GetBytes(bytes);

            if (rest && bytes.Length > 0)
            {
                bytes[bytes.Length - 1] >>= (8 - (byte)(bits % 8));
            }

            BigInteger b = new BigInteger(bytes);
            if (b < 0) b *= -1;
            if (b == 0) b = 1;
            return b;
        }
    }
}
