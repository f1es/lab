using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cairo;
using Gdk;
using Gtk;
using Color = Cairo.Color;
using Key = Gdk.Key;
using static Gdk.EventMask;

public class ErrorOnClick : Gtk.Window
{
    public ErrorOnClick() : base("draw")
    {
        Resize(400, 400);
    }
    protected override bool OnButtonPressEvent(EventButton e)
    {
        MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Произошла ошибка! Программа будет закрыта!");
        md.Run();
        Close();
        return true;
    }
}

