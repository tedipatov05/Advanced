using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int index;

        public ListyIterator(params T[] data)
        {
            collection = data.ToList();
            index = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in collection)
            {
                yield return item;
            }
        }

        public bool HasNext() => index < collection.Count - 1;
        public bool Move()
        {
            bool hasNext = HasNext();
            if (hasNext)
            {
                index++;

            }
            return hasNext;
        }
        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine($"{collection[index]}");
        }
        public void PrintAll() => Console.WriteLine(String.Join(" ", collection));

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
