using System.Xml.Linq;

public class XML : IStrategy
{
    public string GetOutput(Cinema cinema)
    {
        return $"<element>\n\t<Name>{cinema.Name}</Name>\n\t<Year>{cinema.Year}</Year>\n\t<Rating>{cinema.Rating}</Rating>\n<element>";
    }
}

