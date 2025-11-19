using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models2;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conteudo> Conteudos { get; set; }

    public virtual DbSet<Criador> Criadors { get; set; }

    public virtual DbSet<Curtidum> Curtida { get; set; }

    public virtual DbSet<Inscricao> Inscricaos { get; set; }

    public virtual DbSet<ItemPlaylist> ItemPlaylists { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Visualizaco> Visualizacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=100.107.95.31,1433;Database=zunodb;User Id=sa;Password=2019307632;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conteudo>(entity =>
        {
            entity.HasOne(d => d.Criador).WithMany(p => p.Conteudos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conteudo_Criador");
        });

        modelBuilder.Entity<Curtidum>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Conteudo).WithMany(p => p.Curtida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Curtida_Conteudo");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Curtida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Curtida_Usuario");
        });

        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.HasOne(d => d.Criador).WithMany(p => p.Inscricaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscricao_Criador");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inscricaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscricao_Usuario");
        });

        modelBuilder.Entity<ItemPlaylist>(entity =>
        {
            entity.HasOne(d => d.Conteudo).WithMany(p => p.ItemPlaylists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemPlaylist_Conteudo");

            entity.HasOne(d => d.Playlist).WithMany(p => p.ItemPlaylists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemPlaylist_Playlist");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasOne(d => d.Criador).WithMany(p => p.Playlists).HasConstraintName("FK_Playlist_Criador");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Playlists).HasConstraintName("FK_Playlist_Usuario");
        });

        modelBuilder.Entity<Visualizaco>(entity =>
        {
            entity.HasOne(d => d.Conteudo).WithMany(p => p.Visualizacos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Visualizacoes_Conteudo");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Visualizacos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Visualizacoes_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
