
namespace Idea 
{
    class Program
    {
        static void Main()
        {
            Idea idea = new Idea("wfeeeeeeee", true);
            string str = " hello! ";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);
            var bb = idea.crypt(bytes);

            Console.WriteLine(System.Text.Encoding.ASCII.GetString(bb));

            Idea idea1 = new Idea("wfeeeeeeee", false);
            var aa = idea1.crypt(bytes);

            Console.WriteLine(System.Text.Encoding.ASCII.GetString(aa));
        }
    }
}