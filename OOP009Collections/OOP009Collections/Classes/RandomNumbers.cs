using System.Collections;
using System.Collections.Generic;

namespace OOP009Collections
{
    public class RandomNumbers : IEnumerable<int>
    {
        public RandomNumbers(int seed, int min, int max)
        {
            Seed = seed;
            Min = min;
            Max = max;
        }

        public int Seed { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }

        public IEnumerator<int> GetEnumerator() => new RNGEnumerator(Seed, Min, Max);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

