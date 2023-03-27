namespace FilmsCatalog
{
    class Film
    {
        private string _name;
        private int _year;
        private int _rate;
        private string _type;
        private string _country;

        public Film() //конструктор без параметров
        {
            Console.WriteLine("Constructor without parametrs is called");
            SetName();
            SetYear();
            SetType();
            SetRate();
            SetCountry();
        }

        public Film(string name, int year, string type, int rate, string country) //конструктор с параметрами
        {
            Console.WriteLine("Constructor with parametrs was called");
            _name = name;
            _year = year;
            _type = type;
            _rate = rate;
            _country = country;
        }

        public Film(Film film) //конструктор копирования
        {
            _name = film._name;
            _year = film._year;
            _type = film._type;
            _rate = film._rate;
            _country = film._country;
            Console.WriteLine("Copy constructor was called");
        }

        ~Film() //деструктор
        {
            Console.WriteLine("Destructor was called");
        }


        public string GetName() => _name;
        public int GetYear() => _year;
        public int GetRate() => _rate;
        public string GetType() => _type;
        public string GetCountry() => _country;

        public void SetName()
        {
            Console.Write("Enter film name: ");
            _name = Console.ReadLine();
        }

        public void SetYear()
        {
            while (true)
            {
                Console.Write("Enter film year: ");
                int.TryParse(Console.ReadLine(), out int year);
                if (CorrectInputTests.InRange(1927, 2023, year))
                {
                    _year = year;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public void SetType()
        {
            while (true)
            {
                Console.Write("Enter film type: ");
                string type = Console.ReadLine();
                if (CorrectInputTests.IsOnlyLetters(type) && type != "")
                {
                    _type = type;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }
        public void SetRate()
        {
            while (true)
            {
                Console.Write("Enter film rating(0-100): ");
                int.TryParse(Console.ReadLine(), out int rate);
                if (CorrectInputTests.InRange(0,100,rate))
                {
                    _rate = rate;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }
        public void SetCountry()
        {
            while (true)
            {
                Console.Write("Enter film country: ");
                string country = Console.ReadLine();
                if (CorrectInputTests.IsOnlyLetters(country) && country != "")
                {
                    _country = country;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public void Edit()
        {
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("[1] - Name\n[2] - Year\n[3] - Type\n[4] - Rating\n[5] - Country.");
            int edit = Convert.ToInt32(Console.ReadLine());
            switch (edit)
            {
                case 1:
                    SetName();
                    break;
                case 2:
                    SetYear();
                    break;
                case 3:
                    SetType();
                    break;
                case 4:
                    SetRate();
                    break;
                case 5:
                    SetCountry();
                    break;
            }
        }

        public void SeeInfo()
        {
            Console.WriteLine("\tFilm: " + _name);
            Console.WriteLine("\tYear: " + _year);
            Console.WriteLine("\tType: " + _type);
            Console.WriteLine("\tRating: " + _rate);
            Console.WriteLine("\tCountry: " + _country);
        }
    }
}