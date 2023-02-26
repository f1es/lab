using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;

namespace da
{
    class Film
    {
        private string Name { get; set; }
        private int Year { get; set; }
        private int Rate { get; set; }
        private string Type { get; set; }
        private string Country { get; set; }

        public string getName() => Name;
        public int getYear() => Year;
        public int getRate() => Rate;
        public string getType() => Type;
        public string getCountry() => Country;

        public void addName()
        {
            Console.Write("Enter film name: ");
            Name = Console.ReadLine();
        }

        public void addYear()
        {
            Console.Write("Enter film year: ");
            try
            {
                Year = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Incorrect input");
                Year = 0;
            }
        }

        public void addType()
        {
            Console.Write("Enter film type: ");
            try
            {
                Type = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Incorrect input");
                Type = "-";
            }
        }
        public void addRate()
        {
            Console.Write("Enter film rate: ");
            try
            {
                Rate = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Incorrect input");
                Rate = 0;
            }
        }
        public void addCountry()
        {
            Console.Write("Enter film country: ");
            try
            {
                Country = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Incorrect input");
                Country = "-";
            }
        }

        public void addFilm()
        {
            addName();
            addYear();
            addType();
            addRate();
            addCountry();
        }

        public void editFilm()
        {
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("[1] - Name, [2] - Year, [3] - Type, [4] - Rate, [5] - Country.");
            int edit = Convert.ToInt32(Console.ReadLine());
            switch (edit)
            {
                case 1:
                    addName();
                    break;
                case 2:
                    addYear();
                    break;
                case 3:
                    addType();
                    break;
                case 4:
                    addRate();
                    break;
                case 5:
                    addCountry();
                    break;
            }
        }
        public void seeFilmInfo()
        {
            Console.WriteLine("Film: " + Name);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Rate: " + Rate);
            Console.WriteLine("Country: " + Country);
            Console.WriteLine("-------------------------");
        }
    }

    class filmCatalog
    {
        List<Film> filmList = new List<Film>();

        public List<Film> getFilmList()
        {
            return filmList;
        }

        public void setFilmList(List<Film> fl)
        {
            filmList = fl;
        }

        public void addToCatalog(Film F)
        {
            filmList.Add(F);
        }

        public void removeFromCatalog(string name)
        {
            int pos = searchFilmPos(name);
            filmList.RemoveAt(pos);
        }

        public int searchFilmPos(string Name)
        {
            int counter = 0;
            while (counter < filmList.Count)
            {
                if (filmList[counter].getName() == Name) return counter;
                counter++;
            }
            return -1;
        }

        public void search(string name)
        {
            int counter = 0;
            while (filmList.Count > counter)
            {
                if (filmList[counter].getName() == name)
                {
                    filmList[counter].seeFilmInfo();
                }
                counter++;
            }
        }

        public void search(int year)
        {
            int counter = 0;
            while (filmList.Count > counter)
            {
                if (filmList[counter].getYear() == year)
                {
                    filmList[counter].seeFilmInfo();
                }
                counter++;
            }
        }

        public void searchFilm()
        {
            Console.WriteLine("How you want to search?");
            Console.WriteLine("[1] - Name, [2] - Year, [3] - Type, [4] - Rate, [5] - Country.");
            int choise = 0;
            int counter = 0;

            choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    string Name;
                    Console.WriteLine("Enter search name");
                    Name = Console.ReadLine();
                    search(Name);
                    break;
                case 2:
                    int Year;
                    Console.WriteLine("Enter year");
                    Year = Convert.ToInt32(Console.ReadLine());
                    search(Year);
                    break;
                case 3:
                    string Type;
                    Console.WriteLine("Enter type");
                    Type = Console.ReadLine();
                    while (filmList.Count > counter)
                    {
                        if (filmList[counter].getType() == Type)
                        {
                            filmList[counter].seeFilmInfo();
                        }
                        counter++;
                    }
                    break;
                case 4:
                    int Rate;
                    Console.WriteLine("Enter search rate");
                    Rate = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("[1] - <, [2] - >.");
                    int chose = Convert.ToInt32(Console.ReadLine());

                    while (filmList.Count > counter)
                    {
                        if (filmList[counter].getRate() > Rate && chose == 2)
                        {
                            filmList[counter].seeFilmInfo();
                        }
                        if (filmList[counter].getRate() < Rate && chose == 1)
                        {
                            filmList[counter].seeFilmInfo();
                        }
                        counter++;
                    }
                    break;
                case 5:
                    string Country;
                    Console.WriteLine("Enter country");
                    Country = Console.ReadLine();
                    while (filmList.Count > counter)
                    {
                        if (filmList[counter].getCountry() == Country)
                        {
                            filmList[counter].seeFilmInfo();
                        }
                        counter++;
                    }
                    break;
            }
        }

        public void seeAll()
        {
            int counter = 0;
            while (filmList.Count > counter)
            {
                filmList[counter].seeFilmInfo();
                counter++;
            }
        }

        public void SortFilms()
        {
            Console.WriteLine("How you want to sort?");
            Console.WriteLine("[1] - Year, [2] - Rate.");
            int choise = Convert.ToInt32(Console.ReadLine());

            switch (choise)
            {
                case 1:
                    for (int i = 0; i < filmList.Count; i++)
                        for (int j = 0; j < filmList.Count; j++)
                        {
                            if (filmList[i].getYear() < filmList[j].getYear())
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
                            if (filmList[i].getRate() < filmList[j].getRate())
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
    class Program
    {
        static void Main()
        {
            filmCatalog catalog = new filmCatalog();
            //Film kino = new Film();

            while (true)
            {
                Film kino = new Film();
                Console.WriteLine("Enter operation");
                Console.WriteLine("[1] - add, [2] - delete, [3] - edit, [4] - info one, [5] - info all, [6] - sort");
                int choise = Convert.ToInt32(Console.ReadLine());

                string name;
                int pos;
                switch (choise)
                {
                    case 1:
                        kino.addFilm();
                        catalog.addToCatalog(kino);
                        break;
                    case 2:
                        Console.WriteLine("Enter film name");
                        name = Console.ReadLine();
                        catalog.removeFromCatalog(name);
                        break;
                    case 3:
                        Console.WriteLine("Enter film name");
                        name = Console.ReadLine();
                        pos = catalog.searchFilmPos(name);
                        List<Film> temp = catalog.getFilmList();
                        temp[pos].editFilm();
                        catalog.setFilmList(temp);
                        break;
                    case 4:
                        catalog.searchFilm();
                        break;
                    case 5:
                        catalog.seeAll();
                        break;
                    case 6:
                        catalog.SortFilms();
                        break;
                }
            }
        }
    }
}
