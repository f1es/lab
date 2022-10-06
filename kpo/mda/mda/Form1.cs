namespace mda
{
    public partial class Form1 : Form
    {
        ZNAK[] BOOK = new ZNAK[8];
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
            //str2 = Input.Text;
            int number = Convert.ToInt32(comboBox2.SelectedItem);
            label2.Text = " ";
            str2 = " ";

            switch (comboBox1.SelectedItem)
            {
                case "Ввести имя и фамилию":
                    BOOK[number] = AddName(BOOK[number], Input.Text);
                    break;
                case "Ввести знак зодиака":
                    BOOK[number] = AddZodiac(BOOK[number], Input.Text);
                    break;
                case "Ввести день рождения":
                    BOOK[number] = AddBDay(BOOK[number], Input.Text);
                    break;
                case "Информация по фамилии":
                    // str2 = N4(str2);
                    label2.Text = str2;
                    break;
                case "Информация о всех":
                    int[] b = { 0, 0, 0 };
                    for (int i = 0; i < BOOK.Length - 1; i++)
                    {
                        if (BOOK[i].bdate != null) b = BOOK[i].bdate;
                        str2 += BOOK[i].name.Name + ' ' + BOOK[i].name.Surname + ' ' + BOOK[i].zodiac + ' ';

                        string day = "", month = "";
                        if (b[0] < 10) day += '0' + Convert.ToString(b[0]);
                        else day += Convert.ToString(b[1]);

                        if (b[1] < 10) month += '0' + Convert.ToString(b[1]);
                        else month += Convert.ToString(b[1]);

                        if (BOOK[i].bdate != null) str2 += Convert.ToString(day) + '.' + Convert.ToString(month) + '.' + Convert.ToString(b[2]) + Environment.NewLine;
                        else str2 += Environment.NewLine;

                    }
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

        ZNAK AddBDay(ZNAK znk, string str)
        {
            string[] words = str.Split(' ').ToArray();
            int[] array = new int[3];
            for (int i = 0; i < 3; i++)
            {
                array[i] = int.Parse(words[i]);
            }
            znk.bdate = array;
            return znk;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}