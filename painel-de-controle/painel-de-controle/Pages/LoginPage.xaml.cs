using System.Net.Http;
using Preferences = Microsoft.Maui.Storage.Preferences;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace painel_de_controle;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Remove o título da página
        NavigationPage.SetHasNavigationBar(this, false);

    }

    //Login
    private async void OnLoginButtonCliked(object sender, EventArgs e)
    {
        var cliente = new HttpClient();

        var response = await cliente.PostAsJsonAsync("https://zs3rxbr1-44387.brs.devtunnels.ms/api/CriadorAuth/login", new
        {
            email = EmailEntry.Text,
            senha = PasswordEntry.Text
        });

        if (!response.IsSuccessStatusCode)
        {
            var erro = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Erro", erro, "OK");
            return;
        }

        var token = await response.Content.ReadAsStringAsync();

        Preferences.Set("auth_token", token);

        await DisplayAlert("Sucesso", "Logado!", "OK");

        // Navega para mainPage,
        Application.Current.MainPage = new AppShell();

    }

    //ir pra CadastroPage
    private async void OnRegisterLabelTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroPage());
    }
}