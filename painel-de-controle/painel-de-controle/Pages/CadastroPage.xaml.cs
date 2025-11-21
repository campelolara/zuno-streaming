using System.Net.Http.Json;
using Preferences = Microsoft.Maui.Storage.Preferences;
using System.Net.Http;
using System.Threading.Tasks;
using painel_de_controle.ViewModels;

namespace painel_de_controle;

public partial class CadastroPage : ContentPage
{
	public CadastroPage()
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

    //cadastrar
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var cliente = new HttpClient();
        var response = await cliente.PostAsJsonAsync("https://zs3rxbr1-44387.brs.devtunnels.ms/api/CriadorAuth/registrar", new
        {
            nome = RegNameEntry.Text,
            email = RegEmailEntry.Text,
            senha = RegPasswordEntry.Text
        });

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Sucesso", "Cadastrado!", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            var erro = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Erro", erro, "OK");
        }
    }
    //ir pro LoginPage
    private async void OnLoginLabelTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }
}