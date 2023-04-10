using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films
{
    class BlockedFilm : Film
    {
        private string _blockReason;
        public BlockedFilm()
        {
            Console.WriteLine("class BlockedFilm constructor was called");
            SetDescription(EnterDescription());
        }

        public BlockedFilm(string name, int year, string type, int rate, string country, string blockReason) : base(name, year, type, rate, country)
        {
            SetDescription(blockReason);
            Console.WriteLine("class BlockedFilm constructor with parametrs was called");
        }

        public BlockedFilm(BlockedFilm blockedFilm) : base(blockedFilm)
        {
            _blockReason = blockedFilm._blockReason;
            Console.WriteLine("class BlockedFilm copy constructor was called");
        }

        ~BlockedFilm()
        {
            Console.WriteLine("class BlockedFilm destructor was called");
        }

        public static string EnterDescription()
        {
            while (true)
            {
                Console.Write("Enter block reason: ");
                string blockReason = Console.ReadLine();
                if (CorrectInput.IsOnlyLetters(blockReason))
                {
                    return blockReason;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public void SetDescription(string blockReason) { _blockReason = blockReason; }
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
