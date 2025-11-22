using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zunoapi.Infra.Context;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace zunoapi.Infra.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistRepository : IPlaylistRepository
    {
        protected readonly ZunoContext _context;  //referência ao contexto do banco de dados
        protected readonly DbSet<Playlist> _dbSet;       //referência ao conjunto de entidades do tipo T que serão manipuladas

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

        public void UpdatePlaylist(Playlist playlis)
        {
            _dbSet.Update(playlis);
        }

        public void DeletePlaylist(Playlist playlist)
        {
            _dbSet.Remove(playlist);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
 1    

    }
}
