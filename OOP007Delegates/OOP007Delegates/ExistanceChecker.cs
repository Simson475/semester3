using System;
using System.Linq;

namespace OOP007Delegates
{
    public static class ExistanceChecker
    {
        public static bool Exists<T>(Predicate<T> f, T[] a)
        {
            return a.Any(i => f(i));
        }
    }
}
