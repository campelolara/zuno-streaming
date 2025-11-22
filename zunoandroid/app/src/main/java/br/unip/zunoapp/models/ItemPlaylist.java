package br.unip.zunoapp.models;
public class ItemPlaylist {
    private int id;
    private int playlistId;
    private int conteudoId;
    private Conteudo conteudo;
    public ItemPlaylist() {
    }
    public ItemPlaylist(int id, int playlistId, int conteudoId, Conteudo conteudo) {
        this.id = id;
        this.playlistId = playlistId;
        this.conteudoId = conteudoId;
        this.conteudo = conteudo;
    }
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    public int getPlaylistId() { return playlistId; }
    public void setPlaylistId(int playlistId) { this.playlistId = playlistId; }
    public int getConteudoId() { return conteudoId; }
    public void setConteudoId(int conteudoId) { this.conteudoId = conteudoId; }
    public Conteudo getConteudo() { return conteudo; }
    public void setConteudo(Conteudo conteudo) { this.conteudo = conteudo; }
}