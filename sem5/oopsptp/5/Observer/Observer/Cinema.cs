
public class Cinema
{
    private string _name;
    private int _year;
    private int _rating;
    public string Name
    {
        get => _name;
        private set => _name = value;
    }
    public int Year
    {
        get => _year;
        private set
        {
            if (value < 2025 && value > 1899)
                _year = value;
        }
    }
    public int Rating
    {
        get => _rating;
        private set => _rating = value;
    }
    public Cinema(string name, int year, int rating)
    {
        Name = name;
        Year = year;
        Rating = rating;
    }

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
        Console.Write($"{Name}({Year}) {Rating}*/5*");
        Console.WriteLine();
    }
}

