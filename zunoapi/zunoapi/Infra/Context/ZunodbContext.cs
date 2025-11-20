using Microsoft.EntityFrameworkCore;
using zunoapi.Models;

namespace zunoapi.Infra.Context;

public partial class ZunoContext : DbContext
{
    public ZunoContext()
    {
    }

    public ZunoContext(DbContextOptions<ZunoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conteudo> Conteudos { get; set; }

    public virtual DbSet<Criador> Criadors { get; set; }

    public virtual DbSet<Curtida> Curtida { get; set; }

    public virtual DbSet<Inscricao> Inscricaos { get; set; }

    public virtual DbSet<ItemPlaylist> ItemPlaylists { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Visualizacao> Visualizacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
                            "Server=IDSM-D-SIS4\\SQLEXPRESS;Database=zunodb;Trusted_Connection=True;TrustServerCertificate=True;");

    // definir maquina humberto na string de conexão acima.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conteudo>(entity =>
        {
            entity.ToTable("Conteudo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CriadorId).HasColumnName("CriadorID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Criador).WithMany(p => p.Conteudos)
                .HasForeignKey(d => d.CriadorId)
                .HasConstraintName("FK_Conteudo_Criador");
        });

        modelBuilder.Entity<Criador>(entity =>
        {
            entity.ToTable("Criador");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Curtida>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConteudoId).HasColumnName("ConteudoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Conteudo).WithMany(p => p.Curtidas)
                .HasForeignKey(d => d.ConteudoId)
                .HasConstraintName("FK_Curtida_Conteudo");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Curtidas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Curtida_Usuario");
        });

        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.ToTable("Inscricao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CriadorId).HasColumnName("CriadorID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Criador).WithMany(p => p.Inscricoes)
                .HasForeignKey(d => d.CriadorId)
                .HasConstraintName("FK_Inscricao_Criador");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inscricoes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Inscricao_Usuario");
        });

        modelBuilder.Entity<ItemPlaylist>(entity =>
        {
            entity.ToTable("ItemPlaylist");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConteudoId).HasColumnName("ConteudoID");
            entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

            entity.HasOne(d => d.Conteudo).WithMany(p => p.ItemPlaylists)
                .HasForeignKey(d => d.ConteudoId)
                .HasConstraintName("FK_ItemPlaylist_Conteudo");

            entity.HasOne(d => d.Playlist).WithMany(p => p.ItemPlaylists)
                .HasForeignKey(d => d.PlaylistId)
                .HasConstraintName("FK_ItemPlaylist_Playlist");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.ToTable("Playlist");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Playlist_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.PasswordSalt).HasMaxLength(500);
        });

        modelBuilder.Entity<Visualizacao>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConteudoId).HasColumnName("ConteudoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Conteudo).WithMany(p => p.Visualizacoes)
                .HasForeignKey(d => d.ConteudoId)
                .HasConstraintName("FK_Visualizacoes_Conteudo");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Visualizacoes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Visualizacoes_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
