namespace da
{
    class Film
    {
        public string Name{ get; set; }
        private int Year { get; set; }
        private int Rate { get; set; }
        private string Type { get; set; }

        void addName()
        {
            Console.Write("Enter film name: ");
            Name = Console.ReadLine();
        }

        void addYear()
        {
            Console.Write("Enter film year: ");
            Year = Convert.ToInt32(Console.ReadLine());
        }

        void addType()
        {
            Console.Write("Enter film type: ");
            Type = Console.ReadLine();
        }
        void addRate()
        {
            Console.Write("Enter film rate: ");
            Rate = Convert.ToInt32(Console.ReadLine());
        }
        public void addFilm()
        {
            addName();
            addYear();
            addType();
            addRate();
        }

        public void editFilm()
        {
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("[1] - Name, [2] - Year, [3] - Type, [4] - Rate.");
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
            }
        }
        public void infoFilm()
        {
            Console.WriteLine("Film: " + Name);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Rate: " + Rate);
        }
    }

    class filmCatalog
    {
        List<Film> filmList = new List<Film>();
        //string search { get; set; }


        public void addToCatalog(Film F)
        {
            filmList.Add(F);
        }

        public void removeFromCatalog(int pos)
        {
            filmList.RemoveAt(pos);
        }

        public int searchFilm(string Name)
        {
            List<Film> temp = new List<Film>();
            //temp = filmList;


            int counter = 0;
            while (counter < filmList.Count)
            {
                if (filmList[counter].Name == Name) return counter;
                //filmList.RemoveAt(0);
                counter++;
            }
            return -1;
        }
    }
    class Program
    {
        static void Main()
        {
            filmCatalog catalog = new filmCatalog();

            Film kino = new Film();
            Film kino2 = new Film();

            kino.addFilm();
            kino2.addFilm();

            catalog.addToCatalog(kino);
            catalog.addToCatalog(kino2);

            Console.WriteLine("entr srch name - "); string sn = Console.ReadLine();
            int pos = catalog.searchFilm(sn);


            catalog.removeFromCatalog(pos);
            //kino.infoFilm();
           // kino.editFilm();
           // kino.infoFilm();
        }
    }
}


