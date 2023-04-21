﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Entities;
using System.Collections.ObjectModel;

namespace StaffManager.UI.ViewModels;

public partial class PositionsViewModel : ObservableObject
{
    private readonly IPositionService _positionService;
    private readonly IPositionResponsibilityService _positionResponsibilityService;

    public PositionsViewModel(IPositionService positionService, IPositionResponsibilityService positionResponsibilityService)
    {
        _positionService = positionService;
        _positionResponsibilityService = positionResponsibilityService;
    }
    public ObservableCollection<Position> Positions { get; set; } = new();
    public ObservableCollection<PositionResponsibility> PositionResponsibilities { get; set; } = new();

    [ObservableProperty]
    private Position _selectedPosition;

    [RelayCommand]
    async Task UpdateGroupList() => await GetPositions();
    [RelayCommand]
    async Task UpdateMembersList() => await GetPositionResponsibilities();

    public async Task GetPositions()
    {
        var positions = await _positionService.GetAllAsync();
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Positions.Clear();
            foreach (var position in positions)
            {
                Positions.Add(position);
            }
        });
    }

    public async Task GetPositionResponsibilities()
    {
        var positionResponsibilities = await _positionResponsibilityService
            .ListAsync(posResp => posResp.PositionId == SelectedPosition.Id);

        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            PositionResponsibilities.Clear();
            foreach (var positionResponsibility in positionResponsibilities)
            {
                PositionResponsibilities.Add(positionResponsibility);
            }
        });
    }
}
