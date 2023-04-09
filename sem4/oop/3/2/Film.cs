namespace films
{
    class Film
    {
        private string _name;
        private int _year;
        private int _rate;
        private string _type;
        private string _country;

        public Film()
        {
            Console.WriteLine("Constructor without parametrs is called");
            SetName(EnterName());
            SetYear(EnterYear());
            SetType(EnterType());
            SetRate(EnterRate());
            SetCountry(EnterCountry());
        }
        public Film(Film film)
        {
            _name = film._name;
            _year = film._year;
            _type = film._type;
            _rate = film._rate;
            _country = film._country;
            Console.WriteLine("Copy constructor was called");
        }

        public Film(string name, int year, string type, int rate, string country)
        {
            Console.WriteLine("Constructor with parametrs was called");
            _name = name;
            _year = year;
            _type = type;
            _rate = rate;
            _country = country;
        }

        ~Film()
        {
            Console.WriteLine("Destructor was called");
        }

        public string GetName() => _name;
        public int GetYear() => _year;
        public int GetRate() => _rate;
        public string GetType() => _type;
        public string GetCountry() => _country;
        public void SetName(string name) { _name = name; }
        public void SetYear(int year) { _year = year; }
        public void SetType(string type) {_type = type; }
        public void SetRate(int rate) { _rate = rate; }
        public void SetCountry(string country) { _country = country; }

        public static string EnterName()
        {
            Console.Write("Enter film name: ");
            string name = Console.ReadLine();
            while(true)
            {
                if(name != "")
                {
                    return name;
                }
                    
            }
        }

        public static int EnterYear()
        {
            while (true)
            {
                Console.Write("Enter film year: ");
                int.TryParse(Console.ReadLine(), out int year);
                if (CorrectInput.InRange(1927, 2023, year))
                {
                    return year;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public static string EnterType()
        {
            while (true)
            {
                Console.Write("Enter film type: ");
                string type = Console.ReadLine();
                if (CorrectInput.IsOnlyLetters(type))
                {
                    return type;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }
        public static int EnterRate()
        {
            while (true)
            {
                Console.Write("Enter film rating(0-100): ");
                bool check = int.TryParse(Console.ReadLine(), out int rate);
                if (CorrectInput.InRange(0, 100, rate) && check)
                {
                    return rate;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }
        public static string EnterCountry()
        {
            while (true)
            {
                Console.Write("Enter film country: ");
                string country = Console.ReadLine();
                if (CorrectInput.IsOnlyLetters(country))
                {
                    return country;
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
                    SetName(EnterName());
                    break;
                case 2:
                    SetYear(EnterYear());
                    break;
                case 3:
                    SetType(EnterType());
                    break;
                case 4:
                    SetRate(EnterRate());
                    break;
                case 5:
                    SetCountry(EnterCountry());
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