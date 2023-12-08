class Program
{
    public static void Main()
    {
        Catalog catalog = new();
        User user1 = new("Petr", catalog);
        User user2 = new("Sergey", catalog);
        Cinema kino1 = new("Brigada", 2001, 2);
        Cinema kino2 = new("VLASTRLIN KALEC", 2005, 4);
        Cinema kino3 = new("IGRA V PRESTOLI", 1999, 5);
        catalog.AddCinemaToCatalog(kino1);
        Console.WriteLine("--------------------");
        catalog.AddCinemaToCatalog(kino2);
        Console.WriteLine("--------------------");
        user1.StopObserve();
        Console.WriteLine("--------------------");
        catalog.AddCinemaToCatalog(kino3);
    }
}