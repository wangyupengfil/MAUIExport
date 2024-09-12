namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
    
    private void OnLoggerClicked(object sender, EventArgs e)
    {
#if WINDOWS
        var windowsUserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string logDir = Path.Combine(windowsUserDirectory, "AppData\\Local", "AppDataLoggingSample\\logs");

        if (!Directory.Exists(logDir))
            Directory.CreateDirectory(logDir);

        string logFile = Path.Combine(logDir, $"{DateTime.Now:yyyy-MM-dd}-{DateTime.Now.Ticks}.log");

        File.WriteAllText(logFile, "Log button clicked");

        //Open logDir in Explorer
        System.Diagnostics.Process.Start("explorer.exe", logDir);
#endif
    }
}


















