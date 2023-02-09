using huffman;
using System.Windows.Forms.VisualStyles;

namespace HuffmanArchive
{
    public partial class HuffmanArchiver : Form
    {
        string path = "c:\\";
        Huffman huffman = new Huffman();
        public string SelectFilePath()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = path;
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

        public string SelectFolderPath()
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = folderBrowserDialog1.SelectedPath;
                }
            }
                //if (FolderBrowserDialog1)
            return path;
        }

        public HuffmanArchiver()
        {
            InitializeComponent();
        }

        public static string ReverseString(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            if (path != "c:\\") try
            {
                try { FileCompress(); }
                catch { FolderCompress(); }
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
                try { FileDecompress(); }
                catch { FolderDecompress(); }
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
                path = SelectFolderPath();
                string TextPath = "";
                for (int i = 0; i < path.Length; i++)
                {
                    TextPath += path[i];
                    if (i % 29 == 0 && i != 0) TextPath += System.Environment.NewLine;
                }
                PathLabel.Text = TextPath;
                FolderInfo();
                Output.Text = "Folder Selected";
            }
            catch
            {
                Output.Text = "Folder select Failed";
            }
        }

        private void FolderInfo()
        {
            string OutputInfo = "";
            InfoBox.Text = "";

            //NAME
            OutputInfo += "Name    : ";
            string temp = "";
            for (int i = path.Length - 1; path[i] != '\\'; i--)
                temp += path[i];

            string name = "";
            for (int i = temp.Length - 1; i >= 0; i--)
                name += temp[i];
            OutputInfo += name;
            OutputInfo += Environment.NewLine;

            //TYPE
            OutputInfo += "Type       : Folder";
            OutputInfo += Environment.NewLine;

            //CREATED
            OutputInfo += "Created : ";
            var created = Directory.GetCreationTime(path);
            OutputInfo += created.ToString();
            OutputInfo += Environment.NewLine;

            //SIZE
            OutputInfo += "Size        : ";
            string[] files = Directory.GetFiles(path);
            int dataSize = 0;
            byte[] data;
            for (int i = 0; i < files.Length; i++)
            {
                data = File.ReadAllBytes(files[i]);
                dataSize += data.Length;
            }

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
                OutputInfo += Convert.ToString(dataSize) + " Bytes";
            }
            InfoBox.Text = OutputInfo;

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

        private void SFile_Click(object sender, EventArgs e)
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
                Output.Text = "File Selected";
            }
            catch
            {
                Output.Text = "File select Failed";
            }
        }

        private void FileCompress()
        {
            huffman.CompressFile(path, path + ".huf");
            Output.Text = "Compress Complete";
        }

        private void FolderCompress()
        {
            string[] paths = Directory.GetFiles(path);
            string archivePath = path + "_COMPRESSED";
            System.IO.Directory.CreateDirectory(archivePath);

            string[] names = new string[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                string name = "";
                for (int j = paths[i].Length - 1; paths[i][j] != '\\'; j--)
                {
                    name += paths[i][j];
                }
                name = ReverseString(name);
                names[i] = name;
            }

            for (int i = 0; i < paths.Length; i++)
            {
                huffman.CompressFile(paths[i], archivePath + "\\" + names[i] + ".huf");
            }

            Output.Text = "Compress Complete";
        }

        private void FileDecompress()
        {
            string fileName = path;
            fileName = fileName.Remove(fileName.Length - 4, 4);
            huffman.DecompressFile(path, fileName);
            Output.Text = "Decompress Complete";
        }

        private void FolderDecompress()
        {
            string[] paths = Directory.GetFiles(path);
            string archivePath = path.Remove(path.Length - 11, 11) + "_DECOMPRESSED";
            System.IO.Directory.CreateDirectory(archivePath);

            string[] names = new string[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                string name = "";
                for (int j = paths[i].Length - 1; paths[i][j] != '\\'; j--)
                {
                    name += paths[i][j];
                }
                name = ReverseString(name);
                name = name.Remove(name.Length - 4, 4);
                names[i] = name;
            }
            for (int i = 0; i < paths.Length; i++)
            {
                huffman.DecompressFile(paths[i], archivePath + "\\" + names[i]);
            }
            Output.Text = "Decompress Complete";
        }
    }
}