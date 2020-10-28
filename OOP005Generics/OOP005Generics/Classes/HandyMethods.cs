using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP005Generics
{
    public static class HandyMethods
    {
        public static T Max<T>(List<T> listToSort) where T : IComparable<T> => listToSort.Max() ?? throw new ArgumentNullException(nameof(listToSort));
        public static T Min<T>(List<T> listToSort) where T : IComparable<T> => listToSort.Min() ?? throw new ArgumentNullException(nameof(listToSort));
        public static void Copy<T>(T[] FullArray, T[] EmptyArray)
        {
            if (FullArray.Length != EmptyArray.Length) throw new ArgumentException("Arrays must be same length");
            Array.Copy(FullArray, EmptyArray, FullArray.Length);
        }

        public static void Shuffle<T>(T[] ArrayToShuffle)
        {
            Random RNG = new Random();
            int Length = ArrayToShuffle.Length;
            for (int i = 0; i < Length; i++)
            {
                int NumberOne = RNG.Next(0, Length - 1);
                int NumberTwo = RNG.Next(0, Length - 1);
                T TempSave = ArrayToShuffle[NumberOne];
                ArrayToShuffle[NumberOne] = ArrayToShuffle[NumberTwo];
                ArrayToShuffle[NumberTwo] = TempSave;
            }
        }

        //Sorter where you can inject a comparefunc. returns the first memeber of the array
        //private T Sorter(Func<T, T, int> compareFunc, List<T> listToSort)
        //{
        //    if (listToSort is null) throw new ArgumentNullException(nameof(listToSort));
        //    listToSort.Sort((x, y) => (compareFunc(x, y)));
        //    return listToSort[0];
        //}
    }
}
