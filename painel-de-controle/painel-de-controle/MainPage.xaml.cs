namespace painel_de_controle
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            //InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Remove o menu lateral
            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);

            // Remove o título da página
            Shell.SetNavBarIsVisible(this, false);
        }

    }

}
