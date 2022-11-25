using System.Collections;
using System.Collections.Generic;
using SimpleAlgorithmsApp;
using SimpleAlgorithmsQueue;


namespace mda
{
    public partial class Form1 : Form
    {
        QUEUE<int> queue = new QUEUE<int>();
        public Form1()
        {


            InitializeComponent();
            button1.Click += button1_Click;
        }
        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object? sender, EventArgs e)
        {
            
            switch (comboBox1.SelectedItem)
            {
                case "Вычисление стеками":
                    label2.Text = Convert.ToString(Calc());
                    break;
                case "Добавить в очередь":
                    куеуедобавить(queue);
                    break;
                case "Вывести очередь":
                    куеуевывести(queue);
                    break;
                case "Убрать из очереди":
                    куеуеубрать(queue);
                    break;
            }
        }

        int Calc()
        {
            string str = Input.Text;

            NodeStack<int> NumStack = new NodeStack<int>();
            NodeStack<char> FuncStack = new NodeStack<char>();

            for (int i = (str.Length - 1); i > -1; i--)
            {
                if (char.IsDigit(str[i]))
                {
                    string temp = "";
                    while (char.IsDigit(str[i]))
                    {
                        temp += str[i];
                        i--;
                        if (i == -1) break;
                        //if (i == str.Length) break;
                    }
                    i++;
                    temp = ReverseString(temp);
                    int a = Convert.ToInt32(temp);
                    NumStack.Push(a);
                }
                else if (str[i] == '+' || str[i] == '-') FuncStack.Push(str[i]);
            }

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
                        NumStack.Push(SecNumber - FirstNumber);
                        break;
                }
                //return NumStack.Peek();
            }
            return NumStack.Peek();
        }
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        void куеуе()
        {
            QUEUE<int> queue = new QUEUE<int>();
            queue.Enqueue(1);
            label2.Text = Convert.ToString(queue.First());
        }

        void куеуедобавить(QUEUE<int> queue)
        {
            queue.Enqueue(Convert.ToInt32(Input.Text));
        }
        void куеуеубрать(QUEUE<int> queue)
        {
            queue.Dequeue();
        }
        void куеуевывести(QUEUE<int> queue)
        {
            //QUEUE<int> queue = new QUEUE<int>();
            label2.Text = queue.Show();
            //label2.Text = Convert.ToString(queue.First());
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}