package br.unip.zunoapp.models;
import java.util.List;
import br.unip.zunoapp.models.Conteudo;
public class Playlist {
    private int id;
    private String nome;
    private int usuarioId;
    private List<Conteudo> conteudos;
    public Playlist() {
    }
    public Playlist(int id, String nome, int usuarioId, List<Conteudo> conteudos) {
        this.id = id;
        this.nome = nome;
        this.usuarioId = usuarioId;
        this.conteudos = conteudos;
    }
    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }
    public int getUsuarioId() {
        return usuarioId;
    }
    public void setUsuarioId(int usuarioId) {
        this.usuarioId = usuarioId;
    }
    public List<Conteudo> getConteudos() {
        return conteudos;
    }
    public void setConteudos(List<Conteudo> conteudos) {
        this.conteudos = conteudos;
    }
}