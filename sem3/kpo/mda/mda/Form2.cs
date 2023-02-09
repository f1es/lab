namespace mda
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        Graphics gg;
        public void Form2_Paint_1(object sender, PaintEventArgs e)
        {


            gg = CreateGraphics();
            gg.Clear(Color.DarkBlue);
            Pen pen = new Pen(Color.Yellow, 3);

            gg.FillEllipse(new SolidBrush(Color.Yellow), 640, 100, 100, 100);
            gg.FillEllipse(new SolidBrush(Color.DarkBlue), 620, 100, 90, 90);

            //while (true)
            {
                for (int i = 0; i < 20; i++)
                {
                    //Создание объекта для генерации чисел
                    Random rnd = new Random();
                    //Получить случайное число (в диапазоне от 0 до 10)
                    int x = rnd.Next(0, 1280);
                    int y = rnd.Next(0, 720);

                    int n = 2;

                    Point[] points = {
                 new Point(10 * n + x, 10 * n + y),
                 new Point(18 * n + x, 12 * n + y),
                 new Point(20 * n + x, 20 * n + y),
                 new Point(22 * n + x, 12 * n + y),
                 new Point(30 * n + x, 10 * n + y),
                 new Point(22 * n + x, 8 * n + y),
                 new Point(20 * n + x, 0 * n + y),
                 new Point(18 * n + x, 8 * n + y),
                 new Point(10 * n + x, 10 * n + y),
                 new Point(18 * n + x, 12 * n + y)};


                    gg.DrawLines(pen, points);
                    gg.FillClosedCurve(new SolidBrush(Color.Yellow), points);
                }
                Thread.Sleep(30);
                //gg.Clear(Color.DarkBlue);
            }
            //Draw lines to screen.
           // gg.DrawLines(pen, points);
        }

      
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'f') Form2_Paint_1(sender, null);
        }
    }
 }
