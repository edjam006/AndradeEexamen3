namespace AndradeEexamen3.Views;

public partial class LogsPage : ContentPage
{
	public LogsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        LogLabel.Text = await Services.FileLoggerService.LeerLogsAsync();
    }
}