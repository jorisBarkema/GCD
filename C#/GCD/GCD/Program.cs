using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Test euclidTest = new Test(euclid, new GCDVerifier(euclid), 10000);
            Test extEuclidTest = new Test(extEuclid, new BezoutVerifier(euclid), 10000);
            Test iterativeSteinTest = new Test(iterativeStein, new GCDVerifier(euclid), 1000);
            Test recursiveSteinTest = new Test(recursiveStein, new GCDVerifier(euclid), 1000);

            //for (int i = 0; i < 10; i++) euclidTest.Perform();
            for (int i = 0; i < 10; i++) extEuclidTest.Perform();
            //for (int i = 0; i < 10; i++) iterativeSteinTest.Perform();
            //for(int i = 0; i < 10; i++) recursiveSteinTest.Perform();

            Console.ReadLine();
        }
    }
}
