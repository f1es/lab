class Program
{
    static void Main(string[] args)
    {
        List<Cinema> catalog = new List<Cinema>();
        catalog.Add(new Cinema(new Text() ));
        catalog.Add(new Cinema(new XML() ));

        catalog[0].Set();
        catalog[1].Set();
        catalog[0].Output();
        catalog[1].Output();
    }
}

