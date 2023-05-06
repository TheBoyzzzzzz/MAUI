using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StaffManager.Domain.Entities;

namespace StaffManager.UI.ViewModels
{
    public partial class AddPositionViewModel : ObservableObject
    {
        [RelayCommand] async Task AddPosition() => await Add();
        [ObservableProperty] private string _name;
        [ObservableProperty] private string _salary;


        private async Task Add()
        {
            if (!int.TryParse(Salary, out int salary))
            {
                await App.Current.MainPage.DisplayAlert("Зарплата", "Введите число", "Ок");
            }
            else
            {
                var pos = new Position(Name, salary);
                IDictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"Position", pos}
                };


                await Shell.Current.GoToAsync("//Positions", parameters);
            }
        }
    }
}
