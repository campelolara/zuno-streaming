using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models;

[Table("Playlist")]
public partial class Playlist
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("UsuarioID")]
    public int UsuarioId { get; set; }

    [InverseProperty("Playlist")]
    public virtual ICollection<ItemPlaylist> ItemPlaylists { get; set; } = new List<ItemPlaylist>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("Playlists")]
    public virtual Usuario Usuario { get; set; } = null!;
}
