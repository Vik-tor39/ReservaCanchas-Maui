using ReservaCanchas_Maui.InitViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservaCanchas_Maui.ViewModels
{
    public class Page1ViewModel
    {
        public ICommand ImageTappedCommand { get; }

        public Page1ViewModel()
        {
            ImageTappedCommand = new Command<string>(OnImageTapped);
        }

        public async void OnImageTapped(string imageId)
        {
            await App.Current.MainPage.Navigation.PushAsync(new Page2());
        }
    }
}
