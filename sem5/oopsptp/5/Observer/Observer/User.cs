public class User : IObserver
{
    private string _name;
    private IObservable _catalog;
    public User(string name, IObservable catalog)
    {
        _name = name;
        _catalog = catalog;
        catalog.AddObserver(this);
    }
    public void StopObserve()
    {
        _catalog.RemoveObserver(this);
        Console.WriteLine($"{_name} больше не следит за каталогом фильмов");
    }
    public void Update(object film)
    {
        Cinema cinema = (Cinema)film;

        Console.Write($"{_name} Вышел новый фильм - ");
        cinema.Output();
        if (cinema.Rating > 2)
            Console.WriteLine("Рекомендуем к просмотру");
        else
            Console.WriteLine("Так себе фильм, лучше не смотреть");
    }
}

