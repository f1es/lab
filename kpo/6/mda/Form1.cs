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
            //MessageBox.Show(":(");
            //str2 = Input.Text;
            Form2 newform = new Form2();
            newform.Show();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}