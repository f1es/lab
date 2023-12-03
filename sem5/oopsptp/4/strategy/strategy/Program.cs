
class Program
{
    static void Main(string[] args)
    {
        List<IStrategy> catalog = new List<IStrategy>();
        catalog.Add(new Film());
        catalog.Add(new Series());
        catalog[0].Output();
        catalog[1].Output();
        catalog[0].OutputXML();
        catalog[1].OutputXML();
    }
}

