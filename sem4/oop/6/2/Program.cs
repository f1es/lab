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
            //Console.WriteLine("Enter length of templates arrays: ");
            //int.TryParse(Console.ReadLine(), out int arrayLength);

            Template<int> intArray = new Template<int>(5);

            Console.WriteLine("Input int array");
            for (int i = 0; i < intArray.GetArrayLength(); i++)
            {
                int number = 0;
                int.TryParse(Console.ReadLine(), out number);
                intArray.SetByIndex(i, number);
            }

            Template<char> charArray = new Template<char>(5);

            Console.WriteLine("Input char array");
            for (int i = 0; i < intArray.GetArrayLength(); i++)
            {
                char bykva = 'a';
                char.TryParse(Console.ReadLine(), out bykva);
                charArray.SetByIndex(i, bykva);
            }

            Template<FavoriteFilm> favoriteFilmArray = new Template<FavoriteFilm>(5);

            for (int i = 0; i < intArray.GetArrayLength(); i++)
            {
                FavoriteFilm favoriteFilm = new FavoriteFilm("FILM 1", 2003, "NORMALNYY", 99, "AFRICA", "BEST FILM EVER");
                favoriteFilmArray.SetByIndex(i, favoriteFilm);
            }

            Template<BlockedFilm> blockedFilmArray = new Template<BlockedFilm>(5);

            for (int i = 0; i < intArray.GetArrayLength(); i++)
            {
                BlockedFilm blockedFilm = new BlockedFilm("FILM 2", 2003, "NE NORMALNIY", 2, "AFRICA", "WORST FILM EVER");
                blockedFilmArray.SetByIndex(i, blockedFilm);
            }

            Template<int>.templateMenu(intArray, charArray, favoriteFilmArray, blockedFilmArray);

            //Template<int> t = new Template<int>(3);
            //t.SetToIndex(0, 2);
            //t.SetToIndex(1, 3);
            //t.SetToIndex(2, 1);
            //t.Sort();
            //Console.WriteLine(t.GetFromIndex(0));
            //Console.ReadKey();

            Catalog catalog = new Catalog();
            bool MenuCycle = true;
            while (MenuCycle)
            {
                if (Template<int>.templateMenu(intArray, charArray, favoriteFilmArray, blockedFilmArray)) continue;


                Console.WriteLine("\tSelect operation\n" +
                "[1] - add\n" +
                "[2] - info all\n" +
                "[3] - delete\n" +
                "[4] - edit\n" +
                "[5] - search film\n" +
                "[6] - sort\n" +
                "[7] - operators\n" +
                "[8] - templates");

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
                    case 8:
                        Template<int>.templateMenu(intArray, charArray, favoriteFilmArray, blockedFilmArray);
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
