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

            Film da = new Film();

            bool MenuCycle = true;
            while (MenuCycle)
            {
                Console.WriteLine("Select operation");
                Console.WriteLine("[1] - add\n[2] - delete\n[3] - edit\n[4] - search films\n[5] - info all\n[6] - sort\n[7] - make copies");

               // int choise = Convert.ToInt32(Console.ReadLine());
                int.TryParse(Console.ReadLine(), out int choise);

                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Which constructor use to add a film?\n[1] - with parametrs\n[2] - without parametrs");
                        int.TryParse(Console.ReadLine(), out int choiseConstructor);
                        switch (choiseConstructor)
                        {
                            case 1:
                                catalog.AddToCatalogUsingConstructorWithParametrs();
                                break;
                            case 2:
                                catalog.AddToCatalogUsingConstructorWithoutParametrs();
                                break;
                        }
                        break;
                    case 2:
                        catalog.RemoveFromCatalog();
                        break;
                    case 3:
                        Console.Write("Enter film posotion:");
                        int.TryParse(Console.ReadLine(), out int position);

                        if (catalog.GetFilmList().Count == 0)
                        {
                            Console.WriteLine("Catalog is empty");
                            break;
                        }

                        if (position < 0 || position > catalog.GetFilmList().Count)
                        {
                            Console.WriteLine("Film with this number not found");
                            break;
                        }

                        Film editableFilm = catalog.GetFilmFromCatalog(position);
                        editableFilm.Edit();
                        catalog.SetFilmInCatalog(position, editableFilm);
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
                    case 8:
                        MenuCycle = false;
                        break;
                }
                
                Console.WriteLine("========================");
            }
            
            Console.ReadKey();
        }
    }
}
