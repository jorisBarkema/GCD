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
            ExtStein extStein = new ExtStein();
            BuiltInGCD builtInGCD = new BuiltInGCD();

            // So far Euclid is fastest, so use that for the GCDVerifier.
            Test euclidTest = new Test(euclid, new GCDVerifier(euclid), 100);
            Test extEuclidTest = new Test(extEuclid, new BezoutVerifier(euclid), 100);
            Test iterativeSteinTest = new Test(iterativeStein, new GCDVerifier(euclid), 100);
            Test recursiveSteinTest = new Test(recursiveStein, new GCDVerifier(euclid), 100);
            Test extSteinTest = new Test(extStein, new BezoutVerifier(euclid), 100);
            Test builtInGCDTest = new Test(builtInGCD, new GCDVerifier(euclid), 100);

            //for (int i = 0; i < 20; i++) Console.WriteLine(Utils.CreateBigInteger(100));

            //Utils.PerformanceTest();

            //for (int i = 0; i < 3; i++) builtInGCDTest.Perform();
            //for (int i = 0; i < 3; i++) extSteinTest.Perform();
            //for (int i = 0; i < 3; i++) euclidTest.Perform();
            //for (int i = 0; i < 3; i++) extEuclidTest.Perform();
            for (int i = 0; i < 10; i++) iterativeSteinTest.Perform();
            
            Console.ReadLine();
        }
    }
}
