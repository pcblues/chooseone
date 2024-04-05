namespace ChooseOne;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }
}