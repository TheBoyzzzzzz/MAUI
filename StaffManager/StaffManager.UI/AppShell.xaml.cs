using StaffManager.UI.Pages;

namespace StaffManager.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        Routing.RegisterRoute(nameof(PositionResponsibilityDetails), typeof(PositionResponsibilityDetails));
        Routing.RegisterRoute(nameof(AddPositionPage), typeof(AddPositionPage));
        Routing.RegisterRoute(nameof(AddPositionResponsibilityPage), typeof(AddPositionResponsibilityPage));
        InitializeComponent();
    }
}
