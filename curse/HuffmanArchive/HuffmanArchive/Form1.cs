using huffman;

namespace HuffmanArchive
{
    public partial class HuffmanArchiver : Form
    {
        string path;
        Huffman huffman = new Huffman();
        public string SelectFilePath()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
        }



        public HuffmanArchiver()
        {
            InitializeComponent();
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            try
            {
                string formatPath = path;
                formatPath += ".huf";
                huffman.CompressFile(path, formatPath);
                Output.Text = "Compress Complete";
            }
            catch
            {
                Output.Text = "Compress Failed";
            }
        }

        private void DecompressButton_Click(object sender, EventArgs e)
        {
            try
            {
                string formatPath = path;
                if (formatPath.IndexOf(".huf") == -1) throw new System.Exception("Incorrect path");
                formatPath = formatPath.Remove(formatPath.Length - 4, 4);
                huffman.DecompressFile(path, formatPath);
                Output.Text = "Decompress Complete";
            }
            catch
            {
                Output.Text = "Decompress Failed";
            }
        }

        private void SPButton_Click(object sender, EventArgs e)
        {
            try
            {
                path = SelectFilePath();
                string TextPath = "";
                for (int i = 0; i < path.Length; i++)
                {
                    TextPath += path[i];
                    if (i % 29 == 0 && i != 0) TextPath += System.Environment.NewLine;
                }
                PathLabel.Text = TextPath;
                Output.Text = "Path Selected";
            }
            catch
            {
                Output.Text = "Path Secelt Failed";
            }
        }
    }
}