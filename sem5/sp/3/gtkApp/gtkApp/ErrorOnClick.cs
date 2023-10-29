using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cairo;
using Gdk;
using Gtk;

public class ErrorOnClick : Gtk.Window
{
    public ErrorOnClick() : base("error")
    {
        Resize(400, 400);
    }
    protected override bool OnButtonPressEvent(EventButton e)
    {
        MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Произошла ошибка! Программа будет закрыта!");
        md.Run();
        Application.Quit();
        return true;
    }
}

