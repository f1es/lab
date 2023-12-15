
public class Cinema
{
    private string name;
    private int year;
    private int rating;
    public string Name
    {
        get => name;
        private set => name = value;
    }
    public int Year
    {
        get => year;
        private set => year = value;
    }
    public int Rating
    {
        get => rating;
        private set => rating = value;
    }

    public Cinema(IStrategy cinema)
    {
        Strategy = cinema;
    }
    public IStrategy Strategy { get; set; }

    public void Set()
    {
        Console.Write("Input cinema name :");
        Name = Console.ReadLine();

        Console.Write("Input cinema year :");
        int year = 0;
        int.TryParse(Console.ReadLine(), out year);
        Year = year;

        Console.Write("Input cinema rating :");
        int rating = 0;
        int.TryParse(Console.ReadLine(), out rating);
        Rating = rating;

    }

    public void Set(string name, int year, int rating)
    {
        Name = name;
        Year = year;
        Rating = rating;
    }

    public void Output()
    {
        Console.WriteLine(Strategy.GetOutput(this));
    }
}

