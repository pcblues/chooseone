using ChooseOne.Data;
using ChooseOne.Models;

namespace ChooseOne.Views;

[QueryProperty("Item","Item")]
public partial class ProjectItemPage : ContentPage
{
	ProjectItem item;

	public ProjectItem Item
	{
		get => BindingContext as ProjectItem;
		set => BindingContext = value;
	}

	ChooseItemDatabase database;

	public ProjectItemPage(ChooseItemDatabase chooseItemDatabase)
	{
        InitializeComponent();
		database = chooseItemDatabase;
    }
    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Project))
        {
            await DisplayAlert("Project Name Required", "Please enter a name for the project item.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Item.Weight.ToString()))
        {
            await DisplayAlert("Weight Required", "Please enter a likelihood of project being chosen.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}