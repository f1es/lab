using System.Collections;
using System.Collections.Generic;
using SimpleAlgorithmsApp;


NodeStack<string> sstack = new NodeStack<string>();

sstack.Push("sdf");
string str2 = sstack.Pop();
Console.WriteLine(str2);

NodeStack<int> NumStack = new NodeStack<int>();
NodeStack<char> FuncStack = new NodeStack<char>();

string str = "1 - 1";


for (int i = 0; i < str.Length; i++)
{
    //while(char.IsDigit(str[i]))
    //{
    //    string temp = "";
    //    temp += str[i];
    //    i++;
    //}

    if (char.IsDigit(str[i]))
    {
        string temp = "";
        while (char.IsDigit(str[i]))
        {
            temp += str[i];
            i++;
            if (i == str.Length) break;
        }

        int a = Convert.ToInt32(temp);
        NumStack.Push(a);
    }
    else if (str[i] == '+' || str[i] == '-') FuncStack.Push(str[i]);
}

Console.WriteLine(Calc(NumStack, FuncStack));

int Calc(NodeStack<int> NumStack, NodeStack<char> FuncStack)
{
    while (FuncStack.Count > 0)
    {
        int SecNumber = NumStack.Peek();
        NumStack.Pop();
        int FirstNumber = NumStack.Peek();
        NumStack.Pop();

        switch (FuncStack.Peek())
        {
            case '+':
                FuncStack.Pop();
                NumStack.Push(SecNumber + FirstNumber);
                break;
            case '-':
                FuncStack.Pop();
                NumStack.Push(FirstNumber - SecNumber);
                break;
        }
    //return NumStack.Peek();
    }
    return NumStack.Peek();
}


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
    //NodeStack<string> sstack = new NodeStack<string>();

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
            // увеличиваем стек
            Node<T> node = new Node<T>(item);
            node.Next = head; // переустанавливаем верхушку стекана новый элемент
            head = node;
            count++;
        }
        public T Pop()
        {
            // если стек пуст, выбрасываем исключение
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            Node<T> temp = head;
            head = head.Next; // переустанавливаем верхушку стекана следующий элемент
            count--;
            return temp.Data;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
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
