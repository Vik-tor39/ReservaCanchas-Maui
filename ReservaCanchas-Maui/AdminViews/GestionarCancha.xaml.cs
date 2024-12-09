using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.AdminViews;

public partial class GestionarCancha : ContentPage
{
    private CanchaRepository _repository;
    private Cancha _cancha;

    public GestionarCancha(int idCancha)
    {
        InitializeComponent();
        _repository = new CanchaRepository();
        _cancha = _repository.ObtenerCanchaPorId(idCancha);
        CargarDetallesCancha();
    }

    private void CargarDetallesCancha()
    {
        if (_cancha != null)
        {
            NombreCanchaEntry.Text = _cancha.NombreCancha;
            NumeroJugadoresEntry.Text = _cancha.NumeroJugadores.ToString();
            PrecioPorHoraEntry.Text = _cancha.PrecioPorHora.ToString();
            HoraAperturaPicker.Time = _cancha.HoraApertura;
            HoraCierrePicker.Time = _cancha.HoraCierre;
            ImagenCanchaEntry.Text = _cancha.ImagenCancha;
        }
    }

    private async void OnGuardarCambiosClicked(object sender, EventArgs e)
    {
        _cancha.NombreCancha = NombreCanchaEntry.Text;
        _cancha.NumeroJugadores = int.TryParse(NumeroJugadoresEntry.Text, out int jugadores) ? jugadores : 0;
        _cancha.PrecioPorHora = decimal.TryParse(PrecioPorHoraEntry.Text, out decimal precio) ? precio : 0;
        _cancha.HoraApertura = HoraAperturaPicker.Time;
        _cancha.HoraCierre = HoraCierrePicker.Time;
        _cancha.ImagenCancha = ImagenCanchaEntry.Text;

        _repository.ActualizarCancha(_cancha);

        await DisplayAlert("Éxito", "La cancha se ha actualizado correctamente.", "OK");
        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        await Navigation.PopAsync();
    }


    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Regresa a la página anterior
    }
}
