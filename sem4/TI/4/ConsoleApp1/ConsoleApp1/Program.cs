
namespace ti4
{
    class Program
    {
        public static void Main()
        {
            string words = "CRYPTOGRAPHY AND DATA SECURITY", key = "MOUSE";
            Console.WriteLine(Vijener.VijenerEncrypt(words,key));

            string encr = Vijener.VijenerEncrypt(words,key);
            Console.WriteLine(Vijener.VijenarDecrypt(encr,key));
        }
    }
}