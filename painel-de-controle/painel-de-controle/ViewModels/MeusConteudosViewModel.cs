using CommunityToolkit.Mvvm.ComponentModel;
using painel_de_controle.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace painel_de_controle.ViewModels;

public partial class MeusConteudosViewModel : ObservableObject
{
    // alterar para a chamada de dados real posteriormente
    public ObservableCollection<TipoModel> Tipos { get; }

    // rastreia o tipo selecionado na interface
    [ObservableProperty]
    private TipoModel? _selectedTipo;

    public MeusConteudosViewModel()
    {
        Tipos = new ObservableCollection<TipoModel>();
    }
 
    public async ValueTask InitializeAsync()
    {

        //var dadosApi = await _conteudoTipo.ObterTiposAsync();
        var dadosMock = new List<TipoModel>
        {
            new TipoModel { Id = 1, Nome = "Vídeos"},
            new TipoModel { Id = 2, Nome = "Podcasts"},
            new TipoModel { Id = 3, Nome = "Músicas"},
        };

        Tipos.Clear();

        // adiciona os dados obtidos à coleção  observável
        foreach (var item in dadosMock)
            Tipos.Add(item);

        // seleciona o primeiro tipo por padrão
        Tipos[0].IsSelected = true;
        SelectedTipo = Tipos[0];


    }
}