using Microsoft.Maui.Controls;

namespace painel_de_controle
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }   
        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new NavigationPage(new LoginPage())); // pra iniciar na tela de login
            var window = new Window(new AppShell());

            //depois por como comentario
            //Navegar para o Login depois que o Shell existir
            window.Created += (s, e) =>
            {
                Shell.Current.GoToAsync("//LoginPage");
            };
            return window;
        }
    }
}