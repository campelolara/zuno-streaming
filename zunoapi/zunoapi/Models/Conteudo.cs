namespace zunoapi.Models;

public partial class Conteudo
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int TipoId { get; set; }

    public int CriadorId { get; set; }

    public byte[]? Dados { get; set; } 

    public long? Tamanho { get; set; }

    public virtual Tipo Tipo { get; set; } = null!;

    public virtual Criador Criador { get; set; } = null!;

    public virtual ICollection<Curtida> Curtidas { get; set; } = new List<Curtida>();

    public virtual ICollection<ItemPlaylist> ItemPlaylists { get; set; } = new List<ItemPlaylist>();

    public virtual ICollection<Visualizacao> Visualizacoes { get; set; } = new List<Visualizacao>();
}
