using Gdk;
using Gtk;
class Program
{
    static void Main()
    {
        Application.Init();
        Guesser w = new Guesser();
        //ErrorOnClick w = new ErrorOnClick();
        //Loading w = new Loading();
        w.ShowAll();
        Application.Run();
    }
}