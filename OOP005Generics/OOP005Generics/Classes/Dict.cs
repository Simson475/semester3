using System.Collections.Generic;

namespace OOP005Generics
{
    class Dict<K, V>
    {
        private List<Pair<K, V>> Dictionary { get; } = new List<Pair<K, V>>();

        public void Put(K key, V value)
        {
            foreach (var item in Dictionary)
            {
                if (item.T1Property.Equals(key))
                {
                    Dictionary.Remove(item);
                    break;
                }
            }
            Dictionary.Add(new Pair<K, V>(key, value));
        }
        public V Get(K key)
        {
            foreach (var item in Dictionary)
            {
                if (item.T1Property.Equals(key)) return item.T2Property;
            }
            throw new KeyNotFoundException("No element with given key");
        }
    }
}
