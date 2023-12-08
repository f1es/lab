public interface IObservable
{
    public void AddObserver(IObserver observer);
    public void NotifyObservers();
    public void RemoveObserver(IObserver observer);
}

