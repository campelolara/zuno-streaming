using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using painel_de_controle.Models;
using System.Collections.ObjectModel;

namespace painel_de_controle.ViewModels;

public partial class MeusConteudosViewModel : ObservableObject
{
    public ObservableCollection<TipoModel> Tipos { get; }
    public ObservableCollection<ConteudoItemModel> Conteudos { get; }

    [ObservableProperty]
    private TipoModel? _selectedTipo;

    public MeusConteudosViewModel()
    {
        Tipos = new ObservableCollection<TipoModel>();
        Conteudos = new ObservableCollection<ConteudoItemModel>();
    }

    public async ValueTask InitializeAsync()
    {
        // tipos temporários (mock)
        var tiposTemporarios = new List<TipoModel>
        {
            new TipoModel { Id = 1, Nome = "Vídeos"},
            new TipoModel { Id = 2, Nome = "Podcasts"},
            new TipoModel { Id = 3, Nome = "Músicas"},
        };

        Tipos.Clear();
        foreach (var item in tiposTemporarios)
            Tipos.Add(item);

        // Marca o primeiro como selecionado
        Tipos[0].IsSelected = true;
        SelectedTipo = Tipos[0];

        // MOCK conteúdos
        AtualizarConteudosMock();
    }

    // Método auxiliar para evitar repetição
    private void AtualizarConteudosMock()
    {
        Conteudos.Clear();

        var conteudosTemporarios = new List<ConteudoItemModel>
        {
            new ConteudoItemModel { Id = 1, Titulo = "Titulo1", Visualizacao = 40},
            new ConteudoItemModel { Id = 2, Titulo = "Titulo2", Visualizacao = 80},
            new ConteudoItemModel { Id = 3, Titulo = "Titulo3", Visualizacao = 120},
            new ConteudoItemModel { Id = 4, Titulo = "Titulo4", Visualizacao = 160},
            new ConteudoItemModel { Id = 5, Titulo = "Titulo5", Visualizacao = 200},
            new ConteudoItemModel { Id = 6, Titulo = "Titulo6", Visualizacao = 240},
        };

        foreach (var c in conteudosTemporarios)
            Conteudos.Add(c);
    }

    [RelayCommand]
    private async Task SelectTipoAsync(int tipoId)
    {
        // Desmarca o anterior
        if (SelectedTipo != null)
            SelectedTipo.IsSelected = false;

        // Marca o novo
        var newlySelectedTipo = Tipos.First(t => t.Id == tipoId);
        newlySelectedTipo.IsSelected = true;

        SelectedTipo = newlySelectedTipo;

        // Atualiza lista de conteúdos (por enquanto mock)
        AtualizarConteudosMock();
    }
}