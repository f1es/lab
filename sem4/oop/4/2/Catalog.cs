namespace films
{
    class Catalog
    {
        List<Film> filmList = new List<Film>();

        public Film GetFilmFromCatalog(int filmPosition) => filmList[filmPosition];
        public void SetFilmInCatalog(int filmPosition, Film film) { filmList[filmPosition] = film; }

        public void AddBlockedFilm()
        {

            Console.WriteLine("\tWhich constructor use?\n" +
                "[1 - deafult\n[2] - with parametrs\n[3] - copy");
            if (int.TryParse(Console.ReadLine(), out int filmChoise))
                switch (filmChoise)
                {
                    case 1:
                        filmList.Add(new BlockedFilm());
                        break;
                    case 2:
                        filmList.Add(new BlockedFilm(Film.EnterName(), Film.EnterYear(), Film.EnterType(), Film.EnterRate(), Film.EnterCountry(), BlockedFilm.EnterDescription()));
                        break;
                    case 3:
                        if (filmList.Count == 0)
                        {
                            Console.WriteLine("catalog empty");
                            break;
                        }
                        Console.WriteLine("Enter film number");
                        int.TryParse(Console.ReadLine(), out int filmPosition);
                        if (CorrectInput.InRange(0, filmList.Count - 1, filmPosition))
                        {
                            if (filmList[filmPosition] is BlockedFilm)
                            {
                                filmList.Add(new BlockedFilm((BlockedFilm)filmList[filmPosition]));
                            }
                            else filmList.Add(new FavoriteFilm((FavoriteFilm)filmList[filmPosition]));
                        }
                        else
                        {
                            Console.WriteLine("Incorrect film number");
                            break;
                        }
                        break;
                }
        }

        public void AddFavoriteFilm()
        {
            Console.WriteLine("\tWhich constructor use?\n" +
                            "[1 - deafult\n[2] - with parametrs\n[3] - copy");
            if (int.TryParse(Console.ReadLine(), out int filmChoise))
                switch (filmChoise)
                {
                    case 1:
                        filmList.Add(new FavoriteFilm());
                        break;
                    case 2:
                        filmList.Add(new FavoriteFilm(Film.EnterName(), Film.EnterYear(), Film.EnterType(), Film.EnterRate(), Film.EnterCountry(), FavoriteFilm.EnterDescription()));
                        break;
                    case 3:
                        if (filmList.Count == 0)
                        {
                            Console.WriteLine("catalog empty");
                            break;
                        }
                        Console.WriteLine("Enter film number");
                        int.TryParse(Console.ReadLine(), out int filmPosition);
                        if (CorrectInput.InRange(0, filmList.Count - 1, filmPosition))
                        {
                            if (filmList[filmPosition] is FavoriteFilm)
                            {
                                filmList.Add(new FavoriteFilm((FavoriteFilm)filmList[filmPosition]));
                            }
                            else filmList.Add(new BlockedFilm((BlockedFilm)filmList[filmPosition]));
                        }
                        else
                        {
                            Console.WriteLine("Incorrect film number");
                            break;
                        }
                        break;
                }
        }
        
        public void EditFilm()
        {
            if (filmList.Count == 0)
            {
                Console.WriteLine("catalog empty");
                return;
            }
            Console.WriteLine("Enter film number");
            int.TryParse(Console.ReadLine(), out int filmPosition);
            if (CorrectInput.InRange(0, filmList.Count - 1, filmPosition)) filmList[filmPosition].Edit();
            else Console.WriteLine("Incorrect input");
        }

        public void RemoveFromCatalog() 
        {
            if (isEmpty())
            {
                Console.WriteLine("Catalog empty");
                return;
            }

            Console.Write("Enter film number: ");
            int.TryParse(Console.ReadLine(), out int position);

            if (CorrectInput.InRange(0, filmList.Count - 1, position))
            {
                filmList.RemoveAt(position);
                GC.Collect();
            }
            else
            {
                Console.WriteLine("Film with this number not found");
                return;
            }
        }

        public void GetInfoFromPosition(int filmPosition) { filmList[filmPosition].SeeInfo(); }

        public void SearchFilm() 
        {
            if (isEmpty())
            {
                Console.Write("Catalog empty");
                return;
            }

            Console.WriteLine("How you want to search?");
            Console.WriteLine("[1] - Name\n[2] - Year\n[3] - Type\n[4] - Rating\n[5] - Country.");

            int.TryParse(Console.ReadLine(), out int choise);

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

            Console.WriteLine("[1] - <\n[2] - >");
            int chose = Convert.ToInt32(Console.ReadLine());

            foreach (Film film in filmList)
            {
                if(film.GetRate() > rate && chose == 1) film.SeeInfo();
                if(film.GetRate() > rate && chose == 2) film.SeeInfo();
            }
        }

        public void SeeAll() 
        {
            Console.WriteLine("========================");
            for (int i = 0; i < filmList.Count; i++)
            {
                Console.Write(i + ".");
                filmList[i].SeeInfo();
                Console.WriteLine(" ");
            }
        }

        public bool isEmpty()
        {
            if (filmList.Count == 0) return true;
            else return false;
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