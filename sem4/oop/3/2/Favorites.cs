using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films
{
    class Favorites : Film
    {
        string _description;

        public Favorites()
        {
            Console.WriteLine("class favorites constructor was called");
            SetDescription();
        }

        ~Favorites()
        {
            Console.WriteLine("class favorites destructor was called");
        }

        public void SetDescription()
        {
            while (true)
            {
                Console.Write("Enter favorite film description: ");
                string description = Console.ReadLine();
                if (CorrectInput.IsOnlyLetters(description) && description != "")
                {
                    _description = description;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public string GetDescription() => _description;

        public new void SeeInfo()
        {
            Console.WriteLine("\tFilm: " + GetName());
            Console.WriteLine("\tYear: " + GetYear());
            Console.WriteLine("\tType: " + GetType());
            Console.WriteLine("\tRating: " + GetRate());
            Console.WriteLine("\tCountry: " + GetCountry());
            Console.WriteLine("\tDescription: " + _description);
        }
    }
}
