package br.unip.zunoapp.models;
public class Curtida {
    private int id;
    private int usuarioId;
    private int conteudoId;
    private Usuario usuario;
    private Conteudo conteudo;
    public Curtida() {
    }
    public Curtida(int id, int usuarioId, int conteudoId, Usuario usuario, Conteudo conteudo) {
        this.id = id;
        this.usuarioId = usuarioId;
        this.conteudoId = conteudoId;
        this.usuario = usuario;
        this.conteudo = conteudo;
    }
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    public int getUsuarioId() { return usuarioId; }
    public void setUsuarioId(int usuarioId) { this.usuarioId = usuarioId; }
    public int getConteudoId() { return conteudoId; }
    public void setConteudoId(int conteudoId) { this.conteudoId = conteudoId; }
    public Usuario getUsuario() { return usuario; }
    public void setUsuario(Usuario usuario) { this.usuario = usuario; }
    public Conteudo getConteudo() { return conteudo; }
    public void setConteudo(Conteudo conteudo) { this.conteudo = conteudo; }
}