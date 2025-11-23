namespace zunoapi.Models;

public partial class Playlist
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int UsuarioId { get; set; }

    public virtual ICollection<ItemPlaylist> ItemPlaylists { get; set; } = new List<ItemPlaylist>();

    public virtual Usuario Usuario { get; set; } = null!;
}
