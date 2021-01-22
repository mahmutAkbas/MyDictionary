using System;
using System.Collections.Generic;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("denee", "deee");
            Console.WriteLine(pairs.Count);
            MyDictionary<string, string> myDictionary = new MyDictionary<string, string>();
            myDictionary.Add("d1", "deneme1");
            myDictionary.Add("d2", "deneme2");
            foreach (var item in myDictionary.Values)
            {
                Console.WriteLine(item);
            }
            myDictionary.Remove("d1");
            Console.WriteLine("--------------------------");
            foreach (var item in myDictionary.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------");
            myDictionary.Add("d1", "deneme1");
            myDictionary.Add("d3", "deneme3");
            myDictionary.Add("d4", "deneme4");
            myDictionary.Add("d5", "deneme5");

            myDictionary.Remove("d4");
            foreach (var item in myDictionary.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine(myDictionary.Count);

        }
    }
    class MyDictionary<K, V>
    {
        K[] keys;
        V[] values;
        K[] tempKeys;
        V[] tempValues;
        public MyDictionary()
        {
            keys = new K[0];
            values = new V[0];
        }
        public void Add(K key, V value)
        {
            if (SearchKey(key) != true)
            {
                tempKeys = keys;
                tempValues = values;
                keys = new K[keys.Length + 1];
                values = new V[values.Length + 1];
                for (int i = 0; i < tempKeys.Length; i++)
                {
                    keys[i] = tempKeys[i];
                    values[i] = tempValues[i];
                }
                keys[keys.Length - 1] = key;
                values[values.Length - 1] = value;
            }
        }
        public void Remove(K key)
        {

            if (SearchKey(key) == true)
            {
                tempKeys = keys;
                tempValues = values;
                keys = new K[keys.Length - 1];
                values = new V[values.Length - 1];
                int m = 0;
                for (int i = 0; i < tempKeys.Length; i++)
                {
                    if (tempKeys[i].ToString() != key.ToString())
                    {
                        keys[m] = tempKeys[i];
                        values[m] = tempValues[i];
                        m++;
                    }
                }
            }
        }
        public bool SearchKey(K key)
        {
            foreach (var item in keys)
            {
                if (item.ToString() == key.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public void Clear()
        {
            keys = new K[0];
            values = new V[0];
        }

        public int Count
        {
            get { return keys.Length; }
        }

        public V[] Values
        {
            get { return values; }
        }

        public K[] Keys
        {
            get { return keys; }
        }

    }
}