namespace zunoapi.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public virtual ICollection<Curtida> Curtidas { get; set; } = new List<Curtida>();

    public virtual ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    public virtual ICollection<Visualizacao> Visualizacoes { get; set; } = new List<Visualizacao>();
}
