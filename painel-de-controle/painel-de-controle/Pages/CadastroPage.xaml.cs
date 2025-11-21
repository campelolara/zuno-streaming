using System.Net.Http.Json;
using System.Threading.Tasks;
using painel_de_controle.ViewModels;

namespace painel_de_controle;

public partial class CadastroPage : ContentPage
{
	public CadastroPage()
	{
		InitializeComponent();


	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Remove o menu lateral
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);

        // Remove o título da página
        Shell.SetNavBarIsVisible(this, false);
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(new MeusConteudosViewModel()));
        /*
        try
        {
            var cliente = new HttpClient();

            var response = await cliente.PostAsJsonAsync("https://44t8m685-44387.brs.devtunnels.ms/api/CriadorAuth/registrar", new
            {
                nome = RegNameEntry.Text,
                email = RegEmailEntry.Text,
                senha = RegPasswordEntry.Text
            });

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Sucesso", "Cadastrado!", "OK");
                await Navigation.PopAsync(); // volta após cadastrar
            }
            else
            {
                var erro = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Erro", erro, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
        */
    }

    private async void OnLoginLabelTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }


}