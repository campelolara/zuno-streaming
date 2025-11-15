using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace zunoapi.Models;

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

    public virtual DbSet<ItemPlaylist> ItemPlaylists { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IDSM-L-SIS3\\SQLEXPRESS01;Database=zunodb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conteudo>(entity =>
        {
            entity.HasOne(d => d.Criador).WithMany(p => p.Conteudos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conteudo_Criador");
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
            entity.HasOne(d => d.Usuario).WithMany(p => p.Playlists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Playlist_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
