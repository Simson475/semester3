using System;
using System.Collections.Generic;

namespace OOP007Delegates
{
    public static class Tester
    {
        public static void DelegateStringJoinTest()
        {
            StringJoin stringJoiner = (l, r) => l + r;
            string helloDelegates = stringJoiner("hello ", "delegates");
            Console.WriteLine(helloDelegates);
        }
        public static void Join3Test()
        {
            Console.WriteLine(StringJoiner.Join3("a", "b", "c", (l, r) => l + r)); // abc
            Console.WriteLine(StringJoiner.Join3("a", "b", "c", (l, r) => l + "." + r)); // a.b.c
            Console.WriteLine(StringJoiner.Join3("a", "b", "c", (l, r) => l)); // a
        }
        public static void JoinAllString()
        {
            string saved = StringJoiner.JoinAllString(new List<string>() { "hello", "delegates" }, (l, r) => l + r);
            Console.WriteLine(saved);
        }
        public static void JoinGenericList()
        {
            string saved = Joiner.JoinAllGeneric(new List<string>() { "1", "2" }, (l, r) => l + r);
            Console.WriteLine(saved);
        }
        public static void ExistanceCheckerTest()
        {
            bool exists = ExistanceChecker.Exists(a => a == 5, new int[] { 1, 2, 3, 5 });
            Console.WriteLine(exists);
        }
    }
}
