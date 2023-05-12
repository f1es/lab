using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films
{
    class Template <T> //where T : IComparable, IComparable<T>, IEquatable<T>
    {
        private T[] TArray;
        private int ArrayCount;
        public Template(int n)
        {
            TArray = new T[n];
        }

        public T[] GetArray()
        {
            return TArray;
        }
        public T GetFromIndex(int index)
        {
            return TArray[index];
        }

        public void SetFromIndex(int index, T element)
        {
            if (TArray.Length == 0)
            {
                Console.WriteLine("Array is empty");
                return;
            }
            if (CorrectInput.InRange(0, TArray.Length, index))
                TArray[index] = element;
            else
                Console.WriteLine("Wrong array index");
        }

        public int findItem(Template<T> template ,T obj)
        {
            return template == obj;
        }

        static public int operator == (Template<T> template, T secondElement)
        {
            for (int i = 0; i < template.TArray.Length; i++)
            {
                if (Object.Equals(template.TArray[i], secondElement)) 
                    return i;
            }
            return -1;
        }

        static public int operator !=(Template<T> template, T secondElement)
        {
            return -1;
        }
    }
}
