using CommunityToolkit.Mvvm.ComponentModel;
using StaffManager.Application.Abstractions;

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
}
