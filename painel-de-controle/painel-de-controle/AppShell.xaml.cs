namespace painel_de_controle
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Shell.SetNavBarIsVisible(this, false);

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CadastroPage), typeof(CadastroPage));

            var token = Preferences.Get("auth_token", null);

            VerificarLogin();
        }
        // verifica se o usuário  esta logado
        private async void VerificarLogin()
        {
            var token = Preferences.Get("auth_token", null);

            if (string.IsNullOrEmpty(token))
            {
                await GoToAsync("//LoginPage");
            }
        }
    }
}
