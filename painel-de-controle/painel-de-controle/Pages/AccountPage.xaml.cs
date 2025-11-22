using Microsoft.Maui.Storage;
using painel_de_controle.Services;
using painel_de_controle.Models;

namespace painel_de_controle;

public partial class AccountPage : ContentPage
{
    private readonly AuthService _authService;

    public AccountPage()
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);

        _authService = new AuthService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadProfile();
    }

    private async Task LoadProfile()
    {
        var perfil = await _authService.GetMeAsync();

        if (perfil == null)
        {
            await DisplayAlert("Erro", "Token inválido ou expirado.", "OK");
            return;
        }

        NomeLabel.Text = perfil.Nome;
        EmailLabel.Text = perfil.Email;
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        // Remove tokens e dados
        Preferences.Remove("jwt_token");
        Preferences.Remove("creator_id");

        // Volta para a página de login
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

}
