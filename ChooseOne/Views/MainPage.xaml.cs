using ChooseOne.Data;
using ChooseOne.Models;

namespace ChooseOne.Views;


public partial class MainPage : ContentPage
{
    

    ChooseItemDatabase database;

    public MainPage(ChooseItemDatabase chooseItemDatabase)
    {
        InitializeComponent();
        database = chooseItemDatabase;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    
    }
    

    async void OnCounterClicked(object sender, EventArgs e)
    {
        string result = "";
        var items = await database.GetItemsAsync();
        int totalWeight = 0;
        var itemList = new List<string>();
        foreach (var item in items)
        {
            totalWeight+= item.Weight;
            for(var i = 0; i < item.Weight; i++)
            {
                itemList.Add(item.Project);
            }
        }
        if (itemList.Count > 0)
        {
            Random rnd = new Random();
            int index = rnd.Next(totalWeight);
            result = itemList[index];
            CounterBtn.Text = result;
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
