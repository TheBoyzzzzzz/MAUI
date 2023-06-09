﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.UI.ViewModels;

public partial class AddPositionViewModel : ObservableObject
{
    public AddPositionViewModel(IServiceProvider serviceProvider, IPositionService positionService,
        PositionStorage positionStorage)
    {
        _serviceProvider = serviceProvider;
        _positionService = positionService;
        PositionStorage = positionStorage;
    }

    [RelayCommand] async Task AddPosition() => await Add();
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _salary;
    private readonly IServiceProvider _serviceProvider;
    private readonly IPositionService _positionService;

    public PositionStorage PositionStorage { get; }

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
            await _positionService.SaveChangesAsync();

            await MainThread.InvokeOnMainThreadAsync(() =>
             {
                 PositionStorage.Positions.Add(pos);
             });
        }
    }
}
