using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP007Delegates
{
    public static class Joiner
    {
        public static T JoinAllGeneric<T>(List<T> genericList, Func<T, T, T> functionToUse) => genericList.Aggregate(functionToUse);
    }
}
