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

            for (int i = 0; i < 5; i++) builtInGCDTest.Perform();
            for (int i = 0; i < 5; i++) extSteinTest.Perform();
            //for (int i = 0; i < 3; i++) euclidTest.Perform();
            //for (int i = 0; i < 3; i++) extEuclidTest.Perform();
            for (int i = 0; i < 5; i++) steinTest.Perform();

            Console.WriteLine("\nfinished");
            Console.ReadLine();
        }
    }
}
