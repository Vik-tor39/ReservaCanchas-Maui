using ReservaCanchasApp.Models;
using ReservaCanchasApp.Repositories;

namespace ReservaCanchasApp.AdminViews;

public partial class GestionarCancha : ContentPage
{
    private APIRepository _apiRepository;
    public Cancha? _cancha;
    public GestionarCancha(int idCancha)
    {
        InitializeComponent();
        _cancha = App._canchaRepository.ObtenerCanchaPorId(idCancha);
        _apiRepository = new APIRepository();
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

        if (!_cancha.Equals(null)) {
            if(App._canchaRepository.ActualizarCancha(_cancha) == true)
            {
                await DisplayAlert("Éxito", "La cancha se ha actualizado correctamente.", "OK");
            }

            await DisplayAlert("Error", "No fue posible agregar una nueva cancha", "OK");           

        }

        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        await Navigation.PopAsync();
    }


    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        try
        {
            // Mostrar alerta de confirmación
            bool confirmacion = await DisplayAlert(
                "Confirmación",
                "¿Estás seguro de que deseas eliminar esta cancha?",
                "Sí",
                "No"
            );

            // Si el usuario confirma, procede con la eliminación
            if (confirmacion)
            {
                // Llama al repositorio para eliminar la cancha

                bool nuevaCancha = App._canchaRepository.EliminarCancha(_cancha.IdCancha);

                if (!nuevaCancha)
                {
                    await DisplayAlert("Error", "No fue posible eliminar la información.", "OK");
                    return;
                }

                // Opcional: Mostrar mensaje de éxito
                await DisplayAlert("Éxito", "Cancha eliminada correctamente.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error
            await DisplayAlert("Error", "Ocurrió un error al intentar eliminar el usuario.", "OK");
        }
        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        await Navigation.PopAsync();
    }
}
