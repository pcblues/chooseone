using System.Collections.ObjectModel;
using ChooseOne.Data;
using ChooseOne.Models;


namespace ChooseOne.Views;


public partial class ListPage : ContentPage
{

    ChooseItemDatabase database;
    public ObservableCollection<ProjectItem> Items { get; set; } = new();


    public ListPage(ChooseItemDatabase chooseItemDatabase)
	{
		InitializeComponent();
        database = chooseItemDatabase;
        BindingContext = this;

	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);

        });
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProjectItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new ProjectItem()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not ProjectItem item)
            return;

        await Shell.Current.GoToAsync(nameof(ProjectItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}