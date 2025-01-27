using ReservaCanchasApp.Models;
using ReservaCanchasApp.Repositories;

namespace ReservaCanchasApp.AdminViews;

public partial class AddCancha : ContentPage
{
	private APIRepository _apiRepository;
	public Complejo _complejo;
	public Cancha _cancha;
	public AddCancha(Complejo complejo)
	{
		InitializeComponent();
		_complejo = complejo;
        _apiRepository = new APIRepository();

    }
    private async void OnAniadirCanchaClicked(object sender, EventArgs e)
	{
		_cancha = new Cancha()
		{
            NombreCancha = NombreCanchaEntry.Text,
            NumeroJugadores = int.TryParse(NumeroJugadoresEntry.Text, out int jugadores) ? jugadores : 0,
            PrecioPorHora = decimal.TryParse(PrecioPorHoraEntry.Text, out decimal precio) ? precio : 0,
            HoraApertura = HoraAperturaPicker.Time,
            HoraCierre = HoraCierrePicker.Time,
            ImagenCancha = ImagenCanchaEntry.Text,
            IdComplejo = _complejo.IdComplejo
        };

		bool nuevaCancha = App._canchaRepository.CrearCancha(_cancha);
        bool confApi = await _apiRepository.AgregarCanchaAsync(_cancha);

        if (!nuevaCancha)
        {
            await DisplayAlert("Error", "No fue posible guardar la información.", "OK");
            return;
        }

        if (!confApi)
        {
            await DisplayAlert("Error", "La información no se cargo en la API", "OK");
            return;
        }

        await DisplayAlert("Éxito", "Cancha guardada correctamente.", "OK");
        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        await Navigation.PopAsync();
    }
    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Regresa a la página anterior
    }
}