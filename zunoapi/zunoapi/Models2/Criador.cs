using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models2;

[Table("Criador")]
public partial class Criador
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(70)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [InverseProperty("Criador")]
    public virtual ICollection<Conteudo> Conteudos { get; set; } = new List<Conteudo>();

    [InverseProperty("Criador")]
    public virtual ICollection<Inscricao> Inscricaos { get; set; } = new List<Inscricao>();

    [InverseProperty("Criador")]
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
