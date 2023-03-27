using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films
{
    internal class Blocked : Film
    {
        string _blockReason;
        public Blocked()
        {
            Console.WriteLine("class blocked constructor was called");
            SetDescription();
        }

        ~Blocked()
        {
            Console.WriteLine("class blocked destructor was called");
        }

        public void SetDescription()
        {
            while (true)
            {
                Console.Write("Enter block reason: ");
                string blockReason = Console.ReadLine();
                if (CorrectInput.IsOnlyLetters(blockReason) == true && blockReason != "")
                {
                    _blockReason = blockReason;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public string GetDescription() => _blockReason;

        public new void SeeInfo()
        {
            Console.WriteLine("\tFilm: " + GetName());
            Console.WriteLine("\tYear: " + GetYear());
            Console.WriteLine("\tType: " + GetType());
            Console.WriteLine("\tRating: " + GetRate());
            Console.WriteLine("\tCountry: " + GetCountry());
            Console.WriteLine("\tBlock reason: " + _blockReason);
        }
    }
}
