package br.unip.zunoapp.models;
public class Inscricao {

    private int id;
    private int usuarioId;
    private int criadorId;
    private Criador criador;
    private Usuario usuario;
    public Inscricao() {
    }
    public Inscricao(int id, int usuarioId, int criadorId, Criador criador, Usuario usuario) {
        this.id = id;
        this.usuarioId = usuarioId;
        this.criadorId = criadorId;
        this.criador = criador;
        this.usuario = usuario;
    }
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    public int getUsuarioId() { return usuarioId; }
    public void setUsuarioId(int usuarioId) { this.usuarioId = usuarioId; }
    public int getCriadorId() { return criadorId; }
    public void setCriadorId(int criadorId) { this.criadorId = criadorId; }
    public Criador getCriador() { return criador; }
    public void setCriador(Criador criador) { this.criador = criador; }
    public Usuario getUsuario() { return usuario; }
    public void setUsuario(Usuario usuario) { this.usuario = usuario; }
}