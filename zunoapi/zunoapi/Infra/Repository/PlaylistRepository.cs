using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zunoapi.Infra.Context;
using zunoapi.Infra.DTO;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace zunoapi.Infra.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
<<<<<<< HEAD
        public readonly ZunoContext _context; 
        public readonly DbSet<Playlist> _dbSet;       
=======
        //referência ao contexto do banco de dados
        protected readonly ZunoContext _context;
        //referência ao conjunto de entidades do tipo T que serão manipuladas
        protected readonly DbSet<Playlist> _dbSet;      
>>>>>>> 28598cce56a9a6c2a8ef3176beaddae5901c8929

        public PlaylistRepository(ZunoContext context)
        {
            _context = context;
            _dbSet = _context.Set<Playlist>();
        }

        public List<Playlist> GetAllPlaylist()
        {
            return _dbSet.ToList();
        }

        public Playlist GetPlaylistByID(int id)
        {
            return _dbSet.Find(id);
        
        }

        public void AddPlaylist(Playlist playlist)
        {
            _dbSet.Add(playlist);
        }

        public void UpdatePlaylist(Playlist playlist)
        {
            _dbSet.Update(playlist);
        }

        public void DeletePlaylist(Playlist playlist)
        {
            _dbSet.Remove(playlist);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
<<<<<<< HEAD
        }
   

=======
        }    
>>>>>>> 28598cce56a9a6c2a8ef3176beaddae5901c8929
    }
}
