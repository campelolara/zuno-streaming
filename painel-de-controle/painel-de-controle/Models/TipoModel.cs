using System.Security.Cryptography.X509Certificates;
using CommunityToolkit.Mvvm.ComponentModel;

namespace painel_de_controle.Models;

// Modelo de dados para Categoria
public partial class TipoModel : ObservableObject
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    [ObservableProperty]
    private bool _isSelected;

}