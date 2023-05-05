using StaffManager.UI.Pages;

namespace StaffManager.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        Routing.RegisterRoute(nameof(PositionResponsibilityDetails), typeof(PositionResponsibilityDetails));

        InitializeComponent();
    }
}
