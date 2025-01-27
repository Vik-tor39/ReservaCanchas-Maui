using ReservaCanchasApp.Models;
using ReservaCanchasApp.Repositories;
using System.Text.Json;

namespace ReservaCanchasApp.AdminViews;

public partial class AddComplejo : ContentPage
{
    public APIRepository _apiRepository;
    public Complejo _complejo;
    public List<Usuario> _administradores;
    public AddComplejo()
	{
		InitializeComponent();
        _complejo = new Complejo();
        _administradores = CargarAdministradores();
        _apiRepository = new APIRepository();

        AdministradorPicker.ItemsSource = _administradores;
    }
    private List<Usuario> CargarAdministradores()
    {
        List<Usuario> _listaAdministradores = new List<Usuario>();
        _listaAdministradores = App._usuarioRepository.ObtenerTodosLosUsuarios();

        return _listaAdministradores?.Where(u => u.Tipo == TipoDeUsuario.Administrador).ToList() ?? new List<Usuario>();
    }
    private async void OnGuardarComplejoClicked(object sender, EventArgs e)
    {
        // Validar que se haya seleccionado un administrador
        if (AdministradorPicker.SelectedItem is not Usuario administradorSeleccionado)
        {
            await DisplayAlert("Error", "Seleccione un administrador válido.", "OK");
            return;
        }

        // Asignar los datos ingresados
        _complejo.NombreComplejo = NombreComplejoEntry.Text;
        _complejo.ImagenComplejo = ImagenComplejoEntry.Text;
        _complejo.IdAdministrador = administradorSeleccionado.IdUsuario;

        

        bool nuevoComplejo = App._complejoRepository.CrearComplejo(_complejo);
        bool confApi = await _apiRepository.AgregarComplejoAsync(_complejo);

        if (!nuevoComplejo)
        {
            await DisplayAlert("Error", "No fue posible guardar la información.", "OK");
            return;
        }

        if (!confApi)
        {
            await DisplayAlert("Error", "La información no se cargo en la API", "OK");
            return;
        }

        Console.WriteLine($"Complejo creado: {_complejo.NombreComplejo}");

        await DisplayAlert("Éxito", "Complejo guardado correctamente.", "OK");
        await Navigation.PopAsync();
    }
}