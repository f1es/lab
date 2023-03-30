
namespace ti3
{
    class Program
    {
        
        static void Main()
        {
            Calculate c = new Calculate();
            //int a = c.Sum("23421","192352");
            //Console.WriteLine("sum = " + a);
            //Console.WriteLine("mul "+ c.Multiple("23865","321"));
            string a = "", b = "";
            Console.WriteLine("1 number : ");  a = Console.ReadLine();
            Console.WriteLine("2 number : "); b = Console.ReadLine();
            string cc = c.Divide(a, b);
            Console.WriteLine(cc);
        }
    }
}