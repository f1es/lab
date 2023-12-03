public class Series : IStrategy
{
    string name;
    int year;
    int rating;
    int seriesCount;

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
    public int SeriesCount
    {
        get => seriesCount;
        private set => seriesCount = value;
    }
    public Series()
    {
        Set();
    }
    public void Set()
    {
        Console.Write("Input series name :");
        Name = Console.ReadLine();

        Console.Write("Input series year :");
        int _year = 0;
        int.TryParse(Console.ReadLine(), out _year);
        Year = _year;

        Console.Write("Input series rating :");
        int _rating = 0;
        int.TryParse(Console.ReadLine(), out _rating);
        Rating = _rating;

        Console.Write("Input count of series :");
        int _seriesCount = 1;
        int.TryParse(Console.ReadLine(), out _seriesCount);
        SeriesCount = _seriesCount;
    }

    public void Output()
    {
        Console.WriteLine($"series: {Name}\t{Year}\t{Rating}*\t{SeriesCount}");
    }
    
    public void OutputXML()
    {
        Console.WriteLine($"<element>\n\t{Name}\n\t{Year}\n\t{Rating}\n\t{SeriesCount}\n</element>");
    }
}

