using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models2;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(70)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [MaxLength(500)]
    public byte[] PasswordHash { get; set; } = null!;

    [MaxLength(500)]
    public byte[] PasswordSalt { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<Curtidum> Curtida { get; set; } = new List<Curtidum>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Inscricao> Inscricaos { get; set; } = new List<Inscricao>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Visualizaco> Visualizacos { get; set; } = new List<Visualizaco>();
}
