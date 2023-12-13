using System.Xml.Linq;

public class Text : IStrategy
{
    public string GetOutput(Cinema cinema)
    {
        return $"<<{cinema.Name}>>\n<<{cinema.Year}>>\n<<{cinema.Rating}>>";
    }
}

