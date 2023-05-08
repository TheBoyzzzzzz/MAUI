using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.UI.ViewModels;
public partial class AddPositionResponsibilityViewModel : ObservableObject
{
    public AddPositionResponsibilityViewModel(IPositionResponsibilityService positionResponsibilityService,
        PositionStorage positionStorage)
    {
        _positionResponsibilityService = positionResponsibilityService;
        PositionStorage = positionStorage;
    }

    [RelayCommand] async Task AddPositionResponsibility() => await Add();
    //[RelayCommand] async Task UpdateGroupList() => await GetPositions();

    [ObservableProperty] private string _name;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _importance;

    private readonly IPositionResponsibilityService _positionResponsibilityService;

    //public ObservableCollection<Position> Positions { get; set; } = new();
    public PositionStorage PositionStorage { get; }

    [ObservableProperty]
    private Position _selectedPosition;

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
    private async Task Add()
    {
        if (SelectedPosition == null)
        {
            await App.Current.MainPage.DisplayAlert("Должность", "Выберите должность", "Ок");
            return;
        }
        if (!int.TryParse(Importance, out int importance))
        {
            await App.Current.MainPage.DisplayAlert("Важность", "Введите число", "Ок");
            return;
        }

        var posResposibility = new PositionResponsibility(Name, Description, importance) { Position = SelectedPosition };
        await _positionResponsibilityService.AddAsync(posResposibility);
        await _positionResponsibilityService.SaveChangesAsync();
    }
}
