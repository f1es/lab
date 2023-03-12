using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;

namespace da
{
   class help
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
                if (c == '.') return false;
            }
            return true;
        }

    }

    class Program
    {
        static void Main()
        {
            Catalog catalog = new Catalog();
            //Film kino = new Film();

            while (true)
            {
                int choise = 0;
                //Film kino = new Film();
                Console.WriteLine("Select operation");
                Console.WriteLine("[1] - add\n[2] - delete\n[3] - edit\n[4] - search films\n[5] - info all\n[6] - sort");

                choise = Convert.ToInt32(Console.ReadLine());

                string name;
                int pos;
                switch (choise)
                {
                    case 1:
                        Film kino = new Film();
                        catalog.AddToCatalog(kino);
                        break;
                    case 2:
                        try
                        {
                            catalog.RemoveFromCatalog();
                        }
                        catch
                        {
                            Console.WriteLine("Film not found");
                        }
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
                }

                Console.WriteLine("========================");
            }
        }
    }
}
