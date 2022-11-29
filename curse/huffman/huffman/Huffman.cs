using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman
{
    internal class Huffman
    {
        public void CompressFile(string dataFilename, string archiveFilename)
        {
            byte[] data = File.ReadAllBytes(dataFilename);
            byte[] arch = CompressBytes(data);
            File.WriteAllBytes(archiveFilename, arch);
        }

        public void DecompressFile(string archiveFilename, string dataFilename)
        {
            byte[] archive = File.ReadAllBytes(archiveFilename);
            byte[] data = DecompressBytes(archive);
            File.WriteAllBytes(dataFilename, data);
        }

        private byte[] DecompressBytes(byte[] archive)
        {
            ParseHeader(archive, out int dataLength, out int startIndex, out int[] freqs);
            node root = CreateHuffmanTree(freqs);
            byte[] data = Decompress(archive, startIndex, dataLength, root);
            return data;
        }

        private byte[] Decompress(byte[] archive, int startIndex, int dataLength, node root)
        {
            int size = 0;
            node curr = root;
            List<byte> data = new List<byte>();
            for (int j = startIndex; j < archive.Length; j++)
                for (int bit = 1; bit <= 128; bit <<= 1)
                {
                    bool zero = (archive[j] & bit) == 0;
                    if (zero)
                        curr = curr.bit0;
                    else curr = curr.bit1;
                    if (curr.bit0 != null)
                        continue;
                    if (size++ < dataLength)
                        data.Add(curr.symbol);
                    curr = root;
                }
            return data.ToArray();
        }

        private void ParseHeader(byte[] archive, 
            out int dataLength, 
            out int startIndex, 
            out int[] freqs)
        {
           dataLength = archive[0] |
                (archive[1] <<  8) |
                (archive[1] << 16) |
                (archive[1] << 24) ;

            freqs = new int[256];
            for (int j = 0; j < 256; j++)
                freqs[j] = archive[4 + j];

            startIndex = 4 + 256;
        }

        private byte[] CompressBytes(byte[] data)
        {
            int[] freqs = CalculateFreq(data);
            byte[] head = CreatHeadder(data.Length, freqs);
            node root = CreateHuffmanTree(freqs);
            string[] codes = CreateHuffmanCode(root);
            byte[] bits = Compress(data, codes);
            return head.Concat(bits).ToArray();
        }

        private byte[] CreatHeadder(int dataLength, int[] freqs)
        {
            List<byte> head = new List<byte>();
            head.Add((byte)(dataLength & 255));
            head.Add((byte)(dataLength >> 8 & 255));
            head.Add((byte)(dataLength >> 16 & 255));
            head.Add((byte)(dataLength >> 24 & 255));
            for (int j = 0; j < 256; j++)
                head.Add((byte)freqs[j]);
            return head.ToArray();
        }

        private byte[] Compress(byte[] data, string[] codes)
        {
            List<byte> bits = new List<byte>();
            byte sum = 0;
            byte bit = 1;
            foreach (byte symbol in data)
                foreach(char c in codes[symbol])
                {
                    if (c == '1')
                        sum |= bit;
                    if (bit < 128)
                        bit <<= 1;
                    else
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 1;
                    }
                }
            if (bit > 1)
                bits.Add(sum);
            return bits.ToArray();
        }

        private string[] CreateHuffmanCode(node root)
        {
            string[] codes = new string[256];
            Next(root, "");
            return codes;

            void Next(node Node, string code)
            {
                if (Node.bit0 == null)
                    codes[Node.symbol] = code;
                else
                {
                    Next(Node.bit0, code + "0");
                    Next(Node.bit1, code + "1");
                }
            }
        }

        private int[] CalculateFreq(byte[] data)
        {
            int[] freqs = new int[256];
            foreach (byte d in data)
                freqs[d]++;
            NormalizeFreqs(freqs);
            return freqs;

            void NormalizeFreqs(int[] freqs)
            {
                int max = freqs.Max();
                if (max <= 255) return;
                for (int j = 0; j < 256; j++)
                    if (freqs[j] > 0)
                        freqs[j] = 1 + freqs[j] * 255 / (max + 1);
            }
        }

        private node CreateHuffmanTree(int[] freqs)
        {
            PriorityQueue<node> pq = new PriorityQueue<node>();
            for (int j = 0; j < 256; j++)
            {
                if (freqs[j] > 0)
                    pq.Enqueue(freqs[j], new node((byte)j, freqs[j]));
            }
            while(pq.Size() > 1)
            {
                node bit0 = pq.Dequeue();
                node bit1 = pq.Dequeue();
                int freq = bit0.freq + bit1.freq;
                node next = new node(freq, bit0, bit1);
                pq.Enqueue(freq, next);
            }

            return pq.Dequeue();
        }
    }
}
