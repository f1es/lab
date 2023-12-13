
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
        int _year = 0;
        int.TryParse(Console.ReadLine(), out _year);
        Year = _year;

        Console.Write("Input cinema rating :");
        int _rating = 0;
        int.TryParse(Console.ReadLine(), out _rating);
        Rating = _rating;

    }

    public void Output()
    {
        Console.WriteLine(Strategy.GetOutput(this));
    }
}

