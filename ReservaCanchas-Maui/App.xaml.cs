using ReservaCanchas_Maui.InitViews;

namespace ReservaCanchas_Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Page1());
        }
    }
}
