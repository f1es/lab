
namespace Idea 
{
    class Program
    {
        static void Main()
        {
            Idea idea = new Idea("12345678soidfhiuoshf iuhfiulhsjfsioejdo isejfhoishfjiosjfoi shfos ", true);
            string str = "zdarova ";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);
            var bb = idea.crypt(bytes);

            Console.WriteLine(System.Text.Encoding.ASCII.GetString(bb));

            Idea idea1 = new Idea("12345678soidfhiuoshf iuhfiulhsjfsioejdo isejfhoishfjiosjfoi shfos ", false);
            var aa = idea1.crypt(bytes);

            Console.WriteLine(System.Text.Encoding.ASCII.GetString(aa));
        }
    }
}