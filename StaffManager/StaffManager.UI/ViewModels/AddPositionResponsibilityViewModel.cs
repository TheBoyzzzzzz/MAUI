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

    [ObservableProperty] private string _name;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _importance;
    [ObservableProperty] private string _photoPath;
    [ObservableProperty] private Position _selectedPosition;

    private readonly IPositionResponsibilityService _positionResponsibilityService;

    public PositionStorage PositionStorage { get; }


    [RelayCommand] async Task AddPositionResponsibility() => await Add();
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

        if (PhotoPath == null)
        {
            PhotoPath = "dotnet_bot.png";
        }
        var posResposibility = new PositionResponsibility(Name, Description, importance, PhotoPath) { Position = SelectedPosition };
        await _positionResponsibilityService.AddAsync(posResposibility);
        await _positionResponsibilityService.SaveChangesAsync();
    }

    [RelayCommand]
    public async void ChangePhoto()
    {
        var result = await FilePicker.Default.PickAsync();

        if (result != null && (result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)
            || result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase)))
        {
            PhotoPath = result.FullPath;
        }
    }
}
