using System.Collections.ObjectModel;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.UI.ViewModels;
public class PositionStorage
{
    private readonly IPositionService _positionService;

    public PositionStorage(IPositionService positionService)
    {
        _positionService = positionService;
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var positions = await _positionService.GetAllAsync();
            foreach (var pos in positions)
            {
                Positions.Add(pos);
            }
        });
    }

    public ObservableCollection<Position> Positions { get; set; } = new();
}
