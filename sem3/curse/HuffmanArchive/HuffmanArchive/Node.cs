using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman
{
    class node
    {
        public readonly byte symbol;
        public readonly int freq;
        public readonly node bit0;
        public readonly node bit1;

        public node(byte symbol, int freq)
        {
            this.symbol = symbol;
            this.freq = freq;
        }

        public node(int freq, node bit0, node bit1)
        {
            this.freq = freq;
            this.bit0 = bit0;
            this.bit1 = bit1;
        }
    }
}
