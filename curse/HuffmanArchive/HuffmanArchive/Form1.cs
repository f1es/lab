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
                FileInfo();
                Output.Text = "Path Selected";
            }
            catch
            {
                Output.Text = "Path Secelt Failed";
            }
        }

        private void FileInfo()
        {
            string OutputInfo = "";
            InfoBox.Text = "";

            //NAME
            OutputInfo += "Name : ";
            string temp = "";
            for (int i = path.Length - 1; path[i] != '\\'; i--)
                temp += path[i];


            string name = "";
            for (int i = temp.Length - 1; i >= 0; i--)
                name += temp[i];
            OutputInfo += name;
            OutputInfo += Environment.NewLine;

            //TYPE
            OutputInfo += "Type    : ";
            if (path.IndexOf(".txt") != -1)
            {
                OutputInfo += "Text Document";
            }
            else if (path.IndexOf(".png") != -1 || path.IndexOf(".jpg") != -1 || path.IndexOf(".bmp") != -1)
            {
                OutputInfo += "Picture";
            }
            else if (path.IndexOf(".mp3") != -1)
            {
                OutputInfo += "Sound";
            }
            else if (path.IndexOf(".mp4") != -1)
            {
                OutputInfo += "Video";
            }
            else
            {
                string tempType = "";
                for (int i = path.Length - 1; path[i] != '.'; i--)
                {
                    tempType += path[i];
                }
                string Type = "";
                for (int i = tempType.Length - 1; i >= 0; i--)
                {
                    Type += tempType[i];
                }
                OutputInfo += Type;
            }
            OutputInfo += Environment.NewLine;

            //SIZE
            OutputInfo += "Size     : ";


            byte[] data = File.ReadAllBytes(path);
            int dataSize = 0;
            dataSize = data.Length;
            if (dataSize > 1048576)
            {
                dataSize /= 1048576;
                OutputInfo += Convert.ToString(dataSize) + " MB";
            }
            else if (dataSize > 1024)
            {
                dataSize /= 1024;
                OutputInfo += Convert.ToString(dataSize) + " KB";
            }
            else
            {
                OutputInfo += Convert.ToString(data.Length) + " Bytes";
            }


            OutputInfo += Environment.NewLine;

            //MODIFIED
            OutputInfo += "Modified : ";
            var modified = File.GetLastWriteTime(path);
            OutputInfo += Convert.ToString(modified);

            InfoBox.Text = OutputInfo;
        }
    }
}