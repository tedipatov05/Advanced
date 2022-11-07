using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
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
            foreach(T item in collection)
            {
                yield return item;  
            }
        }

        public bool HasNext() => index < collection.Count-1;
        public bool Move()
        {
            if(HasNext())
            {
                index++;
                
            }
            return HasNext();
        }
        public void Print()
        {
            if(collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine($"{collection[index]}");
        }
        public void PrintAll() => Console.WriteLine(String.Join(" ",collection));

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
