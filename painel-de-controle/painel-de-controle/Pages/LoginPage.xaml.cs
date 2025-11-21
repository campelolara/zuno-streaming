using System.Threading.Tasks;

namespace painel_de_controle;

public partial class LoginPage : ContentPage
{
	public LoginPage()
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

    //navega para a página de cadastro
    private async void OnRegisterLabelTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CadastroPage());
    }
    private async void OnLoginButtonCliked(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            await DisplayAlert("Erro", "Por favor insira seu email e senha", "OK");
            return;
        }
        //Simulando o processamento de login
        if(EmailEntry.Text == "email" && PasswordEntry.Text == "123")
        {
            //navega para a página principal
            await Navigation.PushAsync(new MainPage());
        } else
        {
            await DisplayAlert("Erro", "Email ou senha inválidos", "OK");
        }

        
    }
}