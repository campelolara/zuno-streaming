namespace painel_de_controle
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            var token = Preferences.Get("auth_token", null);
            Shell.SetNavBarIsVisible(this, false);
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CadastroPage), typeof(CadastroPage));
        }
    }
}
