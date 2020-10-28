namespace OOP005Generics
{
    class Pair<T1, T2>
    {
        public Pair(T1 t1Property, T2 t2Property)
        {
            T1Property = t1Property;
            T2Property = t2Property;
        }
        public T1 T1Property { get; }
        public T2 T2Property { get; }
        public Pair<T2, T1> Swap() => new Pair<T2, T1>(T2Property, T1Property);
        public Pair<C, T2> SetFst<C>(C NewFirstValue) => new Pair<C, T2>(NewFirstValue, T2Property);
        public Pair<T1, C> SetSnd<C>(C NewSecondValue) => new Pair<T1, C>(T1Property, NewSecondValue);


    }
}

