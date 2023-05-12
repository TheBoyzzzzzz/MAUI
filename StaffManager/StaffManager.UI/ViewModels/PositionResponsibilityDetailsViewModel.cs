using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.UI.ViewModels;

public partial class PositionResponsibilityDetailsViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty] public PositionResponsibility _selectedObject;
    [ObservableProperty] private Position _selectedPosition;

    private readonly IPositionResponsibilityService _positionResponsibilityService;
    public PositionStorage PositionStorage { get; }

    [RelayCommand] async Task UpdatePositionResponsibility() => await Update();
    public PositionResponsibilityDetailsViewModel(IPositionResponsibilityService positionResponsibilityService,
        PositionStorage positionStorage)
    {
        _positionResponsibilityService = positionResponsibilityService;
        PositionStorage = positionStorage;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SelectedObject = query["PositionResponsibility"] as PositionResponsibility;
        SelectedPosition = SelectedObject.Position;

    }

    private async Task Update()
    {
        SelectedObject.Position = SelectedPosition;
        await _positionResponsibilityService.UpdateAsync(SelectedObject);
        await _positionResponsibilityService.SaveChangesAsync();
    }

    [RelayCommand]
    public async void ChangePhoto()
    {
        var result = await FilePicker.Default.PickAsync();

        if (result != null && (result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)
            || result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase)))
        {
            SelectedObject.PhotoPath = result.FileName;

            await _positionResponsibilityService.UpdateAsync(SelectedObject);
        }
    }
}

