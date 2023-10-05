using Gdk;
using Gtk;
using static Gtk.Orientation;

class Program
{
    static void Main()
    {
        Application.Init();
        Guesser w = new Guesser();
        //N2 w = new N2();
        //ErrorOnClick w = new ErrorOnClick();
        w.ShowAll();
        Application.Run();
    }
}