
namespace ti3
{
    class Program
    {
        
        static void Main()
        {
            Calculate calc = new Calculate();
            Console.WriteLine("Sum 123 + 321 : " + calc.Sum("123","321"));
            Console.WriteLine("Multiple 1234 * 5876 : " + calc.Multiple("1234","5876"));
            Console.WriteLine("Divide 4567176 / 14124 : " + calc.Divide("4576176","14124"));
            Console.WriteLine("Karatsuba Multiple 3245364 * 12536432 : " + calc.KaratsubaMultiple(3245364,12536432));
        }
    }
}