

namespace da
{
    class Film
    {
        Program h = new Program();

        private string Name; 
        private int Year;
        private int Rate;
        private string Type;
        private string Country;

        public string GetName() => Name;
        public int GetYear() => Year;
        public int GetRate() => Rate;
        public string GetType() => Type;
        public string GetCountry() => Country;

        public void SetName()
        {
            Console.Write("Enter film name: ");
            Name = Console.ReadLine();
        }

        public void SetYear()
        {
            while (true)
            {
                Console.Write("Enter film year: ");
                int.TryParse(Console.ReadLine(), out int year);
                if (year <= 2023 && year >= 1927)
                {
                    Year = year;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public void SetType()
        {
            while(true)
            {
                Console.Write("Enter film type: ");
                string type = Console.ReadLine();
                if (h.IsOnlyLetters(type) == true)
                {
                    Type = type;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }
        public void SetRate()
        {
            while(true)
            {
                Console.Write("Enter film rating(0-100): ");
                bool check = int.TryParse(Console.ReadLine(), out int rate);
                if (rate <= 100 && rate >= 0 && check == true) 
                { 
                    Rate = rate;
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
                if (h.IsOnlyLetters(country) == true)
                {
                    Country = country;
                    break;
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public Film()
        {
            SetName();
            SetYear();
            SetType();
            SetRate();
            SetCountry(); 
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
            Console.WriteLine("\tFilm: " + Name);
            Console.WriteLine("\tYear: " + Year);
            Console.WriteLine("\tType: " + Type);
            Console.WriteLine("\tRating: " + Rate);
            Console.WriteLine("\tCountry: " + Country);
        }
    }

}