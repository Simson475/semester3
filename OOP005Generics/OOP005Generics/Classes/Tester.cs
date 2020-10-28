using System;
using System.Collections.Generic;

namespace OOP005Generics
{
    public static class Tester
    {
        public static void MaxMin()
        {
            Console.WriteLine("\n\nMax/Min Test:");

            //HandyMethods<int> HandyInt = new HandyMethods<int>();
            int Max = HandyMethods.Max(new List<int>() { 1, 0, 1, 2, 3 });
            int Min = HandyMethods.Min(new List<int>() { 1, 0, 1, 2, 3 });
            Console.WriteLine($"Max method: {Max}  Min Method: {Min}");
        }
        public static void Copy()
        {
            Console.WriteLine("\n\nCopy Test:");

            int[] FirstArray = new int[] { 1, 2, 3, 4, 5 };
            int[] SecondArray = new int[5];
            HandyMethods.Copy(FirstArray, SecondArray);
            Console.Write("Copied array: ");
            foreach (var item in SecondArray) Console.Write($"{item} ");
            Console.WriteLine();
        }
        public static void Shuffle()
        {
            Console.WriteLine("\n\nShuffle Test:");

            int[] ArrayToShuffle = new int[] { 1, 2, 3, 4, 5 };
            Console.Write("Pre shuffle array: ");
            Array.ForEach(ArrayToShuffle, print => Console.Write($"{print} "));
            HandyMethods.Shuffle(ArrayToShuffle);
            Console.Write("Shuffled array: ");
            Array.ForEach(ArrayToShuffle, print => Console.Write($"{print} "));
            Console.WriteLine();
        }
        public static void Pair()
        {
            Console.WriteLine("\n\nPair Test:");
            Pair<int, string> TestPair = new Pair<int, string>(1, "Kasper");
            Console.WriteLine($"OG version T1: {TestPair.T1Property} T2: {TestPair.T2Property}");
            Pair<string, int> SwappedPair = TestPair.Swap();
            Console.WriteLine($"Swapped version T1: {SwappedPair.T1Property} T2: {SwappedPair.T2Property}");
            Pair<bool, int> ChangedPair = SwappedPair.SetFst(true);
            Console.WriteLine($"Changed version T1: {ChangedPair.T1Property} T2: {ChangedPair.T2Property}");
        }
        public static void Dict()
        {
            Dict<int, string> IntStringDict = new Dict<int, string>();
            IntStringDict.Put(1, "One");
            IntStringDict.Put(2, "Two");
            IntStringDict.Put(3, "Three");
            IntStringDict.Put(4, "Four");
            IntStringDict.Put(5, "Five");
            string Value = IntStringDict.Get(4);
            Console.WriteLine($"\n\nDict test:\nShould say \"Four\": {Value}");
            IntStringDict.Put(4, "New Four");
            Value = IntStringDict.Get(4);
            Console.WriteLine($"Should say \"New Four\": {Value}");


        }
    }
}
