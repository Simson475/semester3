using System.Collections;
using System.Collections.Generic;

namespace OOP009Collections
{
    class Sequence : IEnumerable<int>
    {

        public Sequence()
        {
            Start = 0;
            MaxCount = null;
            Skips = new List<int>();
        }
        public Sequence(int start)
        {
            Start = start;
            MaxCount = null;
            Skips = new List<int>();
        }
        public Sequence(int start, int? maxCount)
        {
            Start = start;
            MaxCount = maxCount;
            Skips = new List<int>();
        }
        public Sequence(int start, int? maxCount, List<int> skips)
        {
            Start = start;
            MaxCount = maxCount;
            Skips = skips;
        }

        public int Start { get; set; }
        public int? MaxCount { get; set; }
        public List<int> Skips { get; set; }


        public IEnumerator<int> GetEnumerator() => new CustomCounter(Start, MaxCount, Skips);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}

