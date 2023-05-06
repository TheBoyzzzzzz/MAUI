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
using StaffManager.Application.Abstractions;

namespace StaffManager.UI.ViewModels
{
    public partial class AddPositionViewModel : ObservableObject
    {
        public AddPositionViewModel(IServiceProvider serviceProvider, IPositionService positionService)
        {
            _serviceProvider = serviceProvider;
            _positionService = positionService;
        }

        [RelayCommand] async Task AddPosition() => await Add();
        [ObservableProperty] private string _name;
        [ObservableProperty] private string _salary;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPositionService _positionService;

        private async Task Add()
        {
            if (!int.TryParse(Salary, out int salary))
            {
                await App.Current.MainPage.DisplayAlert("Зарплата", "Введите число", "Ок");
            }
            else
            {
                var pos = new Position(Name, salary);
                var posViewModel = _serviceProvider.GetRequiredService<PositionsViewModel>();
                await _positionService.AddAsync(pos);
                // по моему тут должно быть SaveChanges()
                await MainThread.InvokeOnMainThreadAsync(() =>
                 {
                     posViewModel.Positions.Add(pos);
                 });
            }
        }
    }
}
