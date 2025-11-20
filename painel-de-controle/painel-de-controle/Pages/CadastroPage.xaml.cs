using System.Threading.Tasks;

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
        await Navigation.PopAsync();
    }

    private async void OnLoginLabelTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }
}