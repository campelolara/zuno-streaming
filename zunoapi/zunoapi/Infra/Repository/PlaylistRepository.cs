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

        public async Task<List<Playlist>> GetAllPlaylist()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Playlist> GetPlaylistByID(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddPlaylist(Playlist playlist)
        {
            await _dbSet.AddAsync(playlist);
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


        //public List<Playlist> GetAllPlaylist()
        //{
        //    var allPlaylists = _context.Playlists.ToList();

        //    return allPlaylists;
        //}

        //public Playlist GetPlaylistByID (int id)
        //{
        //    var playlist = _context.Find<Playlist>(id);

        //    return playlist;
        //}

        //public void AddPlaylist (Playlist playlist)
        //{
        //    _context.Add<Playlist>(playlist);
        //}

        //public void UpdatePlaylist(Playlist playlist)
        //{
        //    _context.Update<Playlist>(playlist);
        //}

        //public void DeletePlaylist(int id)
        //{
        //    _context.Remove<Playlist>(GetPlaylistByID(id));
        //}

        //public async Task Save()
        //{
        //    await _context.SaveChangesAsync();
        //}

    }
}
