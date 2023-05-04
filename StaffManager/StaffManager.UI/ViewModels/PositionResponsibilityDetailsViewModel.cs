using StaffManager.Domain.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StaffManager.UI.ViewModels;

public class PositionResponsibilityDetailsViewModel : IQueryAttributable,  INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    PositionResponsibility selectedObject;

    public PositionResponsibility SelectedObject
    {
        get => selectedObject;
        set
        {
            selectedObject = value;
            OnPropertyChanged();
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SelectedObject = query["PositionResponsibility"] as PositionResponsibility;
    }

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

