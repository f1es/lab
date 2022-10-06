namespace mda
{
    public partial class Form1 : Form
    {
        ZNAK[] BOOK = new ZNAK[8];

        public Form1()
        {
            InitializeComponent();

            BOOK[0].name.Name = "Александр";
            BOOK[0].name.Surname = "Иванов";
            BOOK[0].zodiac = "Водолей";
            int[] a = { 15, 7, 2006 };
            BOOK[0].bdate = a;
            //
            BOOK[1].name.Name = "Сергей";
            BOOK[1].name.Surname = "Павлов";
            BOOK[1].zodiac = "Стрелец";
            int[] g = { 6, 9, 2007 };
            BOOK[1].bdate = g;
            //
            BOOK[2].name.Name = "Иван";
            BOOK[2].name.Surname = "Иванов";
            BOOK[2].zodiac = "Скорпион";
            int[] c = { 12, 12, 2004 };
            BOOK[2].bdate = c;
            //
            BOOK[3].name.Name = "Алексей";
            BOOK[3].name.Surname = "Алексеев";
            BOOK[3].zodiac = "Козерог";
            int[] d = { 7, 8, 2007 };
            BOOK[3].bdate = d;

            //int knopka = 0;
            button1.Click += button1_Click;
        }
        string str2;
        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object? sender, EventArgs e)
        {
            //MessageBox.Show(":(");
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
                    ZNAK temp;
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++) 
                        {
                            //int[] a1 = new int[3];
                            // int[] a2 = new int[3];
                            //a1 = BOOK[j].bdate;
                            //a2 = BOOK[i].bdate;
                            if (BOOK[j].bdate != null && BOOK[i].bdate != null)
                            {
                                if (BOOK[j].bdate[2] < BOOK[i].bdate[2])
                                {
                                    temp = BOOK[i];
                                    BOOK[i] = BOOK[j];
                                    BOOK[j] = temp;
                                }
                                else if (BOOK[j].bdate[2] == BOOK[i].bdate[2] && BOOK[j].bdate[1] < BOOK[i].bdate[1])
                                {
                                    temp = BOOK[i];
                                    BOOK[i] = BOOK[j];
                                    BOOK[j] = temp;
                                }
                                else if (BOOK[j].bdate[2] == BOOK[i].bdate[2] && BOOK[j].bdate[1] == BOOK[i].bdate[1] && BOOK[j].bdate[0] < BOOK[i].bdate[0])
                                {
                                    temp = BOOK[i];
                                    BOOK[i] = BOOK[j];
                                    BOOK[j] = temp;
                                }
                            }
                        }
                    break;
                case "Информация по фамилии":
                    int[] bb = { 0, 0, 0 };
                    for (int i = 0; i < BOOK.Length; i++)
                    {
                        if (Input.Text == BOOK[i].name.Surname)
                        {
                            if (BOOK[i].bdate != null) bb = BOOK[i].bdate;
                            str2 += BOOK[i].name.Name + ' ' + BOOK[i].name.Surname + " | " + BOOK[i].zodiac + " | ";

                            string day = "", month = "";
                            if (bb[0] < 10) day += '0' + Convert.ToString(bb[0]);
                            else day += Convert.ToString(bb[0]);

                            if (bb[1] < 10) month += '0' + Convert.ToString(bb[1]);
                            else month += Convert.ToString(bb[1]);

                            if (BOOK[i].bdate != null) str2 += Convert.ToString(day) + '.' + Convert.ToString(month) + '.' + Convert.ToString(bb[2]) + Environment.NewLine;
                            else str2 += Environment.NewLine;
                        }
                    }
                    label2.Text = str2;
                    break;
                case "Информация о всех":
                    int[] b = { 0, 0, 0 };
                    for (int i = 0; i < BOOK.Length - 1; i++)
                    {
                        if (BOOK[i].bdate != null)
                        {
                            b = BOOK[i].bdate;
                            str2 += BOOK[i].name.Name + ' ' + BOOK[i].name.Surname + " | " + BOOK[i].zodiac + " | ";

                            string day = "", month = "";
                            if (b[0] < 10) day += '0' + Convert.ToString(b[0]);
                            else day += Convert.ToString(b[0]);

                            if (b[1] < 10) month += '0' + Convert.ToString(b[1]);
                            else month += Convert.ToString(b[1]);

                            if (BOOK[i].bdate != null) str2 += Convert.ToString(day) + '.' + Convert.ToString(month) + '.' + Convert.ToString(b[2]) + Environment.NewLine;
                            else str2 += Environment.NewLine;
                        }
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