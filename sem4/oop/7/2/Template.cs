using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films
{
    class Template <T>
    {
        private T[] TArray; 
        private int ArrayLength;
        public Template(int n)
        {
            TArray = new T[n];
            ArrayLength = n;
        }

        public int GetArrayLength()
        {
            return ArrayLength;
        }

        public T GetElement(int n)
        {
            return TArray[n];
        }

        public T[] GetArray()
        {
            return TArray;
        }
        public T GetFromIndex(int index)
        {
            return TArray[index];
        }

        public void SetByIndex(int index, T element)
        {
            if (TArray.Length == 0)
            {
                EmptyListException error = new EmptyListException("Array is empty");
                Console.WriteLine($"The exception was thrown: {error.Message}");
                return;
            }
            //if (CorrectInput.InRange(0, TArray.Length - 1, index))
                TArray[index] = element;
            //else
            //    Console.WriteLine("Index was outside of array");
        }

        public int findItem(Template<T> template ,T obj)
        {
            return template == obj;
        }
        
        public void Sort()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            TArray = list.ToArray();
        }

        public T max()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            return list[list.Count - 1];
        }

        public T min()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            return list[0];
        }

        static public int operator == (Template<T> template, T secondElement)
        {
            for (int i = 0; i < template.ArrayLength; i++)
            {
                if (Object.Equals(template.TArray[i], secondElement)) 
                    return i;
            }
            return -1;
        }

        static public int operator !=(Template<T> template, T secondElement)
        {
            return -1;
        }

        static public void SeeArrays(Template<int> intArray, Template<char> charArray,
            Template<FavoriteFilm> favoriteFilmArray, Template<BlockedFilm> blockedFilmArray)
        {
            Console.Write("Int Array: ");
            for (int i = 0; i < intArray.GetArrayLength(); i++)
            {
                Console.Write(intArray.GetFromIndex(i) + ", ");
            }
            Console.WriteLine("");

            Console.Write("Char Array: ");
            for (int i = 0; i < charArray.GetArrayLength(); i++)
            {
                Console.Write(charArray.GetFromIndex(i) + ", ");
            }
            Console.WriteLine("");

            Console.WriteLine("\t\tfavorite films Array:");
            for (int i = 0; i < favoriteFilmArray.GetArrayLength(); i++)
            {
                favoriteFilmArray.GetFromIndex(i).SeeInfo();
                Console.WriteLine("");
            }

            Console.WriteLine("\t\tblocked films Array:");
            for (int i = 0; i < blockedFilmArray.GetArrayLength(); i++)
            {
                blockedFilmArray.GetFromIndex(i).SeeInfo();
                Console.WriteLine("");
            }
        }

        static public bool templateMenu(Template<int> intArray, Template<char> charArray,
            Template<FavoriteFilm> favoriteFilmArray, Template<BlockedFilm> blockedFilmArray)
        {
            Console.WriteLine("\tSelect template operation\n" +
                            "[1] - set array element\n" +
                            "[2] - max array element\n" +
                            "[3] - min array element\n" +
                            "[4] - get array element\n" +
                            "[5] - sort array\n" +
                            "[6] - other operations\n" +
                            "[7] - see all arrays");

            if (int.TryParse(Console.ReadLine(), out int templateChoise))
            {
                try
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
                                        intArray.SetByIndex(index, intElement);
                                        return true;
                                    case 2:
                                        Console.WriteLine("Enter symbol");
                                        char.TryParse(Console.ReadLine(), out char charElement);
                                        charArray.SetByIndex(index, charElement);
                                        return true;
                                    case 3:
                                        FavoriteFilm film = new FavoriteFilm();
                                        favoriteFilmArray.SetByIndex(index, film);
                                        return true;
                                    case 4:
                                        BlockedFilm blockedFilm = new BlockedFilm();
                                        blockedFilmArray.SetByIndex(index, blockedFilm);
                                        return true;
                                }
                            }
                            return true;

                        case 2:
                            Console.WriteLine("\tSelect array\n"
                                + "[1] - Integer array\n"
                                + "[2] - Char array\n"
                                + "[3] - Favorite film array\n"
                                + "[4] - Blocked film array\n");
                            if (int.TryParse(Console.ReadLine(), out int maxChoise))
                                switch (maxChoise)
                                {
                                    case 1:
                                        Console.WriteLine(intArray.max());
                                        return true;
                                    case 2:
                                        Console.WriteLine(charArray.max());
                                        return true;
                                    case 3:
                                        favoriteFilmArray.max().SeeInfo();
                                        return true;
                                    case 4:
                                        blockedFilmArray.max().SeeInfo();
                                        return true;
                                }
                            return true;

                        case 3:
                            Console.WriteLine("\tSelect array\n"
                                + "[1] - Integer array\n"
                                + "[2] - Char array\n"
                                + "[3] - Favorite film array\n"
                                + "[4] - Blocked film array\n");
                            if (int.TryParse(Console.ReadLine(), out int minChoise))
                                switch (minChoise)
                                {
                                    case 1:
                                        Console.WriteLine(intArray.min());
                                        return true;
                                    case 2:
                                        Console.WriteLine(charArray.min());
                                        return true;
                                    case 3:
                                        favoriteFilmArray.min().SeeInfo();
                                        return true;
                                    case 4:
                                        blockedFilmArray.min().SeeInfo();
                                        return true;
                                }
                            return true;

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
                                        //if (CorrectInput.InRange(0, intArray.GetArrayLength() - 1, index))
                                            Console.WriteLine(intArray.GetFromIndex(index));
                                        //else
                                        //    Console.WriteLine("Incorrect array index");
                                        return true;

                                    case 2:
                                        //if (CorrectInput.InRange(0, charArray.GetArrayLength() - 1, index))
                                            Console.WriteLine(charArray.GetFromIndex(index));
                                        //else
                                        //    Console.WriteLine("Incorrect array index");
                                        return true;

                                    case 3:
                                        //if (CorrectInput.InRange(0, favoriteFilmArray.GetArrayLength() - 1, index))
                                            favoriteFilmArray.GetElement(index).SeeInfo();
                                        //else
                                        //    Console.WriteLine("Incorrect array index");
                                        return true;

                                    case 4:
                                        //if (CorrectInput.InRange(0, blockedFilmArray.GetArrayLength() - 1, index))
                                            blockedFilmArray.GetElement(index).SeeInfo();
                                        //else
                                        //    Console.WriteLine("Incorrect array index");
                                        return true;
                                }
                            }
                            return true;

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
                                        return true;
                                    case 2:
                                        charArray.Sort();
                                        return true;
                                    case 3:
                                        favoriteFilmArray.Sort();
                                        return true;
                                    case 4:
                                        blockedFilmArray.Sort();
                                        return true;
                                }
                            return true;

                        case 6:
                            return false;

                        case 7:
                            Template<int>.SeeArrays(intArray, charArray, favoriteFilmArray, blockedFilmArray);
                            return true;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine($"The exception was thrown: {error.Message}");
                }
            }
            return true;
        }
    }
}
