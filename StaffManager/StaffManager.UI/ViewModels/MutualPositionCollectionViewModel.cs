using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.UI.ViewModels;
public partial class MutualPositionCollectionViewModel : ObservableObject
{
    private readonly IPositionService _positionService;

    public MutualPositionCollectionViewModel(IPositionService positionService)
    {
        _positionService = positionService;
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var positions = await _positionService.GetAllAsync();
            foreach(var pos in positions)
            {
                Positions.Add(pos);
            }
        });
    }

    public ObservableCollection<Position> Positions { get; set; } = new();
}
