using StaffManager.UI.ViewModels;

namespace StaffManager.UI.Pages;


public partial class Positions : ContentPage
{
	private PositionsViewModel _positionsModel;
	public Positions(PositionsViewModel posMod)
	{
		InitializeComponent();
		_positionsModel = posMod;
		BindingContext = _positionsModel;
	}
}