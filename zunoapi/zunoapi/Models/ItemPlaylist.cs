using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models;

[Table("ItemPlaylist")]
public partial class ItemPlaylist
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PlaylistID")]
    public int PlaylistId { get; set; }

    [Column("ConteudoID")]
    public int ConteudoId { get; set; }

    [ForeignKey("ConteudoId")]
    [InverseProperty("ItemPlaylists")]
    public virtual Conteudo Conteudo { get; set; } = null!;

    [ForeignKey("PlaylistId")]
    [InverseProperty("ItemPlaylists")]
    public virtual Playlist Playlist { get; set; } = null!;
}
