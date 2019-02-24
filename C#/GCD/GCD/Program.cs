using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Euclid euclid = new Euclid();
            ExtEuclid extEuclid = new ExtEuclid();
            IterativeStein iterativeStein = new IterativeStein();
            RecursiveStein recursiveStein = new RecursiveStein();

            // So far Euclid is fastest, so use that for the GCDVerifier.
            Test euclidTest = new Test(euclid, new GCDVerifier(euclid), 100);
            Test extEuclidTest = new Test(extEuclid, new BezoutVerifier(euclid), 100);
            Test iterativeSteinTest = new Test(iterativeStein, new GCDVerifier(euclid), 100);
            Test recursiveSteinTest = new Test(recursiveStein, new GCDVerifier(euclid), 100);

            /*
            for (int i = 0; i < 10; i++) euclidTest.Perform();
            for (int i = 0; i < 10; i++) extEuclidTest.Perform();
            for (int i = 0; i < 10; i++) iterativeSteinTest.Perform();
            //for(int i = 0; i < 10; i++) recursiveSteinTest.Perform();
            */
            
            // Test method from
            // https://stackoverflow.com/questions/1047218/benchmarking-small-code-samples-in-c-can-this-implementation-be-improved
            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            for(int t = 1; t <= 10; t++)
            {
                Console.WriteLine("Times for " + 1000 * t + " bits");
                for (int k = 0; k < 10; k++)
                {
                    // setup and warm up
                    Tuple<BigInteger, BigInteger>[] testValues = new Tuple<BigInteger, BigInteger>[1000];
                    //BigInteger[] testValues = new BigInteger[1000];
                    for (int i = 0; i < testValues.Length; i++)
                    {
                        //testValues[i] = euclidTest.CreateBigInteger(1000 * t);
                        testValues[i] = Tuple.Create(euclidTest.CreateBigInteger(10000), euclidTest.CreateBigInteger(10));
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

            Console.ReadLine();
        }
    }
}
