using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Entities;
using StaffManager.UI.Pages;

namespace StaffManager.UI.ViewModels;

public partial class PositionsViewModel : ObservableObject
{
    private readonly IPositionService _positionService;
    private readonly IPositionResponsibilityService _positionResponsibilityService;

    public PositionsViewModel(IPositionService positionService, IPositionResponsibilityService positionResponsibilityService,
        PositionStorage positionStorage)
    {
        _positionService = positionService;
        _positionResponsibilityService = positionResponsibilityService;
        PositionStorage = positionStorage;
    }

    public ObservableCollection<PositionResponsibility> PositionResponsibilities { get; set; } = new();
    public PositionStorage PositionStorage { get; }

    [ObservableProperty]
    private Position _selectedPosition;


    [RelayCommand]
    async Task UpdateMembersList() => await GetPositionResponsibilities();

    public async Task GetPositionResponsibilities()
    {
        if (SelectedPosition is not null)
        {
            var positionResponsibilities = await _positionResponsibilityService
            .ListAsync(posResp => posResp.Position.Id == SelectedPosition.Id);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                PositionResponsibilities.Clear(); 
                foreach (var positionResponsibility in positionResponsibilities)
                {
                    PositionResponsibilities.Add(positionResponsibility);
                }
            }); 
        }
    }

    [RelayCommand]
    async Task ShowDetails(PositionResponsibility responsibility) => await GotoDetailsPage(responsibility);
    private async Task GotoDetailsPage(PositionResponsibility responsibility)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
                {"PositionResponsibility", responsibility}
        };

        await Shell.Current.GoToAsync(nameof(PositionResponsibilityDetails), parameters);
    }


    [RelayCommand] async Task DoUpdateResponsibilities() => await UpdateResponsibilities();
    private async Task UpdateResponsibilities()
    {
        await GetPositionResponsibilities();
    }
}
