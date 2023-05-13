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
            int.TryParse(Console.ReadLine(), out int arrayLength);

            Template<int> intArray = new Template<int>(arrayLength); ;
            Template<char> charArray = new Template<char>(arrayLength); ;
            Template<FavoriteFilm> favoriteFilmArray = new Template<FavoriteFilm>(arrayLength); ;
            Template<BlockedFilm> blockedFilmArray = new Template<BlockedFilm>(arrayLength); ;

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
                Console.WriteLine("\tSelect operation\n" +
                "[1] - add\n" +
                "[2] - info all\n" +
                "[3] - delete\n" +
                "[4] - edit\n" +
                "[5] - search film\n" +
                "[6] - sort\n" +
                "[7] - operators" +
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



                        if (int.TryParse(Console.ReadLine(), out int templateChoise))
                        {
                            switch (templateChoise)
                            {
                                case 1:
                                    if (int.TryParse(Console.ReadLine(), out int setArrayTypeChoise))
                                    {
                                        int.TryParse(Console.ReadLine(), out int index);
                                        switch (setArrayTypeChoise)
                                        {
                                            case 1:
                                                int.TryParse(Console.ReadLine(), out int intElement);
                                                intArray.SetToIndex(index, intElement);
                                                break;
                                            case 2:
                                                char.TryParse(Console.ReadLine(), out char charElement);
                                                charArray.SetToIndex(index, charElement);
                                                break;
                                            case 3:
                                                FavoriteFilm film = new FavoriteFilm();
                                                favoriteFilmArray.SetToIndex(index, film);
                                                break;
                                            case 4:
                                                BlockedFilm blockedFilm = new BlockedFilm();
                                                blockedFilmArray.SetToIndex(index, blockedFilm);
                                                break;
                                        }
                                    }
                                    break;

                                  case 2:
                                    if (int.TryParse(Console.ReadLine(), out int maxChoise))
                                        switch (maxChoise)
                                        {
                                            case 1:
                                                intArray.max();
                                                break;
                                            case 2:
                                                charArray.max();
                                                break;
                                            case 3:
                                                favoriteFilmArray.max();
                                                break;
                                            case 4:
                                                blockedFilmArray.max();
                                                break;
                                        }
                                    break;

                                  case 3:
                                    if (int.TryParse(Console.ReadLine(), out int minChoise))
                                        switch (minChoise)
                                        {
                                            case 1:
                                                intArray.min();
                                                break;
                                            case 2:
                                                charArray.min();
                                                break;
                                            case 3:
                                                favoriteFilmArray.min();
                                                break;
                                            case 4:
                                                blockedFilmArray.min();
                                                break;
                                        }
                                        break;

                                  case 4:
                                    if (int.TryParse(Console.ReadLine(), out int getArrayTypeChoise))
                                    {
                                        int.TryParse(Console.ReadLine(), out int index);
                                        switch (getArrayTypeChoise)
                                        {
                                            case 1:
                                                intArray.GetFromIndex(index);
                                                break;
                                            case 2:
                                                charArray.GetFromIndex(index);
                                                break;
                                            case 3:
                                                favoriteFilmArray.GetFromIndex(index);
                                                break;
                                            case 4:
                                                blockedFilmArray.GetFromIndex(index);
                                                break;
                                        }
                                    }
                                    break;

                                case 5:
                                    if (int.TryParse(Console.ReadLine(), out int sortChoise))
                                        switch (sortChoise)
                                        {
                                            case 1:
                                                intArray.max();
                                                break;
                                            case 2:
                                                charArray.max();
                                                break;
                                            case 3:
                                                favoriteFilmArray.max();
                                                break;
                                            case 4:
                                                blockedFilmArray.max();
                                                break;
                                        }
                                    break;
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
