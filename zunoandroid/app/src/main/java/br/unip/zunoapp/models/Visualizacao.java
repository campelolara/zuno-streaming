package br.unip.zunoapp.models;
public class Visualizacao {
    private int id;
    private int usuarioId;
    private int conteudoId;
    private Conteudo conteudo;
    private Usuario usuario;
    public Visualizacao() {
    }
    public Visualizacao(int id, int usuarioId, int conteudoId, Conteudo conteudo, Usuario usuario) {
        this.id = id;
        this.usuarioId = usuarioId;
        this.conteudoId = conteudoId;
        this.conteudo = conteudo;
        this.usuario = usuario;
    }
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    public int getUsuarioId() { return usuarioId; }
    public void setUsuarioId(int usuarioId) { this.usuarioId = usuarioId; }
    public int getConteudoId() { return conteudoId; }
    public void setConteudoId(int conteudoId) { this.conteudoId = conteudoId; }
    public Conteudo getConteudo() { return conteudo; }
    public void setConteudo(Conteudo conteudo) { this.conteudo = conteudo; }
    public Usuario getUsuario() { return usuario; }
    public void setUsuario(Usuario usuario) { this.usuario = usuario; }
}