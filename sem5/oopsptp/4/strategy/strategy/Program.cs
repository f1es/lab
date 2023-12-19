class Program
{
    static void Main()
    {
        List<Cinema> catalog = new List<Cinema>();
        catalog.Add(new Cinema(new Text()));
        catalog.Add(new Cinema(new XML()));

        catalog[0].Set("KINO", 2001, 4);
        catalog[1].Set("FILM", 1999, 5);
        catalog[0].Output();
        catalog[1].Output();
    }
}