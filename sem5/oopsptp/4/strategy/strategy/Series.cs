public class Series : IStrategy
{
    private int seriesCount = 1;
    public int SeriesCount
    {
        get => seriesCount;
        private set => seriesCount = value;
    }
    public void Set()
    {
        Console.Write("Input count of series :");
        int _seriesCount = 1;
        int.TryParse(Console.ReadLine(), out _seriesCount);
        SeriesCount = _seriesCount;
    }

    public void Output()
    {
        Console.Write($"series: {SeriesCount}");
    }
    
    public void OutputXML()
    {
        Console.WriteLine($"\t<SeriesCount>{SeriesCount}</SeriesCount>");
    }
}

