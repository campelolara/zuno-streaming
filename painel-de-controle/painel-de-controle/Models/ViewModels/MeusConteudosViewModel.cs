using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using painel_de_controle.Models;
using System.Collections.ObjectModel;

namespace painel_de_controle.ViewModels;

public partial class MeusConteudosViewModel : ObservableObject
{
 
    public int CreatorId { get; }

    public ObservableCollection<TipoConteudo> Tipos { get; }
    public ObservableCollection<Conteudo> Conteudos { get; }

    [ObservableProperty]
    private TipoConteudo? _selectedTipo;

    private List<Conteudo> _todosConteudos;

    public MeusConteudosViewModel()
    {
        //tem que ter isso
        CreatorId = Preferences.Get("creator_id", 0);

        Tipos = new ObservableCollection<TipoConteudo>();
        Conteudos = new ObservableCollection<Conteudo>();
    }

    public async ValueTask InitializeAsync()
    {

        var creatorId = Preferences.Get("creator_id", 0);
        Console.WriteLine($"CRIADOR LOGADO = {creatorId}");


        // tipos temporários (mock)
        var tiposTemporarios = new List<TipoConteudo>
        {
            new TipoConteudo { Id = 1, Nome = "Vídeos"},
            new TipoConteudo { Id = 2, Nome = "Podcasts"},
            new TipoConteudo { Id = 3, Nome = "Músicas"},
        };

        Tipos.Clear();
        foreach (var item in tiposTemporarios)
            Tipos.Add(item);

        // Marca o primeiro como selecionado
        Tipos[0].IsSelected = true;
        SelectedTipo = Tipos[0];

        // MOCK conteúdos
        AtualizarConteudosMock(SelectedTipo.Id);
    }

    // Método auxiliar para evitar repetição
    private void AtualizarConteudosMock(int? tipoId = null)
    {
        // Mock dos conteúdos
        _todosConteudos = new List<Conteudo>
    {
        new Conteudo { Id = 1, Titulo = "Natureza", Visualizacao = 500, TipoId=1},
        new Conteudo { Id = 2, Titulo = "Peixes", Visualizacao = 600, TipoId=1},
        new Conteudo { Id = 3, Titulo = "Filhotes", Visualizacao = 700, TipoId=1},
        new Conteudo { Id = 4, Titulo = "Cidades", Visualizacao = 800, TipoId=1},
        new Conteudo { Id = 5, Titulo = "Titulo5", Visualizacao = 200, TipoId=2},
        new Conteudo { Id = 6, Titulo = "Titulo6", Visualizacao = 240, TipoId=2},
    };

        // Filtra se tiver tipo selecionado
        Conteudos.Clear();
        var filtrados = tipoId != null
            ? _todosConteudos.Where(c => c.TipoId == tipoId)
            : _todosConteudos;

        foreach (var c in filtrados)
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

        Conteudos.Clear();
        var filtrados = _todosConteudos.Where(c => c.TipoId == tipoId);
        foreach (var c in filtrados)
            Conteudos.Add(c);

        // Atualiza lista de conteúdos (por enquanto mock)
        //AtualizarConteudosMock();
    }
}