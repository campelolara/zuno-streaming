
using painel_de_controle.Models;
using painel_de_controle.ViewModels;

namespace painel_de_controle
{

    public partial class MainPage : ContentPage
    {
                private readonly MeusConteudosViewModel _meusConteudosViewModel;
        public MainPage(MeusConteudosViewModel vm)
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
            _meusConteudosViewModel = vm;
            BindingContext = vm;
            Initialize();
        }

        private async void Initialize()
        {
            await _meusConteudosViewModel.InitializeAsync();
        }

    }

}
