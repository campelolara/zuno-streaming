
using painel_de_controle.Models;

namespace painel_de_controle
{

    public partial class MainPage : ContentPage
    {
        public List<Tipo> Tipos { get; set; }
        public MainPage()
        {
            InitializeComponent();

            //Simulação de Categorias - Substituir por futura chamada de API
            Tipos = new List<Tipo>
            {
                new Tipo { Id = 1, Nome = "Vídeos"},
                new Tipo { Id = 2, Nome = "Podcasts"},
                new Tipo { Id = 3, Nome = "Músicas"},
                new Tipo { Id = 4, Nome = "Playlists"},
            };

            //vincula os dados à interface
            BindingContext = this;
        }

        

    }

}
