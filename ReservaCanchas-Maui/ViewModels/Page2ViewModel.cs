using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservaCanchas_Maui.ViewModels
{
    public class Page2ViewModel
    {
        public ICommand ImageTappedCommand { get; }

        public Page2ViewModel()
        {
            ImageTappedCommand = new Command<string>(OnImageTapped);
        }

        private void OnImageTapped(string imageId)
        {
            // Lógica al tocar una imagen
            App.Current.MainPage.DisplayAlert("Imagen Seleccionada", $"Has seleccionado: {imageId}", "OK");
        }
    }
}
