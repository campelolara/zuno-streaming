using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models2;

[Table("Inscricao")]
public partial class Inscricao
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UsuarioID")]
    public int UsuarioId { get; set; }

    [Column("CriadorID")]
    public int CriadorId { get; set; }

    [ForeignKey("CriadorId")]
    [InverseProperty("Inscricaos")]
    public virtual Criador Criador { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Inscricaos")]
    public virtual Usuario Usuario { get; set; } = null!;
}
