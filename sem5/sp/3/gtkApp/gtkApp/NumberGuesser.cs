using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdk;
using Gtk;
using static Gtk.Orientation;

public class NumberGuesser
{
    int maxNumber = 1000;
    int currentNumber = 500;
    int search = 500;

    public int CurrentNumber { get => currentNumber; set => currentNumber = value; }

    public void More()
    {
        ChangeSearch();
        currentNumber += search;
    }

    public void Less()
    {
        ChangeSearch();
        currentNumber -= search;
    }

    public void ChangeSearch()
    {
        if (search != 1)
            search /= 2;
    }
}

class Guesser : Gtk.Window
{
    NumberGuesser guesser = new NumberGuesser();

    Button yesButton = new Button("Yes");
    Label currentNumberLabel = new Label("");
    Button resetButton = new Button("Reset");
    Button moreButton = new Button("More(>)");
    Button lessButton = new Button("Less(<)");

    public Guesser() : base("number")
    {
        Box row = new Box(Horizontal, 0);
        currentNumberLabel.Text = guesser.CurrentNumber.ToString() + "?";
        row.Add(currentNumberLabel);

        Box row2 = new Box(Horizontal, 3);
        row2.Add(moreButton);
        moreButton.Clicked += onMore;
        row2.Add(lessButton);
        lessButton.Clicked += onLess;
        row2.Add(resetButton);
        resetButton.Clicked += onReset;
        row2.Add(yesButton);
        yesButton.Clicked += onYes;

        Box vbox = new Box(Vertical, 5);
        vbox.Add(row);
        vbox.Add(row2);
        Add(vbox);
        vbox.Margin = 5;
    }


    void onLess(object? sender, EventArgs args)
    {
        if (guesser.CurrentNumber != -1)
        {
            guesser.Less();
            currentNumberLabel.Text = guesser.CurrentNumber.ToString() + "?";
        }
    }

    void onMore(object? sender, EventArgs args)
    {
        if (guesser.CurrentNumber != -1)
        {
            guesser.More();
            currentNumberLabel.Text = guesser.CurrentNumber.ToString() + "?";
        }
    }

    public void onReset(object? sender, EventArgs args)
    {
        guesser = new NumberGuesser();
        currentNumberLabel.Text = guesser.CurrentNumber.ToString() + "?";
    }

    public void onYes(object? sender, EventArgs args)
    {
        currentNumberLabel.Text = "😎";
        guesser.CurrentNumber = -1;
    }

    protected override bool OnDeleteEvent(Event e)
    {
        Application.Quit();
        return true;
    }
}