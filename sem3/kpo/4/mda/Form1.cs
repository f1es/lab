namespace mda
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            label2.Text = "Vveddite pyth k faily Введите путь к файлу";
            button1.Click += button1_Click;
        }
        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object? sender, EventArgs e)
        {
            //MessageBox.Show(":(");
            //str2 = Input.Text;
            label2.Text = " ";

            
            string path = Path.Text;
            //if(Input.Text != "") path = @Input.Text;

            switch (comboBox1.SelectedItem)
            {
                case "Задание 1":
                    //FileInfo fileInf = new FileInfo(path);
                    //fileInf.Create();
                    //File.WriteAllTextAsync(path, "\n123");
                    N1(path);
                    break;
                case "Задание 2":
                    N2(path);
                    break;
            }
        }

        void N1(string path)
        {
            string[] str = File.ReadAllLines(path);

            double min = 99999999, max = -99999999;
            if (str.Length < 1)
            {
                label2.Text = "Need more pairs of numbers";
            }
            else
            {
                int x1 = 0, y1 = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    x1 = Convert.ToInt32(str[i][0]) - 48; y1 = Convert.ToInt32(str[i][2]) - 48;
                    for (int j = 0; j < str.Length; j++)
                    {
                        int x2 = str[j][0] - 48, y2 = str[j][2] - 48;
                        double distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                        if (distance < min && distance != 0)
                        {
                            min = distance;
                        }
                        if (distance > max && distance != 0)
                        {
                            max = distance;
                        }
                    }
                }
            }
            label2.Text = "Maximum distance is : " + max + " Minimum distance is : " + min;
        }

        void N2(string path)
        {
            string path2 = path.Substring(0, path.Length - 4);
            path2 += "2.txt";

            string[] str = File.ReadAllLines(path);
            for (int i = 0; i < str.Length; i++)
            {
                File.AppendAllText(path2, str[i]);
                File.AppendAllText(path2, "\n");
            }

            string s = Input.Text;

            File.AppendAllText(path2, s);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}