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

            Test euclidTest = new Test(euclid, new GCDVerifier(euclid), 100);
            Test extEuclidTest = new Test(extEuclid, new GCDVerifier(euclid), 100);
            for (int i = 0; i < 10; i++)
            {
                euclidTest.Perform(debug: true);
            }

            Console.ReadLine();
        }
    }
}
