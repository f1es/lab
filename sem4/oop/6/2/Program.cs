using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Sockets;
using System.Reflection;
using System.Xml.Linq;

namespace films
{
    class Program
    {
        static void Main()
        {   
            Catalog catalog = new Catalog();
            bool MenuCycle = true;
            while (MenuCycle)
            {
                Console.WriteLine("\tSelect operation\n" +
                "[1] - add\n" +
                "[2] - info all\n" +
                "[3] - delete\n" +
                "[4] - edit\n" +
                "[5] - search film\n" +
                "[6] - sort\n" +
                "[7] - operators");

                int.TryParse(Console.ReadLine(), out int choise);
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("\tSelect film to add\n" +
                        "[1] - favorite\n" +
                        "[2] - blocked");
                        if(int.TryParse(Console.ReadLine(), out int filmChoise))
                        switch(filmChoise)
                        {
                            case 1:
                                    catalog.AddFavoriteFilm();
                                    break;
                            case 2:
                                    catalog.AddBlockedFilm();
                                    break;
                        }
                        break;
                    case 2:
                        if (catalog.isEmpty())
                        {
                            Console.WriteLine("Catalog empty");
                            break;
                        }
                        catalog.SeeAll();
                        break;
                    case 3:
                        catalog.RemoveFromCatalog();
                        break;
                    case 4:
                        catalog.EditFilm();
                        break;
                    case 5:
                        catalog.SearchFilm();
                        break;
                    case 6:
                        catalog.SortFilms();
                        break;
                    case 7:
                        catalog.UseOperators(catalog);
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
