namespace da
{
    class Catalog
    {
        List<Film> filmList = new List<Film>();

        public List<Film> GetFilmList()
        {
            return filmList;
        }

        public void SetFilmList(List<Film> List)
        {
            filmList = List;
        }

        public void AddToCatalog(Film film)
        {
            filmList.Add(film);
        }

        public void RemoveFromCatalog()
        {
            Console.Write("Enter film number: ");
            int.TryParse(Console.ReadLine(), out int position);
            filmList.RemoveAt(position);
        }

        public int SearchFilmPosition(string name)
        {

            int counter = 0;
            foreach (Film film in filmList)
            {
                if (film.GetName() == name) return counter;
            }
            return -1;
        }

        public int SearchFilmPosition(int year)
        {
            int counter = 0;
            foreach (Film film in filmList)
            {
                if (film.GetYear() == year) return counter;
            }
            return -1;
        }

        public void GetInfoFromPosition(int filmPosition)
        {
            filmList[filmPosition].SeeInfo();
        }

        public void SearchFilm()
        {
            Console.WriteLine("How you want to search?");
            Console.WriteLine("[1] - Name\n[2] - Year\n[3] - Type\n[4] - Rating\n[5] - Country.");
            int choise = 0;
            int counter = 0;

            int.TryParse(Console.ReadLine(), out choise);

            switch (choise)
            {
                case 1:
                    SearchName();
                    break;
                case 2:
                    SearchYear();
                    break;
                case 3:
                    SearchType();
                    break;
                case 4:
                    SeatchRate();
                    break;
                case 5:
                    SearchCounrty();
                    break;
            }
        }

        public void SearchCounrty()
        {
            Console.WriteLine("Enter country");
            string Country = Console.ReadLine();

            for (int i = 0; i < filmList.Count; i++)
            {
                if (filmList[i].GetCountry() == Country)
                {
                    Console.Write(i + ".");
                    filmList[i].SeeInfo();
                }
            }
        }

        public void SearchType()
        {
            Console.WriteLine("Enter type");
            string Type = Console.ReadLine();

            for (int i = 0; i < filmList.Count; i++)
            {
                if (filmList[i].GetType() == Type)
                {
                    Console.Write(i + ".");
                    filmList[i].SeeInfo();
                }
            }
        }

        public void SearchName()
        {
            Console.WriteLine("Enter name");
            string Name = Console.ReadLine();

            for (int i = 0; i < filmList.Count; i++)
            {
                if (filmList[i].GetName().IndexOf(Name) != -1)
                {
                    Console.Write(i + ".");
                    filmList[i].SeeInfo();
                }
            }
        }

        public void SearchYear()
        {
            Console.WriteLine("Enter year");
            int.TryParse(Console.ReadLine(), out int year);
            Console.WriteLine("[1] - >\n[2] - <");
            int.TryParse(Console.ReadLine(), out int choise);


            for (int i = 0; i < filmList.Count; i++)
            {
                if (filmList[i].GetYear() > year && choise == 1)
                {
                    Console.Write(i + ".");
                    filmList[i].SeeInfo();
                }

                if (filmList[i].GetYear() < year && choise == 2)
                {
                    Console.Write(i + ".");
                    filmList[i].SeeInfo();
                }
            }
        }

        public void SeatchRate()
        {
            Console.WriteLine("Enter search rating(0-100)");
            int rate;
            while(true)
            {
                int.TryParse(Console.ReadLine(), out rate);
                if (rate < 100 && rate > 0) break;
                Console.WriteLine("Incorrect input, try again");
            }

            Console.WriteLine("[1] - <, [2] - >.");
            int chose = Convert.ToInt32(Console.ReadLine());
            while(true)
            {
                int.TryParse(Console.ReadLine(), out chose);
                if (chose == 1 || chose == 2) break;
                Console.WriteLine("Incorrect input, try again");
            }

            foreach (Film film in filmList)
            {
                if(film.GetRate() > rate && chose == 1) film.SeeInfo();
                if(film.GetRate() > rate && chose == 2) film.SeeInfo();
            }
        }

        public void SeeAll()
        {
            Console.WriteLine("========================");
            int counter = 0;
            for (int i = 0; i < filmList.Count; i++)
            {
                Console.Write(i + ".");
                filmList[i].SeeInfo();
                Console.WriteLine(" ");
            }
        }

        public void SortFilms()
        {
            int choise = 0;
            Console.WriteLine("How you want to sort?");
            Console.WriteLine("[1] - Year\n[2] - Rating.");

            try
            {
                choise = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            switch (choise)
            {
                case 1:
                    for (int i = 0; i < filmList.Count; i++)
                        for (int j = 0; j < filmList.Count; j++)
                        {
                            if (filmList[i].GetYear() < filmList[j].GetYear())
                            {
                                Film temp = filmList[i];
                                filmList[i] = filmList[j];
                                filmList[j] = temp;
                            }
                        }
                    break;
                case 2:
                    for (int i = 0; i < filmList.Count; i++)
                        for (int j = 0; j < filmList.Count; j++)
                        {
                            if (filmList[i].GetRate() < filmList[j].GetRate())
                            {
                                Film temp = filmList[i];
                                filmList[i] = filmList[j];
                                filmList[j] = temp;
                            }
                        }
                    break;
            }
        }
    }
}