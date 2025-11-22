using System.Security.Cryptography.X509Certificates;
using CommunityToolkit.Mvvm.ComponentModel;

namespace painel_de_controle.Models;

public class ConteudoItemModel : ObservableObject
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int Visualizacao { get; set; }
    public int TipoId { get; set; }

}


