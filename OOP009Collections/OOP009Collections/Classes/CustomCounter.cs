using System.Collections;
using System.Collections.Generic;

namespace OOP009Collections
{
    class CustomCounter : IEnumerator<int>

    {
        public CustomCounter(int start, int? count, List<int> skips)
        {
            Current = start - 1;
            MaxCount = count;
            Skips = skips;
        }
        public int Current { get; set; }
        public int? MaxCount { get; set; }
        public int CurrentCount { get; set; } = 0;
        public List<int> Skips { get; set; }
        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {

            Current++;
            while (Skips.Contains(Current)) Current++;
            CurrentCount++;
            if (CurrentCount > MaxCount && MaxCount != null) return false;
            return true;
        }

        public void Reset()
        {
            Current = 0;
        }
    }
}

