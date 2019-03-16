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
            Stein stein = new Stein();
            ExtStein extStein = new ExtStein();
            BuiltInGCD builtInGCD = new BuiltInGCD();

            // So far Euclid is fastest, so use that for the GCDVerifier.
            Test euclidTest = new Test(euclid, new GCDVerifier(euclid), 100);
            Test extEuclidTest = new Test(extEuclid, new BezoutVerifier(euclid), 100);
            Test steinTest = new Test(stein, new GCDVerifier(euclid), 100);
            Test extSteinTest = new Test(extStein, new BezoutVerifier(euclid), 100);
            Test builtInGCDTest = new Test(builtInGCD, new GCDVerifier(euclid), 100);

            //for (int i = 0; i < 20; i++) Console.WriteLine(Utils.CreateBigInteger(100));

            //Utils.PerformanceTest();
            /*
            for(int t = 25;t <= 30; t++)
            {
                euclidTest.BitSize = 1000 * t;
                extEuclidTest.BitSize = 1000 * t;
                steinTest.BitSize = 1000 * t;
                extSteinTest.BitSize = 1000 * t;
                builtInGCDTest.BitSize = 1000 * t;
                
                builtInGCDTest.PerformSeveral(10);
                extSteinTest.PerformSeveral(10);
                euclidTest.PerformSeveral(10);
                extEuclidTest.PerformSeveral(10);
                steinTest.PerformSeveral(10);
            }
            */

            int bitsize = 13;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(Utils.CreateBigInteger(bitsize));
            }

            Console.WriteLine("Math.Pow(2, "+ bitsize + "): " + Math.Pow(2, bitsize) + " 1 << 8 - 1: " + ((1 << bitsize) - 1));
            Console.WriteLine("\nfinished");
            Console.ReadLine();
        }
    }
}
