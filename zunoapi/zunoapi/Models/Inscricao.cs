namespace zunoapi.Models;

public partial class Inscricao
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int CriadorId { get; set; }

    public virtual Criador Criador { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
