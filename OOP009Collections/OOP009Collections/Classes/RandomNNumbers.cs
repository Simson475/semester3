using System.Collections.Generic;

namespace OOP009Collections
{
    public class RandomNNumbers
    {
        public RandomNNumbers(int n, int seed, int min, int max)
        {
            NumberGenerator = new RandomNumbers(seed, min, max);
            NumbersAmount = n;
        }

        public RandomNumbers NumberGenerator { get; set; }
        public int NumbersAmount { get; set; }

        public List<int> GetNumbers()
        {
            IEnumerator<int> enumerator = NumberGenerator.GetEnumerator();
            List<int> numberList = new List<int>();
            for (int i = 0; i < NumbersAmount; i++)
            {
                enumerator.MoveNext();
                numberList.Add(enumerator.Current);
            }
            return numberList;
        }
    }
}

