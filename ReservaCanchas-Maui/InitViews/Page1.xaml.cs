using ReservaCanchas_Maui.ViewModels;

namespace ReservaCanchas_Maui.InitViews;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
        BindingContext = new Page1ViewModel();
    }
}