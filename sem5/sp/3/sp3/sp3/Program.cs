using System;
//using Gdk;
using Gtk;


public class GtkApplication : Window
{
    public GtkApplication() : base(WindowType.Toplevel)
    {
        
    }

    protected void OnDeleteEvent(Object sender, EventArgs e)
    {
        Application.Quit();
        
    }


    public static void Main()
    {
        //Console.WriteLine("HelloWorld");
        Application.Init();
        Window windw = new Window("fdfdf");
        //Create a label and put some text in it.

        string str = Console.ReadLine();
        Label myLabel = new Label();
        myLabel.Text = str;
        Entry entry = new Entry();
        


        //Add the label to the form
        windw.Add(entry);
        
        windw.ShowAll();
        Application.Run();



    }

    public bool Search(int number)
    { 
    }
}