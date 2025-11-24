using Microsoft.EntityFrameworkCore;
using zunoapi.Infra.Context;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace zunoapi.Infra.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        protected readonly ZunoContext _context;
        protected readonly DbSet<Playlist> _dbSet;

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
        }

    }
}
