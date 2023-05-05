using CommunityToolkit.Mvvm.ComponentModel;
using StaffManager.Domain.Entities;

namespace StaffManager.UI.ViewModels;

public partial class PositionResponsibilityDetailsViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty] public PositionResponsibility _selectedObject;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SelectedObject = query["PositionResponsibility"] as PositionResponsibility;
    }
}

