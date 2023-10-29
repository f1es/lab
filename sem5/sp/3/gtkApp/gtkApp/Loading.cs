using System;
using Gtk;

public class Loading : Window
{
    private ProgressBar progressBar;
    private Button cancelButton;
    private Timer timer;

    public Loading() : base("Loading")
    {
        //SetDefaultSize(300, 200);
        DeleteEvent += delegate { Application.Quit(); };

        VBox vbox = new VBox(false, 5);
        progressBar = new ProgressBar();
        cancelButton = new Button("Cancel");

        vbox.PackStart(progressBar, false, false, 0);
        vbox.PackStart(cancelButton, false, false, 0);

        Add(vbox);

        cancelButton.Clicked += OnCancelButtonClicked;
        TimerCallback callback = new TimerCallback(OnTimerTick);
        timer = new Timer(callback, null, 0, 100);

    }

    private void OnCancelButtonClicked(object sender, EventArgs e)
    {
        timer.Dispose();
        progressBar.Fraction = 0;
        Dialog("Canceled");
    }

    private void OnTimerTick(object state)
    {
        progressBar.Fraction += 0.04;

        if (progressBar.Fraction >= 1)
        {
            timer.Dispose();
            Dialog("Complete");
        }
    }

    private void Dialog(string message)
    {
        MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, message);
        md.Run();
        Application.Quit();
    }
}