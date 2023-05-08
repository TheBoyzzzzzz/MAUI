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
        MutualPositionCollectionViewModel mutualPositionCollectionViewModel)
    {
        _positionService = positionService;
        _positionResponsibilityService = positionResponsibilityService;
        MutualPositionCollectionViewModel = mutualPositionCollectionViewModel;
    }

    //public ObservableCollection<Position> Positions { get; set; } = new();
    public ObservableCollection<PositionResponsibility> PositionResponsibilities { get; set; } = new();
    public MutualPositionCollectionViewModel MutualPositionCollectionViewModel { get; }

    [ObservableProperty]
    private Position _selectedPosition;

    //[RelayCommand]
    //async Task UpdateGroupList() => await GetPositions();

    [RelayCommand]
    async Task UpdateMembersList() => await GetPositionResponsibilities();

    //public async Task GetPositions()
    //{
    //    var positions = await _positionService.GetAllAsync();
    //    Positions.Clear();

    //    await MainThread.InvokeOnMainThreadAsync(() =>
    //    {
    //        foreach (var position in positions)
    //        {
    //            Positions.Add(position);
    //        }
    //    });
    //}

    public async Task GetPositionResponsibilities()
    {
        var positionResponsibilities = await _positionResponsibilityService
        .ListAsync(posResp => posResp.Position.Id == SelectedPosition.Id);

        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            PositionResponsibilities.Clear(); // Мб тут можно что получше придумать, чем каждый раз чистить.
            foreach (var positionResponsibility in positionResponsibilities)
            {
                PositionResponsibilities.Add(positionResponsibility);
            }
        });
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
}
