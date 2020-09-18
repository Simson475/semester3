using System;
using System.Linq;

public static class MaxSequenceFinder
{
    public static int MaxSequence(int[] arr)
    {
        int Max = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int[] Temp = new int[i - j + 1];
                Array.Copy(arr, j, Temp, 0, i - j + 1);
                Max = Math.Max(Max, Temp.Sum());
            }
        }
        return Max;
    }
}


//shitty slow recursive version
//public static class Kata
//{
//    public static int MaxSequence(int[] arr)
//    {
//        Console.WriteLine(arr.Length);
//        if (arr.Length == 0)
//        {
//            return 0;
//        }
//        else
//        {
//            int[] First = new int[arr.Length - 1];
//            int[] Last = new int[arr.Length - 1];
//            Array.Copy(arr, 0, First, 0, First.Length);
//            Array.Copy(arr, 1, Last, 0, First.Length);
//            return Math.Max(arr.Sum(), Math.Max(MaxSequence(First), MaxSequence(Last)));
//        }
//    }
//}