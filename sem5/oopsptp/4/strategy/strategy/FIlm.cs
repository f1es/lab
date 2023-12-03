public class Film : IStrategy
{
    string genre;
    public string Genre
    {
        get => genre;
        private set => genre = value;
    }

    public void Set()
    {
        Console.Write("Input film genre :");
        Genre = Console.ReadLine();
    }

    public void Output()
    {
        Console.Write($"genre: {Genre}");
    }

    public void OutputXML()
    {
        Console.WriteLine($"\t<Genre>{Genre}</Genre>");
    }
}

