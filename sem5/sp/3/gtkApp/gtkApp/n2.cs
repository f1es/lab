using Cairo;
using Gdk;
using Gtk;
using Color = Cairo.Color;
using Key = Gdk.Key;
using static Gdk.EventMask;

enum Tool { Line, Rectangle };

class Area : DrawingArea
{
    Color black = new Color(0, 0, 0),
          white = new Color(1, 1, 1),
          transparent_green = new Color(0.56, 0.93, 0.56, 0.5);

    ImageSurface canvas;
    bool dragging = false;
    double start_x, start_y;    // start position of mouse drag
    double end_x, end_y;        // end position of drag
    public Tool tool = Tool.Line;

    public Area()
    {
        canvas = new ImageSurface(Format.Rgb24, 400, 400);
        using (Context c = new Context(canvas))
        {
            c.SetSourceColor(white);
            c.Paint();
        }

        AddEvents((int)(ButtonPressMask | ButtonReleaseMask | PointerMotionMask));
    }

    void draw(Context c)
    {
        c.SetSourceColor(black);
        c.LineWidth = 3;
        if (tool == Tool.Line)
        {
            c.MoveTo(start_x, start_y);
            c.LineTo(end_x, end_y);
            c.Stroke();
        }
        else
        {
            c.Rectangle(x: start_x, y: start_y,
                        width: end_x - start_x, height: end_y - start_y);
            c.StrokePreserve();
            c.SetSourceColor(transparent_green);
            c.Fill();
        }
    }

    protected override bool OnDrawn(Context c)
    {
        c.SetSourceSurface(canvas, 0, 0);
        c.Paint();

        if (dragging)
            draw(c);
        return true;
    }

    protected override bool OnButtonPressEvent(EventButton e)
    {
        dragging = true;
        (start_x, start_y) = (end_x, end_y) = (e.X, e.Y);
        QueueDraw();
        return true;
    }

    protected override bool OnMotionNotifyEvent(EventMotion e)
    {
        if (dragging)
        {
            (end_x, end_y) = (e.X, e.Y);
            QueueDraw();
        }
        return true;
    }

    protected override bool OnButtonReleaseEvent(EventButton e)
    {
        dragging = false;
        using (Context c = new Context(canvas))
            draw(c);
        QueueDraw();
        return true;
    }
}

class N2 : Gtk.Window
{
    Area area;

    public N2() : base("draw")
    {
        Resize(400, 400);
        area = new Area();
        Add(area);
    }

    protected override bool OnKeyPressEvent(EventKey e)
    {
        switch (e.Key)
        {
            case Key.l: area.tool = Tool.Line; break;
            case Key.r: area.tool = Tool.Rectangle; break;
        }
        return true;
    }

    protected override bool OnDeleteEvent(Event e)
    {
        Application.Quit();
        return true;
    }
}
