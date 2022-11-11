using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using SimpleAlgorithmsApp;
using SimpleAlgorithmsQueue;

public class Node<T>
{
    public Node(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public Node<T> Next { get; set; }
}

namespace SimpleAlgorithmsApp
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class NodeStack<T> : IEnumerable<T>
    {
        Node<T> head;
        int count;
        public bool IsEmpty
        {
            get { return count == 0; }

        }
        public int Count
        {
            get { return count; }
        }
        public void Push(T item)
        {
            // ����������� ����
            Node<T> node = new Node<T>(item);
            node.Next = head; // ����������������� �������� ������� ����� �������
            head = node;
            count++;
        }
        public T Pop()
        {
            // ���� ���� ����, ����������� ����������
            if (IsEmpty)
                throw new InvalidOperationException("���� ����");
            Node<T> temp = head;
            head = head.Next; // ����������������� �������� ������� ��������� �������
            count--;
            return temp.Data;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("���� ����");
            return head.Data;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

namespace SimpleAlgorithmsQueue
{
    public class QUEUE<T> : IEnumerable<T>
    {
        Node<T> head; // ��������/������ �������
        Node<T> tail; // ���������/��������� �������
        int count;
        // ���������� � �������
        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;

        }
        // �������� �� �������
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        // �������� ������ �������
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        // �������� ��������� �������
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;

            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

namespace mda
{
public class Node<T>
{
    public Node(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public Node<T> Next { get; set; }
}


internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
      
        static void Main()
        {
            string path;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}