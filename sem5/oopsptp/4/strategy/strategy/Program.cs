class Program
{
    static void Main(string[] args)
    {
        List<Cinema> catalog = new List<Cinema>();
        catalog.Add(new Cinema(new Film() ));
        catalog.Add(new Cinema(new Series() ));

        catalog[0].Set();
        catalog[1].Set();
        catalog[0].Output();
        catalog[1].Output();
        catalog[0].OutputXML();
        catalog[1].OutputXML();
    }
}

