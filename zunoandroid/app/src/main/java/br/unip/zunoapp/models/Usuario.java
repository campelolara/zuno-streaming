package br.unip.zunoapp.models;
import java.util.List;
public class Usuario {
    private int id;
    private String nome;
    private String email;
    private List<Playlist> playlists;
    public Usuario(int id, String nome, String email, List<Playlist> playlists) {
        this.id = id;
        this.nome = nome;
        this.email = email;
        this.playlists = playlists;
    }
    public Usuario() {
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
    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }
    public List<Playlist> getPlaylists() {
        return playlists;
    }
    public void setPlaylists(List<Playlist> playlists) {
        this.playlists = playlists;
    }
}