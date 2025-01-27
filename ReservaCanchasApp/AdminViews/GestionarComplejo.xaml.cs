using ReservaCanchasApp.Models;
using ReservaCanchasApp.Repositories;

namespace ReservaCanchasApp.AdminViews;

public partial class GestionarComplejo : ContentPage
{
	private APIRepository _apiRepository;
	public Complejo _complejo;

	public GestionarComplejo(Complejo complejo)
	{
		InitializeComponent();
		_complejo = complejo;

        NombreComplejoEntry.Text = _complejo.NombreComplejo;
        ImagenComplejoEntry.Text = _complejo.ImagenComplejo;
    }
    private async void OnGuardarCambiosClicked(object sender, EventArgs e)
    {
        // Validar entradas
        if (string.IsNullOrWhiteSpace(NombreComplejoEntry.Text) ||
            string.IsNullOrWhiteSpace(ImagenComplejoEntry.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        // Actualizar los datos del complejo
        _complejo.NombreComplejo = NombreComplejoEntry.Text;
        _complejo.ImagenComplejo = ImagenComplejoEntry.Text;

        // Guardar los cambios en el repositorio
        App._complejoRepository.ActualizarComplejo(_complejo);
        //await _apiRepository.ModificarComplejoAsync(_complejo.IdComplejo, _complejo);

        await DisplayAlert("Éxito", "Los datos del complejo se han actualizado correctamente.", "OK");
        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        await Navigation.PopAsync();
    }
    private async void OnAniadirCanchaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCancha(_complejo));
    }

}