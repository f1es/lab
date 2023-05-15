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
            Template<char> charArray = new Template<char>(5); 
            Template<FavoriteFilm> favoriteFilmArray = new Template<FavoriteFilm>(5); 
            Template<BlockedFilm> blockedFilmArray = new Template<BlockedFilm>(5); 

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

                        Console.WriteLine("\tSelect template operation\n" +
                            "[1] - set array element\n" +
                            "[2] - max array element\n" +
                            "[3] - min array element\n" +
                            "[4] - get array element\n" +
                            "[5] - sort array\n"); 
                            //"[6] - see arrays");

                        if (int.TryParse(Console.ReadLine(), out int templateChoise))
                        {
                            switch (templateChoise)
                            {
                                case 1:
                                    Console.WriteLine("\tSelect array\n" + 
                                        "[1] - Integer array\n" + 
                                        "[2] - Char array\n" + 
                                        "[3] - Favorite film array\n" + 
                                        "[4] - Blocked film array\n");
                                    if (int.TryParse(Console.ReadLine(), out int setArrayTypeChoise))
                                    {
                                        Console.WriteLine("Enter element index");
                                        int.TryParse(Console.ReadLine(), out int index);
                                        switch (setArrayTypeChoise)
                                        {
                                            case 1:
                                                Console.WriteLine("Enter number");
                                                int.TryParse(Console.ReadLine(), out int intElement);
                                                intArray.SetToIndex(index, intElement);
                                                break;
                                            case 2:
                                                Console.WriteLine("Enter symbol");
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
                                    Console.WriteLine("\tSelect array\n" +
                                        "[1] - Integer array\n"
                                        + "[2] - Char array\n"
                                        + "[3] - Favorite film array\n"
                                        + "[4] - Blocked film array\n");
                                    if (int.TryParse(Console.ReadLine(), out int maxChoise))
                                        switch (maxChoise)
                                        {
                                            case 1:
                                                Console.WriteLine(intArray.max());
                                                break;
                                            case 2:
                                                Console.WriteLine(charArray.max());
                                                break;
                                            case 3:
                                                favoriteFilmArray.max().SeeInfo();
                                                break;
                                            case 4:
                                                blockedFilmArray.max().SeeInfo();
                                                break;
                                        }
                                    break;

                                  case 3:
                                    if (int.TryParse(Console.ReadLine(), out int minChoise))
                                        switch (minChoise)
                                        {
                                            case 1:
                                                Console.WriteLine(intArray.min());
                                                break;
                                            case 2:
                                                Console.WriteLine(charArray.min());
                                                break;
                                            case 3:
                                                favoriteFilmArray.min().SeeInfo();
                                                break;
                                            case 4:
                                                blockedFilmArray.min().SeeInfo();
                                                break;
                                        }
                                        break;

                                  case 4:
                                    Console.WriteLine("\tSelect array\n" +
                                    "[1] - Integer array\n" +
                                    "[2] - Char array\n" +
                                    "[3] - Favorite film array\n" +
                                    "[4] - Blocked film array\n");
                                    if (int.TryParse(Console.ReadLine(), out int getArrayTypeChoise))
                                    {
                                        Console.WriteLine("Enter element index");
                                        int.TryParse(Console.ReadLine(), out int index);
                                        switch (getArrayTypeChoise)
                                        {
                                            case 1:
                                                Console.WriteLine(intArray.GetFromIndex(index));
                                                break;
                                            case 2:
                                                Console.WriteLine(charArray.GetFromIndex(index));
                                                break;
                                            case 3:
                                                //Console.WriteLine(favoriteFilmArray.GetFromIndex(index));
                                                favoriteFilmArray.GetElement(index).SeeInfo();
                                                break;
                                            case 4:
                                                //Console.WriteLine(blockedFilmArray.GetFromIndex(index));
                                                blockedFilmArray.GetElement(index).SeeInfo();
                                                break;
                                        }
                                    }
                                    break;

                                case 5:
                                    Console.WriteLine("\tSelect array\n" +
                                    "[1] - Integer array\n" +
                                    "[2] - Char array\n" +
                                    "[3] - Favorite film array\n" +
                                    "[4] - Blocked film array\n");
                                    if (int.TryParse(Console.ReadLine(), out int sortChoise))
                                        switch (sortChoise)
                                        {
                                            case 1:
                                                intArray.Sort();
                                                break;
                                            case 2:
                                                charArray.Sort();
                                                break;
                                            case 3:
                                                favoriteFilmArray.Sort();
                                                break;
                                            case 4:
                                                blockedFilmArray.Sort();
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
