using ReservaCanchas_Maui.ViewModels;

namespace ReservaCanchas_Maui.InitViews;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
        BindingContext = new Page2ViewModel();
    }
}