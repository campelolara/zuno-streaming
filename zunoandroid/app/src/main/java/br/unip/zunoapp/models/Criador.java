package br.unip.zunoapp.models;
import java.util.List;
public class Criador {
    private int id;
    private String nome;
    private String email;
    private List<Conteudo> conteudos;
    public Criador() {
    }
    public Criador(int id, String nome, String email, List<Conteudo> conteudos) {
        this.id = id;
        this.nome = nome;
        this.email = email;
        this.conteudos = conteudos;
    }

    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    public String getNome() { return nome; }
    public void setNome(String nome) { this.nome = nome; }
    public String getEmail() { return email; }
    public void setEmail(String email) { this.email = email; }
    public List<Conteudo> getConteudos() { return conteudos; }
    public void setConteudos(List<Conteudo> conteudos) { this.conteudos = conteudos; }
}