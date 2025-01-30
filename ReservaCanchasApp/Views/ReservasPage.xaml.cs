using ReservaCanchasApp.Models;
using ReservaCanchasApp.Repositories;
using ReservaCanchasApp.AdminViews;

namespace ReservaCanchasApp.Views;

public partial class ReservasPage : ContentPage
{
    public Usuario _usuario;
    public Complejo _complejo;
	public Cancha _cancha;
    public Reserva _reserva;
	public ReservasPage(Cancha cancha, Usuario usuario, Complejo complejo)
	{
		InitializeComponent();
		_cancha = cancha;
        _usuario = usuario;
        _complejo = complejo;
        FechaPicker.MinimumDate = DateTime.Now.Date;
        BindingContext = this;
        MostrarDetallesCancha();
        GenerarBotonCanchaAdministrador();
    }
    private void MostrarDetallesCancha()
    {
        // Cargar detalles de la cancha
        NombreCanchaLabel.Text = _cancha.NombreCancha;
        ImagenCanchaImage.Source = _cancha.ImagenCancha;
        NumeroJugadoresLabel.Text = $"{_cancha.NumeroJugadores} jugadores";
        HorarioLabel.Text = $"{_cancha.HoraApertura:hh\\:mm} - {_cancha.HoraCierre:hh\\:mm}";
        PrecioPorHoraLabel.Text = $"{_cancha.PrecioPorHora:C}";
        UsuarioName.Text = _usuario.NombreUsuario;
        UsuarioCorreo.Text = _usuario.CorreoUsuario;


        // Configurar rango para TimePicker
        HoraInicioPicker.Time = _cancha.HoraApertura;
        HoraFinPicker.Time = _cancha.HoraCierre;
    }

    private async void OnConfirmarReservacionClicked(object sender, EventArgs e)
    {
        if (HoraInicioPicker.Time < _cancha.HoraApertura || HoraFinPicker.Time > _cancha.HoraCierre || HoraInicioPicker.Time >= HoraFinPicker.Time)
        {
            await DisplayAlert("Error", "El horario seleccionado no es v�lido.", "Aceptar");
            return;
        }

        if (!App._reservaRepository.VerificarEstado(_cancha.IdCancha, FechaPicker.Date, HoraInicioPicker.Time, HoraFinPicker.Time))
        {
            await DisplayAlert("Error", "El horario seleccionado ya est� reservado.", "Aceptar");
            return;
        }

        // Crear la reserva
        _reserva = new Reserva()
        {
            IdUsuario = _usuario.IdUsuario,
            Fecha = FechaPicker.Date,
            HoraInicio = HoraInicioPicker.Time,
            HoraFin = HoraFinPicker.Time,
            IdCancha = _cancha.IdCancha
        };

        // Guardar la reserva
        App._reservaRepository.CrearReserva(_reserva);

        await DisplayAlert("�xito", "Reservaci�n confirmada.", "Aceptar");
        await Navigation.PopAsync();
    }
    private void GenerarBotonCanchaAdministrador()
    {
        // Verificar si el usuario es administrador y si puede gestionar la cancha
        if (_usuario.Tipo == TipoDeUsuario.Administrador &&
            _cancha.IdComplejo == _complejo.IdComplejo &&
            _complejo.IdAdministrador == _usuario.IdUsuario)
        {
            var botonCanchaAdmin = new Button
            {
                Text = "Gestionar Cancha",
                BackgroundColor = Color.FromArgb("#F2F2F2"),
                TextColor = Color.FromArgb("#007BFF"),
                Margin = new Thickness(0, 10),
                CommandParameter = _cancha.IdCancha
            };

            botonCanchaAdmin.Clicked += OnAdministracionCanchaAdmin;

            // A�adir el bot�n al StackLayout directamente
            ReservasStackLayout.Children.Add(botonCanchaAdmin);
        }
    }

    private async void OnAdministracionCanchaAdmin(object sender, EventArgs e)
    {
        // Obtener el IdCancha del CommandParameter del bot�n
        int idCancha = (sender as Button)?.CommandParameter as int? ?? 0;

        // Navegar a la p�gina de gestionar cancha con el IdCancha
        await Navigation.PushAsync(new GestionarCancha(idCancha));
    }

}