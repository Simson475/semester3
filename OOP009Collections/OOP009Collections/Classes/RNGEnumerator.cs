using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP009Collections
{
    public class RNGEnumerator : IEnumerator<int>
    {
        public RNGEnumerator(int seed, int min, int max)
        {
            RNG = new Random(seed);
            Min = min;
            Max = max;
        }

        public Random RNG { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int Current { get; set; }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            Current = RNG.Next(Min, Max);
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

