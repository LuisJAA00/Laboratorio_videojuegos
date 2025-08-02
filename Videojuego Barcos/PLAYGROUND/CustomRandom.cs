using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    internal class CustomRandom
    {
        private static Random random = new Random();

        public CustomRandom()
        {
            random = new Random();
        }

        public CustomRandom(int seed)
        {
            random = new Random(seed);
        }

        public double NextDoubleWithAverage(double average, double range)
        {
            // Calculate the boundaries of the range
            double min = average - range / 2;
            double max = average + range / 2;

            // Generate a random number within the specified range
            return min + (max - min) * random.NextDouble();
        }


    }
}
