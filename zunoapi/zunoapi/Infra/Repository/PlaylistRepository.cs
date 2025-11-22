using zunoapi.Infra.Context;
using zunoapi.Models;

namespace zunoapi.Infra.Repository
{
    public class PlaylistRepository 
    {
        private ZunoContext _context;

        public PlaylistRepository(ZunoContext context)
        {
            _context = context;
        }


        public List<Playlist> GetAllPlaylist()
        {
            var allPlaylists = _context.Playlists.ToList();

            return allPlaylists;
        }

        public Playlist GetPlaylistByID (int id)
        {
            var playlist = _context.Find<Playlist>(id);
            
            return playlist;
        }

        public void AddPlaylist (Playlist playlist)
        {
            _context.Add<Playlist>(playlist);
        }

        public void UpdatePlaylist(Playlist playlist)
        {
            _context.Update<Playlist>(playlist);
        }

        public void DeletePlaylist(int id)
        {
            _context.Remove<Playlist>(GetPlaylistByID(id));
        }

    }
}
