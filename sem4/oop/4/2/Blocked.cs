using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace da
{
    internal class Blocked : Film
    {
        Program h = new Program();
        string BlockReason;
        public void SetDescription()
        {
            while (true)
            {
                Console.Write("Enter block reason: ");
                string blockReason = Console.ReadLine();
                if (h.IsOnlyLetters(blockReason) == true && blockReason != "")
                {
                    BlockReason = blockReason;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public string GetDescription() => BlockReason;


        public Blocked()
        {
            Console.WriteLine("class blocked constructor was called");
            SetDescription();
        }

        ~Blocked()
        {
            Console.WriteLine("class blocked destructor was called");
        }

        public override void SeeInfo()
        {
            Console.WriteLine("\tFilm: " + GetName());
            Console.WriteLine("\tYear: " + GetYear());
            Console.WriteLine("\tType: " + GetType());
            Console.WriteLine("\tRating: " + GetRate());
            Console.WriteLine("\tCountry: " + GetCountry());
            Console.WriteLine("\tBlock reason: " + BlockReason);
        }
    }
}
