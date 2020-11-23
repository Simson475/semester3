using System;

namespace OOP007Delegates
{
    public static class Twicer
    {
        public static T Twice<T>(Func<T, T> funcToDoTwice, T v)
        {
            return funcToDoTwice(funcToDoTwice(v));
        }
    }
}
