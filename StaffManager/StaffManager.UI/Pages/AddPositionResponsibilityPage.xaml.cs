using StaffManager.UI.ViewModels;

namespace StaffManager.UI.Pages;

public partial class AddPositionResponsibilityPage : ContentPage
{
    private readonly AddPositionResponsibilityViewModel _vm;
    public AddPositionResponsibilityPage(AddPositionResponsibilityViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }
}