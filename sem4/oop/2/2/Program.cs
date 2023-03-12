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
            }
            return true;
        }

        static void Main()
        {
            Catalog catalog = new Catalog();
            

            while (true)
            {
                Console.WriteLine("Select operation");
                Console.WriteLine("[1] - add\n[2] - delete\n[3] - edit\n[4] - search films\n[5] - info all\n[6] - sort\n[7] - make copies");

               // int choise = Convert.ToInt32(Console.ReadLine());
                int.TryParse(Console.ReadLine(), out int choise);

                switch (choise)
                {
                    case 1:
                        Film kino = new Film();
                        catalog.AddToCatalog(kino);
                        break;
                    case 2:
                        catalog.RemoveFromCatalog();
                        break;
                    case 3:
                        Console.Write("Enter film posotion:");
                        int.TryParse(Console.ReadLine(), out int position);

                        List<Film> temp = catalog.GetFilmList();
                        temp[position].Edit();
                        catalog.SetFilmList(temp);
                        break;
                    case 4:
                        catalog.SearchFilm();
                        break;
                    case 5:
                        catalog.SeeAll();
                        break;
                    case 6:
                        catalog.SortFilms();
                        break;
                    case 7: //laba 2
                        int filmNumber;
                        while(true)
                        {
                            Console.Write("Enter copy film number:");
                            if (int.TryParse(Console.ReadLine(), out filmNumber) == true) 
                                if(filmNumber <= catalog.GetFilmList().Count) break;
                            Console.WriteLine("Incorrect input, try again");
                        }

                        Console.Write("Enter count of copies:");
                        int.TryParse(Console.ReadLine(), out int copiesCount);
                        catalog.CopyFilm(catalog.GetFilmList()[filmNumber], copiesCount);
                        break;
                }
                
                Console.WriteLine("========================");
                //Console.Clear();
            }
        }
    }
}
