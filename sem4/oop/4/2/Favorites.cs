using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace da
{
    class Favorites : Film
    {
        Program h = new Program();
        string Description;
        
        public void SetDescription()
        {
            while (true)
            {
                Console.Write("Enter favorite film description: ");
                string description = Console.ReadLine();
                if (h.IsOnlyLetters(description) == true && description != "")
                {
                    Description = description;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public string GetDescription() => Description;

        public Favorites()
        {
            Console.WriteLine("class favorites constructor was called");
            SetDescription();
        }

        ~Favorites()
        {
            Console.WriteLine("class favorites destructor was called");
        }

        public override void SeeInfo()
        {
            Console.WriteLine("\tFilm: " + GetName());
            Console.WriteLine("\tYear: " + GetYear());
            Console.WriteLine("\tType: " + GetType());
            Console.WriteLine("\tRating: " + GetRate());
            Console.WriteLine("\tCountry: " + GetCountry());
            Console.WriteLine("\tDescription: " + Description);
        }
    }
}
