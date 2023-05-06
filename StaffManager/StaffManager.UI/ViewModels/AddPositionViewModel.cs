using CommunityToolkit.Maui.Alerts;
using System.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using StaffManager.Application.Services;
using StaffManager.Domain.Entities;
using StaffManager.UI.Pages;
using StaffManager.UI.ViewModels;
using CommunityToolkit.Maui.Core;

namespace StaffManager.UI.ViewModels
{
    public partial class AddPositionViewModel : ObservableObject
    {
        public AddPositionViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [RelayCommand] async Task AddPosition() => await Add();
        [ObservableProperty] private string _name;
        [ObservableProperty] private string _salary;
        private readonly IServiceProvider _serviceProvider;

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

                var posViewModel = _serviceProvider.GetRequiredService<PositionsViewModel>();

                await MainThread.InvokeOnMainThreadAsync(() =>
                 {
                     posViewModel.Positions.Add(pos);
                 });
            }
        }
    }
}
