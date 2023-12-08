public class Catalog : IObservable
{
    private List<Cinema> _cinemas = new();
    private List<IObserver> _observers = new();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_cinemas.Last());
        }
    }
    public void AddCinemaToCatalog(Cinema cinema)
    {
        _cinemas.Add(cinema);
        NotifyObservers();
    }
}

