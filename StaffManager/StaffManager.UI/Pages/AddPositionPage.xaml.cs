using StaffManager.UI.ViewModels;

namespace StaffManager.UI.Pages;

public partial class AddPositionPage : ContentPage
{
    private readonly AddPositionViewModel _vm;

    public AddPositionPage(AddPositionViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }
}