using System.Collections;


string a = " ";
a = Console.ReadLine();

Console.WriteLine(a);
double b;
b = da.Calc(a);
Console.WriteLine(b);

//Queue<string> queue = new Queue<string>();
//queue.Enqueue("Kate");
//queue.Enqueue("Sam");
//queue.Enqueue("Alice");
//queue.Enqueue("Tom");
//foreach (string item in queue)
//    Console.WriteLine(item);
//Console.WriteLine();
//Console.WriteLine();
//string firstItem = queue.Dequeue();
//Console.WriteLine($"Извлеченный элемент: {firstItem}");
//Console.WriteLine();
//foreach (string item in queue)
//    Console.WriteLine(item);

class da
{
    public static double Calc(string s)
    {
        s = '(' + s + ')';
        Stack<double> Operands = new Stack<double>();
        Stack<char> Functions = new Stack<char>();
        int pos = 0;
        object token;
        object prevToken = 'Ы';

        do
        {
            token = getToken(s, ref pos);
            // разрливаем унарный + и -
            if (token is char && prevToken is char &&
                // если эту сточку заменить на (char)prevToken != ')' &&
                // то можно будет писать (2 * -5) или даже (2 - -4)
                // но нужно будет ввести ещё одну проверку так, как запись 2 + -+-+-+2 тоже будет работать :)
                (char)prevToken == '(' &&
                ((char)token == '+' || (char)token == '-'))
                Operands.Push(0); // Добавляем нулевой элемент

            if (token is double) // Если операнд
            {
                Operands.Push((double)token); // то просто кидаем в стек
            }
            // в данном случае у нас только числа и операции. но можно добавить функции, переменные и т.д. и т.п.
            else if (token is char) // Если операция
            {
                if ((char)token == ')')
                {
                    // Скобка - исключение из правил. выталкивает все операции до первой открывающейся
                    while (Functions.Count > 0 && Functions.Peek() != '(')
                        popFunction(Operands, Functions);
                    Functions.Pop(); // Удаляем саму скобку "("
                }
                else
                {
                    while (canPop((char)token, Functions)) // Если можно вытолкнуть
                        popFunction(Operands, Functions); // то выталкиваем

                    Functions.Push((char)token); // Кидаем новую операцию в стек
                }
            }
            prevToken = token;
        }
        while (token != null);

        if (Operands.Count > 1 || Functions.Count > 0)
            throw new Exception("Ошибка в разборе выражения");

        return Operands.Pop();
    }

    private static void popFunction(Stack<double> Operands, Stack<char> Functions)
    {
        double B = Operands.Pop();
        double A = Operands.Pop();
        switch (Functions.Pop())
        {
            case '+':
                Operands.Push(A + B);
                break;
            case '-':
                Operands.Push(A - B);
                break;
            case '*':
                Operands.Push(A * B);
                break;
            case '/':
                Operands.Push(A / B);
                break;
        }
    }

    private static bool canPop(char op1, Stack<char> Functions)
    {
        if (Functions.Count == 0)
            return false;
        int p1 = getPriority(op1);
        int p2 = getPriority(Functions.Peek());

        return p1 >= 0 && p2 >= 0 && p1 >= p2;
    }

    private static int getPriority(char op)
    {
        switch (op)
        {
            case '(':
                return -1; // не выталкивает сам и не дает вытолкнуть себя другим
            case '*':
            case '/':
                return 1;
            case '+':
            case '-':
                return 2;
            default:
                throw new Exception("недопустимая операция");
        }
    }

    private static object getToken(string s, ref int pos)
    {
        readWhiteSpace(s, ref pos);

        if (pos == s.Length) // конец строки
            return null;
        if (char.IsDigit(s[pos]))
            return Convert.ToDouble(readDouble(s, ref pos));
        else
            return readFunction(s, ref pos);
    }

    private static char readFunction(string s, ref int pos)
    {
        // в данном случае все операции состоят из одного символа
        // но мы можем усложнить код добавив == && || mod div и ещё чегонить
        return s[pos++];
    }

    private static string readDouble(string s, ref int pos)
    {
        string res = "";
        while (pos < s.Length && (char.IsDigit(s[pos]) || s[pos] == '.'))
            res += s[pos++];

        return res;
    }

    // Считывает все проблемы и прочие левые символы.
    private static void readWhiteSpace(string s, ref int pos)
    {
        while (pos < s.Length && char.IsWhiteSpace(s[pos]))
            pos++;
    }
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
    public class Queue<T> : IEnumerable<T>
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;
        // добавление в очередь
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
        // удаление из очереди
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        // получаем первый элемент
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        // получаем последний элемент
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