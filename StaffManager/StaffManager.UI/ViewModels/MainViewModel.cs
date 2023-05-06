using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StaffManager.UI.Pages;

namespace StaffManager.UI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand] async Task AddPosition() => await GoToAddPositionPage();
        [RelayCommand] async Task AddPositionResponsibility() => await GoToAddPositionResponsibilityPage();
        async Task GoToAddPositionPage()
        {
            await Shell.Current.GoToAsync(nameof(AddPositionPage));
        }

        async Task GoToAddPositionResponsibilityPage()
        {
            await Shell.Current.GoToAsync(nameof(AddPositionResponsibilityPage));
        }
    }
}
