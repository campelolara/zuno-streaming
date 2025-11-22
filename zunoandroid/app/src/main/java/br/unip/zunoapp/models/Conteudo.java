package br.unip.zunoapp.models;
public class Conteudo {
    private int id;
    private String titulo;
    private String tipo;
    private int criadorId;
    private long tamanho;
    private Criador criador;
    private String urlDoArquivo;
    public Conteudo() {
    }
    public Conteudo(int id, String titulo, String tipo, int criadorId, long tamanho, String urlDoArquivo, Criador criador) {
        this.id = id;
        this.titulo = titulo;
        this.tipo = tipo;
        this.criadorId = criadorId;
        this.tamanho = tamanho;
        this.urlDoArquivo = urlDoArquivo;
        this.criador = criador;
    }

    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    public String getTitulo() { return titulo; }
    public void setTitulo(String titulo) { this.titulo = titulo; }
    public String getTipo() { return tipo; }
    public void setTipo(String tipo) { this.tipo = tipo; }
    public int getCriadorId() { return criadorId; }
    public void setCriadorId(int criadorId) { this.criadorId = criadorId; }
    public long getTamanho() { return tamanho; }
    public void setTamanho(long tamanho) { this.tamanho = tamanho; }
    public Criador getCriador() { return criador; }
    public void setCriador(Criador criador) { this.criador = criador; }
    public String getUrlDoArquivo() { return urlDoArquivo; }
    public void setUrlDoArquivo(String urlDoArquivo) { this.urlDoArquivo = urlDoArquivo; }
}