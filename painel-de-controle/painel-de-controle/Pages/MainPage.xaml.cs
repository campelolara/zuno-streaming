using painel_de_controle.Models;
using painel_de_controle.ViewModels;
using System.Threading.Tasks;

namespace painel_de_controle
{

    public partial class MainPage : ContentPage
    {

        private readonly MeusConteudosViewModel _meusConteudosViewModel;
       
        public List<TipoModel> Tipos { get; set; }
        public MainPage(MeusConteudosViewModel meusConteudosViewModel)
        {
            InitializeComponent();

            //vincula os dados à interface
            _meusConteudosViewModel = meusConteudosViewModel;
            BindingContext = _meusConteudosViewModel;
            Initialize();
        }
        // Inicializa os dados quando a página é carregada
        private async void Initialize()
        {
            await _meusConteudosViewModel.InitializeAsync();
        }
        
        

    }

}
