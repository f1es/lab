using huffman;
//string path = @"X:\vs\git\lab\curse\huffman\huffman\bin\Debug\net6.0\1.txt";

//string a = "1.txt";

Huffman huffman = new Huffman();

huffman.CompressFile("крым 2012.png", "крым 2012.png.huf");
huffman.DecompressFile("крым 2012.png.huf", "2крым 2012.png");
