using System;
using System.Collections.Generic;

namespace SlipWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Int32.Parse(Console.ReadLine());
            int[] array = GetArray(Console.ReadLine());
            if (array.Length != n)
                throw new InvalidOperationException("Size missmatch");
            var m = Int32.Parse(Console.ReadLine());
            var maxims = new int[n - m + 1];
            var queue = new QueueMax<int>();
            for (int i = 0; i < m - 1; i++)
                queue.Enqueue(array[i]);
            for (int i = m - 1; i < n; i++)
            {
                queue.Enqueue(array[i]);
                maxims[i - m + 1] = queue.Max;
                queue.Dequeue();
            }
            foreach (var max in maxims)
                Console.Write("{0} ", max);
            //Console.ReadKey();


        }

        private static int[] GetArray(string v)
        {
            var numbers = v.Split(' ');
            var array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = Int32.Parse(numbers[i]);
            return array;
        }
    }

    class QueueMax<T> where T : IComparable<T>
    {
        StackMax<T> leftStack = new StackMax<T>();
        StackMax<T> rightStack = new StackMax<T>();
        public void Enqueue(T value)
        {
            leftStack.Push(value);
        }
        public T Dequeue()
        {
            if (!rightStack.Empty)
                return rightStack.Pop();
            else if (!leftStack.Empty)
            {
                this.MoveToRight();
                return rightStack.Pop();
            }
            else
                throw new InvalidOperationException("The stack is empty");
        }
        private void MoveToRight()
        {
            while (!leftStack.Empty)
                rightStack.Push(leftStack.Pop());
        }
        public T Peek()
        {
            if (!rightStack.Empty)
                return rightStack.Peek();
            else if (!leftStack.Empty)
            {
                this.MoveToRight();
                return rightStack.Peek();
            }
            else
                throw new InvalidOperationException("The stack is empty");
        }
        public int Count
        {
            get
            {
                return leftStack.Count + rightStack.Count;
            }
        }
        public bool Empty
        {
            get
            {
                return leftStack.Empty || rightStack.Empty;
            }
        }
        public T Max
        {
            get
            {
                if (!rightStack.Empty && !leftStack.Empty)
                    return GetMax(leftStack.Max, rightStack.Max);
                else if (!leftStack.Empty)
                    return leftStack.Max;
                else if (!rightStack.Empty)
                    return rightStack.Max;
                else
                    return default(T);
            }
        }
        private T GetMax(T max1, T max2)
        {
            if (max1.CompareTo(max2) > 0)
                return max1;
            else return max2;
        }
    }

    public class StackMax<T> where T : IComparable<T>
    {
        LinkedList<Container<T>> item = new LinkedList<Container<T>>();

        public void Push(T value)
        {
            item.AddLast(new Container<T>(value, Maximum(value)));
        }
        private T Maximum(T val)
        {
            if (!this.Empty && val.CompareTo(item.Last.Value.Maximum) < 0)
                return item.Last.Value.Maximum;
            else
                return val;
        }
        public T Pop()
        {
            if (this.Empty)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            T result = item.Last.Value.Item;
            item.RemoveLast();
            return result;
        }
        public T Peek()
        {
            if (this.Empty)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            return item.Last.Value.Item;
        }
        public int Count
        {
            get
            {
                return item.Count;
            }
        }
        public bool Empty
        {
            get
            {
                return item.Count == 0;
            }
        }
        private T max;
        public T Max
        {
            get
            {
                if (item.Count != 0)
                    return item.Last.Value.Maximum;
                else
                    return default(T);
            }
            set
            {
                if (item.Count != 0 || max.CompareTo(value) == 0)
                    max = value;
            }
        }
    }
    public struct Container<T> where T : IComparable<T>
    {
        private T item;
        private T maximum;
        public T Item
        {
            get { return item; }
            set { item = value; }
        }
        public T Maximum
        {
            get { return maximum; }
            set { maximum = value; }
        }
        public Container(T val1, T val2)
        {
            item = val1;
            maximum = val2;
        }
    }
}