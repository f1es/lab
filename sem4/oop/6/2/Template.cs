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
        private int ArrayLength;
        public Template(int n)
        {
            TArray = new T[n];
            ArrayLength = n;
        }

        public T[] GetArray()
        {
            return TArray;
        }
        public T GetFromIndex(int index)
        {
            return TArray[index];
        }

        public void SetToIndex(int index, T element)
        {
            if (TArray.Length == 0)
            {
                Console.WriteLine("Array is empty");
                return;
            }
            if (CorrectInput.InRange(0, TArray.Length, index))
                TArray[index] = element;
            else
                Console.WriteLine("Index was outside of array");
        }

        public int findItem(Template<T> template ,T obj)
        {
            return template == obj;
        }
        
        public void Sort()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            TArray = list.ToArray();
            //list.Reverse();
        }

        public T max()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            return list[0];
        }

        public T min()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            return list[list.Count];
        }

        static public int operator == (Template<T> template, T secondElement)
        {
            for (int i = 0; i < template.ArrayLength; i++)
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
