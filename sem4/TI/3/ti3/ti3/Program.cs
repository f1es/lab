
using System.Numerics;

namespace ti3
{
    class Program
    {
        
        static void Main()
        {
            Calculate calc = new Calculate();
            string sum1 = "110", sum2 = "321";
            Console.WriteLine($"Sum {sum1} + {sum2} : " + calc.Sum(sum1,sum2));
            string mult1 = "3245364", mult2 = "12536432";
            Console.WriteLine($"Multiple {mult1} * {mult2} : " + calc.Multiple("12345","12345"));
            string div1 = "4567176", div2 = "14124";
            Console.WriteLine($"Divide {div1} / {div2} : " + calc.Divide(div1,div2));
            BigInteger karatsuba1 = 8475647382938476364, karatsuba2 = 9485748394857674832;
            Console.WriteLine($"Karatsuba Multiple {karatsuba1} * {karatsuba2} : " + calc.KaratsubaMultiple(karatsuba1,karatsuba2));
        }
    }
}