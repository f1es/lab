using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;

namespace da
{
    class Program
    {
        public bool IsOnlyLetters(string str)
        {
            foreach (char c in str)
            {
                if (Char.IsNumber(c)) return false;
                if (c == '-') return false;
                if (c == '.') return false;
                if (c == ',') return false;
                if (c == ';') return false;
                if (c == '/') return false;
                if (c == ':') return false;
                if (c == '@') return false;
                if (c == '#') return false;
                if (c == '$') return false;
                if (c == '%') return false;
                if (c == '^') return false;
                if (c == '&') return false;
                if (c == '*') return false;
            }
            return true;
        }

        static void Main()
        {
            //Film film = new Film();
            //Favorites favoriteFilm = new Favorites();
            //Blocked blockedFilm = new Blocked();

            //film.SeeInfo();
            //favoriteFilm.SeeInfo();
            //blockedFilm.SeeInfo();
            
            List<Film> films = new List<Film>();
            List<Favorites> favoriteFilms = new List<Favorites>();
            List<Blocked> blockedFilms = new List<Blocked>();

            bool MenuCycle = true;
            while (MenuCycle)
            {
                Console.WriteLine("Select operation");
                Console.WriteLine("[1] - add\n[2] - info all");

                int.TryParse(Console.ReadLine(), out int choise);
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Select film list");
                        Console.WriteLine("[1] - films\n[2] - favorites\n[3] - blocked");
                        int.TryParse(Console.ReadLine(), out int listChoise);
                        switch(listChoise)
                        {
                            case 1:
                                Console.WriteLine("Select film type");
                                Console.WriteLine("[1] - common\n[2] - favorite\n[3] - blocked");
                                int.TryParse(Console.ReadLine(), out int filmChoise);
                                switch(filmChoise)
                                {
                                    case 1:
                                        Film film = new Film();
                                        films.Add(film);
                                        break;
                                    case 2:
                                        Favorites favorite = new Favorites();
                                        films.Add(favorite);
                                        break;
                                    case 3:
                                        Blocked blocked = new Blocked();
                                        films.Add(blocked);
                                        break;
                                }
                                break;
                            case 2:
                                Favorites favoriteFilm = new Favorites();
                                favoriteFilms.Add(favoriteFilm);
                                break;
                            case 3:
                                Blocked blockedFilm = new Blocked();
                                blockedFilms.Add(blockedFilm);
                                break;
                        }

                        break;
                    case 2:
                        if (films.Count == 0)
                        {
                            Console.WriteLine("List of films is empty");
                        }
                        else
                        {
                            Console.WriteLine("List of films:");
                            for (int i = 0; i < films.Count; i++)
                            {
                                Console.Write(i + ".");
                                films[i].SeeInfo();
                                Console.WriteLine(" ");
                            }
                        }

                        if (favoriteFilms.Count == 0)
                        {
                            Console.WriteLine("List of favorite films is empty");
                        }
                        else
                        {
                            Console.WriteLine("List of favorite films:");
                            for (int i = 0; i < favoriteFilms.Count; i++)
                            {
                                Console.Write(i + ".");
                                favoriteFilms[i].SeeInfo();
                                Console.WriteLine(" ");
                            }
                        }

                        if (blockedFilms.Count == 0)
                        {
                            Console.WriteLine("List of blocked films is empty");
                        }
                        else
                        {
                            Console.WriteLine("List of blocked films:");
                            for (int i = 0; i < blockedFilms.Count; i++)
                            {
                                Console.Write(i + ".");
                                blockedFilms[i].SeeInfo();
                                Console.WriteLine(" ");
                            }
                        }
                        break;
                    case -1:
                        MenuCycle = false;
                        break;
                }
                
                Console.WriteLine("========================");
            }
            
            Console.ReadKey();
        }
    }
}
