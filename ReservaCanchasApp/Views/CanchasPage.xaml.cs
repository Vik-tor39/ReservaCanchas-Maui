using ReservaCanchasApp.AdminViews;
using ReservaCanchasApp.Models;
using ReservaCanchasApp.Repositories;
using System.Text.Json;

namespace ReservaCanchasApp.Views;

public partial class CanchasPage : ContentPage
{
    public Usuario _usuario;
	public List<Cancha> _canchas;
	public Complejo _complejo;

    public CanchasPage(Complejo complejo, Usuario usuario)
    {
        InitializeComponent();
        _complejo = complejo;
        _usuario = usuario;
        Title = $"Canchas de {_complejo.NombreComplejo}";
        CargarCanchas();
        GenerarBotonAdministrador();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarCanchas(); // Recarga las canchas cada vez que la página aparece
    }

    private void CargarCanchas()
    {
		_canchas = App._canchaRepository.ObtenerTodasLasCanchas();
        CanchasCollection.ItemsSource = _canchas.Where(c => c.IdComplejo == _complejo.IdComplejo).ToList();
    }
    private async void OnCanchaSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Cancha seleccionada)
        {
            await Navigation.PushAsync(new ReservasPage(seleccionada, _usuario, _complejo));
        }
    }
    private void GenerarBotonAdministrador()
    {
        // Botón específico para administrador
        if (_usuario.Tipo == TipoDeUsuario.Administrador &&
            _usuario.ComplejosAdministrados.Contains(_complejo.IdComplejo))
        {
            var botonAdmin = new Button
            {
                Text = "Editar Complejo",
                BackgroundColor = Color.FromArgb("#007BFF"),
                TextColor = Colors.White,
                Margin = new Thickness(0, 10),
            };

            botonAdmin.Clicked += OnAdministracionComplejoAdmin;

            // Añadir el botón al contenedor y hacerlo visible
            AdminButtonContainer.Children.Add(botonAdmin);
            AdminButtonContainer.IsVisible = true;
        }
    }


    private async void OnAdministracionComplejoAdmin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GestionarComplejo(_complejo));
    }
}