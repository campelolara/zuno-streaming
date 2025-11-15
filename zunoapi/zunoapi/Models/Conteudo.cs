using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models;

[Table("Conteudo")]
public partial class Conteudo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [Column("CriadorID")]
    public int CriadorId { get; set; }

    public byte[] Dados { get; set; } = null!;

    public long Tamanho { get; set; }

    [ForeignKey("CriadorId")]
    [InverseProperty("Conteudos")]
    public virtual Criador Criador { get; set; } = null!;

    [InverseProperty("Conteudo")]
    public virtual ICollection<ItemPlaylist> ItemPlaylists { get; set; } = new List<ItemPlaylist>();
}
