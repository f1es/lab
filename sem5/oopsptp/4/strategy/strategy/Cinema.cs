
public class Cinema
{
    string name;
    int year;
    int rating;
    public string Name
    {
        get => name;
        private set => name = value;
    }
    public int Year
    {
        get => year;
        private set
        {
            if (value < 2025 && value > 1899)
                year = value;
        }
    }
    public int Rating
    {
        get => rating;
        private set => rating = value;
    }

    public Cinema(IStrategy _cinema)
    {
        Strategy = _cinema;
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

        Strategy.Set();
    }

    public void Output()
    {
        Console.Write($"cinema: {Name}\t{Year}\t{Rating}*\t");
        Strategy.Output();
        Console.WriteLine();
    }

    public void OutputXML()
    {
        Console.WriteLine($"<element>\n\t<Name>{Name}</Name>\n\t<Year>{Year}</Year>\n\t<Rating>{Rating}</Rating>");
        Strategy.OutputXML();
        Console.WriteLine("</element>");
    }
}

