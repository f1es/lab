namespace mda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }
        string str2;
        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            str2 = Input.Text;
            //MessageBox.Show(str2);
            str2 = N3(str2);
            label2.Text = str2;
        }

        string N1(string str2)
        {
            string str = "";
            int i = str2.Length;
            if(str2.Length > 2)
            {
                str += "Первый символ : "; str += str2[0];
                str += " Средний символ : "; str += str2[str2.Length / 2];

                str += " Последний символ : "; str += str2[i - 1];
                return str;
            }
            if (str2.Length == 2)
            {
                str += "Первый символ : "; str += str2[0];

                str += " Последний символ : "; str += str2[i - 1];
                return str;
            }

            return str;
        }

        string N2(string str)
        {
            int counter = 0;
            for (int i = 0; i < (str.Length) - 2; i++)
            {
                if (str[i] == 'a' && str[i + 1] == 'b' && str[i + 2] == 'a')
                {
                    counter++;
                }
            }

            string str2;
            str2 = "Количество вхождений : " + Convert.ToString(counter);
            return str2;
        }

        string N3(string str)
        {
            string str2 = "";
            int glasniy_counter = 0;
            int glasniy_counter_max = 0;
            int pos = 0;
            for(int i = 0; i < str.Length; i++)
            {
               if (str[i] == 'a' || str[i] == 'e' || str[i] == 'y' || str[i] == 'u' || str[i] == 'i' || str[i] == 'o') glasniy_counter++;
                if (str[i] == ' ' && glasniy_counter_max < glasniy_counter)
                {
                    pos = i;
                    glasniy_counter_max = glasniy_counter;
                    glasniy_counter = 0;
                }
                if (str[i] == ' ') glasniy_counter = 0;
            }

            glasniy_counter = 0;
            string str_temp = " ";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a' || str[i] == 'e' || str[i] == 'y' || str[i] == 'u' || str[i] == 'i' || str[i] == 'o') glasniy_counter++;
                if (str[i] == ' ' && glasniy_counter == glasniy_counter_max)
                {
                    pos = i - 1;
                    while (str[pos] != ' ') 
                    {
                        str_temp += str[pos];
                        pos--;
                    }
                    str_temp += ' ';
                }
                if (str[i] == ' ') glasniy_counter = 0;
            }

            //glasniy_counter_prev = glasniy_counter;
            //glasniy_counter = 0;

            //int a = ++pos;
            //while (str[a] != ' ' || a == str.Length)
            //{
            //    str2 += str[a];
            //    str = str.Remove(a,a);
            //    a++;
            //}

            return str2;
        }

        //StringBuilder someString = new StringBuilder(drb);
        //someString[k] = str[k + 2];
        //drb = someString.ToString();

        string N4(string str)
        {
            string str2 = "";

            int pos = 0, aaaaaa = 1;
            for(int i = 0; i < str.Length; i++)
            {
                if (aaaaaa == 0 && str[i] == ' ')
                {
                    str[pos] = '<';
                    str[i] = '>';
                }
                if (str[i] == ' ') 
                {
                    pos = i;
                    aaaaaa = 0;
                }
                if (str[i] < 48 || str[i] > 57) aaaaaa = 1;

            }

            return str2;
        }
    }
}