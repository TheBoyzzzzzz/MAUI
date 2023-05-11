using StaffManager.UI.ViewModels;

namespace StaffManager.UI.Pages;

public partial class PositionResponsibilityDetails : ContentPage
{
    private PositionResponsibilityDetailsViewModel _posResponsibilityModel;
    public PositionResponsibilityDetails(PositionResponsibilityDetailsViewModel posResponsibilityModel)
    {
        InitializeComponent();
        _posResponsibilityModel = posResponsibilityModel;
        BindingContext = _posResponsibilityModel;
    }
}