using System.Windows.Forms;
using changeRegister;

namespace RegisterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LowerRegisterButtonClick(object sender, EventArgs e)
        {
            if (Clipboard.GetText().Length == 0)
                return;
            string lowerString = Register.ToLowerReg(Clipboard.GetText()); 
            Clipboard.SetText(lowerString);
        }
        private void UpperRegisterButtonClick(object sender, EventArgs e)
        {
            if (Clipboard.GetText().Length == 0)
                return;
            string upperString = Register.ToUpperReg(Clipboard.GetText()); 
            Clipboard.SetText(upperString);
        }
        private void CheckClipboardButtonClick(object sender, EventArgs e)
        {
            if (Clipboard.GetText().Length > 0)
                MessageBox.Show(Clipboard.GetText());
            else
                MessageBox.Show("Буфер обмена не содержит текста");
        }
    }
}
