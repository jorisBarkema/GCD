using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Test
    {
        private GCD GCD;
        private Verifier Verifier;
        private int size;
        private BigInteger[][] values;
        private BigInteger[] results;
        private double time = -1;

        public Test(GCD gcd, Verifier verifier, int size)
        {
            this.GCD = gcd;
            this.Verifier = verifier;
            this.size = size;

            this.NewValues();
        }

        private void NewValues()
        {
            // set the results to 0
            this.results = new BigInteger[this.size];
            this.values = new BigInteger[this.size][];

            Random random = new Random();
            // 256 bytes is 2048 bits
            byte[] bytes = new byte[256];

            for (int i = 0; i < this.values.Length; i++)
            {
                this.values[i] = new BigInteger[2];
                random.NextBytes(bytes);
                this.values[i][0] = new BigInteger(bytes);
                if (this.values[i][0] < 0) this.values[i][0] *= -1;
                random.NextBytes(bytes);
                this.values[i][1] = new BigInteger(bytes);
                if (this.values[i][1] < 0) this.values[i][1] *= -1;
            }
        }

        private void Verify()
        {
            for(int i = 0; i <  this.values.Length; i++)
            {
                this.Verifier.verify(this.values[i][0], this.values[i][1], this.results[i]);
            }
        }
        /*
        public static BigInteger RandomInRange(BigInteger min, BigInteger max)
        {
            if (min > max)
            {
                var buff = min;
                min = max;
                max = buff;
            }

            // offset to set min = 0
            BigInteger offset = -min;
            min = 0;
            max += offset;

            var value = randomInRangeFromZeroToPositive(max) - offset;
            return value;
        }

        private static BigInteger randomInRangeFromZeroToPositive(BigInteger max)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            BigInteger value;
            var bytes = max.ToByteArray();

            // count how many bits of the most significant byte are 0
            // NOTE: sign bit is always 0 because `max` must always be positive
            byte zeroBitsMask = 0b00000000;

            var mostSignificantByte = bytes[bytes.Length - 1];

            // we try to set to 0 as many bits as there are in the most significant byte, starting from the left (most significant bits first)
            // NOTE: `i` starts from 7 because the sign bit is always 0
            for (var i = 7; i >= 0; i--)
            {
                // we keep iterating until we find the most significant non-0 bit
                if ((mostSignificantByte & (0b1 << i)) != 0)
                {
                    var zeroBits = 7 - i;
                    zeroBitsMask = (byte)(0b11111111 >> zeroBits);
                    break;
                }
            }

            do
            {
                rng.GetBytes(bytes);

                // set most significant bits to 0 (because `value > max` if any of these bits is 1)
                bytes[bytes.Length - 1] &= zeroBitsMask;

                value = new BigInteger(bytes);

                // `value > max` 50% of the times, in which case the fastest way to keep the distribution uniform is to try again
            } while (value > max);

            return value;
        }
        */
    }
}
