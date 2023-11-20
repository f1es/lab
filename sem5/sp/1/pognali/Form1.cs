namespace pognali
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ChangeColor();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        protected override void OnClick(EventArgs e)
        {
            ChangeColor();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            ChangeColor();
        }

        private void ChangeColor()
        {
            BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }


    }
}