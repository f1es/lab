namespace mda
{
    public partial class Form1 : Form
    {
        ZNAK[] arr = new ZNAK[8];
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
            int number = Convert.ToInt32(comboBox2.SelectedItem);


            switch(comboBox1.SelectedItem)
            {
                case "Ввести имя и фамилию":
                    arr[number] = AddName(arr[number], Input.Text);
                    //str2 = N1(str2);
                    //label2.Text = str2;
                    break;
                case "Ввести знак зодиака":
                    arr[number] = AddZodiac(arr[number], Input.Text);
                    break;
                case "Ввести день рождения":
                    //arr[number] = AddName(arr[number], Input.Text);
                    break;
                case "Информация по фамилии":
                   // str2 = N4(str2);
                    label2.Text = str2;
                    break;
                case "Информация о всех":
                    // str2 = N4(str2);
                    label2.Text = str2;
                    break;
            }
        }

        ZNAK AddName(ZNAK znk, string str)
        {
            string[] words = str.Split(' ').ToArray();
            znk.name.Name = words[0];
            znk.name.Surname = words[1];
            return znk;
        }

        ZNAK AddZodiac(ZNAK znk, string str)
        {
            znk.zodiac = str;
            return znk;
        }

        ZNAK AddBDay(ZNAK znk, params int[] d)
        {
            for (int i = 0; i < d.Length; i++) znk.bdate[i] = d[i];
            return znk;
        }

        string N4(string str)
        {
            string str2 = "";
            string[] words = str.Split(' ').ToArray(); 

            for(int i = 0; i < words.Length; i++)
            {
                try
                {
                   int a = int .Parse(words[i]);

                    str2 += " <";
                   str2 += Convert.ToString(a);
                    str2 += "> ";
                }
                catch   
                {
                    str2 += words[i];
                }
            }

            return str2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}