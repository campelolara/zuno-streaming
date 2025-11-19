namespace zunoapi.Models;

public partial class Criador
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Conteudo> Conteudos { get; set; } = new List<Conteudo>();

    public virtual ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
