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
            if (Convert.ToInt32(comboBox1.SelectedItem) == 1)
            {
                str2 = N1(str2);
                label2.Text = str2;
            }
            switch(Convert.ToInt32(comboBox1.SelectedItem))
            {
                case 1:
                    str2 = N1(str2);
                    label2.Text = str2;
                    break;
                case 2:
                    str2 = N2(str2);
                    label2.Text = str2;
                    break;
                case 3:
                    str2 = N1(str2);
                    label2.Text = str2;
                    break;
                case 4:
                    str2 = N4(str2);
                    label2.Text = str2;
                    break;
            }
        }

        string N1(string str2)
        {
            string str = "";
            int i = str2.Length;
            if (str2.Length > 2)
            {
                str += "first element : ";str += str2[0];
                str += "middle element :"; str += str2[str2.Length / 2];
                str += "last element : "; str += str2[i - 1];
                return str;
            }
            if (str2.Length == 2)
            {
                str += "first element : \'"; str += str2[0];
                str += " last element : "; str += str2[i - 1];
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
            str2 = "aba count : " + Convert.ToString(counter);
            return str2;
        }
        //string N3(string str)
        //{
        //    Regex regex = new Regex("\\b[\\wР-пр-џ]+\\b");
        //    str = textBox1.Text;
        //    var words = regex.Matches(str).Cast<Match>()
        //        .Select(x => x.Value)
        //        .OrderBy(x => x)
        //        .ToArray();
        //    string str2 = "";
        //    for (int i = 0; i < words.Length; i++)
        //    {
        //       str2 += words[i];
        //        str2 += ' ';
        //    }

        //    str2 += Environment.NewLine;

        //    //str2 += "weewgw";

        //    int count = 0;
        //    for(int i = 0; i < words.Length; i++)
        //    {
        //        for(int j = 0; j < words[i].Length; j++)
        //        {
        //            if (words[i][j] == 'р') count++;
        //        }

        //        if (count >= 2)
        //        {
        //            str2 += ' ';
        //            str2 += words[i];
        //        }
        //        count = 0;
        //    }

        //    return str2;
        //}

        string N4(string str)
        {
            string str2 = "";
            string[] words = str.Split(' ').ToArray(); 

            for(int i = 0; i < words.Length; i++)
            {
                try
                {
                   int a = int .Parse(words[i]);

                    str2 += '<';
                   str2 += Convert.ToString(a);
                    str2 += '>';
                }
                catch(Exception e)    
                {
                    str2 += words[i];
                }

                //str2 += Convert.ToString(a);

            }

            return str2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}