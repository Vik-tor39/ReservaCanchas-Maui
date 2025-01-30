﻿using ReservaCanchasApp.Repositories;

namespace ReservaCanchasApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void MostrarPasswordChanged(object sender, CheckedChangedEventArgs e)
    {
        PasswordEntry.IsPassword = !e.Value;
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CorreoEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        var usuario = App._usuarioRepository.ObtenerTodosLosUsuarios()
                                        .FirstOrDefault(u => u.CorreoUsuario == CorreoEntry.Text &&
                                                             u.PasswordUsuario == PasswordEntry.Text);

        if (usuario == null)
        {
            await DisplayAlert("Error", "Correo o contraseña incorrectos.", "OK");
            return;
        }

        await DisplayAlert("Éxito", $"¡Bienvenido {usuario.NombreUsuario}!", "OK");

        await Navigation.PushAsync(new Views.ComplejosPage(usuario));
    }

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }
}
