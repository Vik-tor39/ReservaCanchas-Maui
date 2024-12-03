using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.Views;

public partial class Register : ContentPage
{
    public Usuario _usuario;
    public UsuarioRepository _repository;
	public Register()
	{
		InitializeComponent();
        _repository = new UsuarioRepository();
        _usuario = new Usuario();
	}
    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    private void OnAniadirUsuario(object Sender, EventArgs e)
    {

    }
}