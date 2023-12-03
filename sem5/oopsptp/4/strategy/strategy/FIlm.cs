public class Film : IStrategy
{
    string name;
    int year;
    int rating;
    string genre;

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
    public string Genre 
    { 
        get => genre; 
        private set => genre = value;
    }
    public Film()
    {
        Set();
    }
    public void Set()
    {
        Console.Write("Input film name :");
        Name = Console.ReadLine();

        Console.Write("Input film year :");
        int _year = 0;
        int.TryParse(Console.ReadLine(), out _year);
        Year = _year;

        Console.Write("Input film rating :");
        int _rating = 0;
        int.TryParse(Console.ReadLine(), out _rating);
        Rating = _rating;

        Console.Write("Input film genre :");
        Genre = Console.ReadLine();
    }

    public void Output()
    {
        Console.WriteLine($"film: {Name}\t{Year}\t{Rating}*\t{Genre}");
    }

    public void OutputXML()
    {
        Console.WriteLine($"<element>\n\t{Name}\n\t{Year}\n\t{Rating}\n\t{Genre}\n</element>");
    }
}

