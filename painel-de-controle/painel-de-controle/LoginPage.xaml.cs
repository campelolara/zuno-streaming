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

    private void OnRegisterLabelTapped(object sender, TappedEventArgs e)
    {

    }

    private void OnLoginButtonCliked(object sender, EventArgs e)
    {

    }
}