
namespace ti4
{
    class Program
    {
        public static void Main()
        {
            Vijener vijener = new Vijener();
            string words = "data and data and data and data and data and data",
                key = "Mouse";
            var cryptedText = Vijener.VijenerEncrypt(words, key);
            Console.WriteLine(cryptedText);

            string encr = Vijener.VijenerEncrypt(words,key);
            Console.WriteLine(Vijener.VijenarDecrypt(encr,key));

            var lengths = Attack.CalcKeyLengths(Attack.RepeatedBlocks(cryptedText));
            foreach (var length in lengths)
                Console.WriteLine($"Possible key length: {length}");
        }
    }
}