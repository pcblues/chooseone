using ChooseOne.Views;

namespace ChooseOne;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ProjectItemPage), typeof(ProjectItemPage));
    }
}
