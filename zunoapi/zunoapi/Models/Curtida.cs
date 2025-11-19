namespace zunoapi.Models;

public partial class Curtida
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ConteudoId { get; set; }

    public virtual Conteudo Conteudo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
