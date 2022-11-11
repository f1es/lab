using System.Collections;
using System.Collections.Generic;
using SimpleAlgorithmsApp;


namespace mda
{
    public partial class Form1 : Form
    {
        
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
                case "Задание 1":
                    label2.Text = Convert.ToString(Calc());
                    break;
                case "Задание 2":
                    N2();
                    break;
            }
        }

        int Calc()
        {
            string str = Input.Text;

            NodeStack<int> NumStack = new NodeStack<int>();
            NodeStack<char> FuncStack = new NodeStack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    string temp = "";
                    while (char.IsDigit(str[i]))
                    {
                        temp += str[i];

                        i++;

                        if (i == str.Length) break;
                        //if (i == str.Length) break;
                    }
                    i--;

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
                        NumStack.Push(FirstNumber - SecNumber);
                        break;
                }
                //return NumStack.Peek();
            }
            return NumStack.Peek();
        }

        void N2()
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}