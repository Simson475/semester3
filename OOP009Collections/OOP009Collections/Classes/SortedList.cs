using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOP009Collections
{
    public class SortedList<T> : ICollection<T> where T : IComparable
    {
        private List<T> InternalList { get; set; } = new List<T>();
        public int Count { get; set; } = 0;
        public bool IsReadOnly { get; set; } = false;

        public void Add(T item)
        {
            InternalList.Add(item);
            InternalList.Sort();
        }
        public void Clear() => InternalList.Clear();
        public bool Contains(T item) => InternalList.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => InternalList.CopyTo(array, arrayIndex);
        public bool Remove(T item) => InternalList.Remove(item);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => InternalList.GetEnumerator();
        public T this[int i] { get => InternalList.ElementAt(i); }

        public List<T> GetElementsReversed()
        {
            List<T> reverseList = new List<T>();
            foreach (var item in InternalList)
            {
                reverseList.Add(item);
            }
            reverseList.Reverse();
            return reverseList;
        }

        public List<T> GetElements(Predicate<T> filter) => InternalList.FindAll(filter);
    }
}

