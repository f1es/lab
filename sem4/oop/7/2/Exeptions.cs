namespace films;
public class Exceptions : Exception
{
    public Exceptions(string message)
        : base(message)
    {
    }

    public Exceptions(string message, Exception inner)
        : base(message, inner)
    {
    }
}
