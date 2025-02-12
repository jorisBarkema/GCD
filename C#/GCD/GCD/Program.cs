﻿using System;
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
            Test euclidTest = new Test(euclid, new GCDVerifier(builtInGCD), 100);
            Test extEuclidTest = new Test(extEuclid, new BezoutVerifier(builtInGCD), 100);
            Test steinTest = new Test(stein, new GCDVerifier(builtInGCD), 100);
            Test extSteinTest = new Test(extStein, new BezoutVerifier(builtInGCD), 100);
            Test builtInGCDTest = new Test(builtInGCD, new GCDVerifier(builtInGCD), 100);

            //for (int i = 0; i < 20; i++) Console.WriteLine(Utils.CreateBigInteger(100));

            //Utils.CalculateFractions();

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
            
            for (int t = 11; t <= 30; t++)
            {
                euclidTest.BitSize = 1000 * t;
                steinTest.BitSize = 1000 * t;
                builtInGCDTest.BitSize = 1000 * t;

                builtInGCDTest.PerformSeveral(10);
                euclidTest.PerformSeveral(10);
                steinTest.PerformSeveral(10);
            }
            

            //Utils.PerformanceTest();
            
            builtInGCDTest.BitSize = 10000;
            builtInGCDTest.PerformSeveral(10);

            builtInGCDTest.BitSize = 20000;
            builtInGCDTest.PerformSeveral(10);

            builtInGCDTest.BitSize = 40000;
            builtInGCDTest.PerformSeveral(10);

            builtInGCDTest.BitSize = 80000;
            builtInGCDTest.PerformSeveral(10);

            builtInGCDTest.BitSize = 160000;
            builtInGCDTest.PerformSeveral(10);
            
            builtInGCDTest.BitSize = 320000;
            builtInGCDTest.PerformSeveral(10);

            builtInGCDTest.BitSize = 640000;
            builtInGCDTest.PerformSeveral(10);

            Console.WriteLine("\nfinished");
            Console.ReadLine();
        }
    }
}
