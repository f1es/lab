using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films
{
    class FavoriteFilm : Film
    {
        private string _description;

        public FavoriteFilm()
        {
            Console.WriteLine("class FavoriteFilm constructor was called");
            SetDescription(EnterDescription());
        }
        public FavoriteFilm(string name, int year, string type, int rate, string country, string description) : base(name, year , type, rate, country)
        {
            _description = description;
            Console.WriteLine("class FavoriteFilm constructor with paramerts was called");
        }
        public FavoriteFilm(FavoriteFilm favoriteFilm) : base(favoriteFilm)
        {
            _description = favoriteFilm.GetDescription();
            Console.WriteLine("class FavoriteFilm copy constructor was called");
        }

        ~FavoriteFilm()
        {
            Console.WriteLine("class FavoriteFilm destructor was called");
        }

        public static string EnterDescription()
        {
            while (true)
            {
                Console.Write("Enter favorite film description: ");
                string description = Console.ReadLine();
                if (CorrectInput.IsOnlyLetters(description))
                {
                    return description;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public void SetDescription(string description) 
        {
            _description = description; 
        }
        public string GetDescription() 
            => _description;

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
