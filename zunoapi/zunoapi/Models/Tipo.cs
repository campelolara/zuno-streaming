using System;
using System.Collections.Generic;

namespace zunoapi.Models;

public partial class Tipo
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Conteudo> Conteudos { get; set; } = new List<Conteudo>();
}
