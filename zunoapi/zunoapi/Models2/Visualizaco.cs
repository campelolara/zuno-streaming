using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models2;

public partial class Visualizaco
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UsuarioID")]
    public int UsuarioId { get; set; }

    [Column("ConteudoID")]
    public int ConteudoId { get; set; }

    [ForeignKey("ConteudoId")]
    [InverseProperty("Visualizacos")]
    public virtual Conteudo Conteudo { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Visualizacos")]
    public virtual Usuario Usuario { get; set; } = null!;
}
