using zunoapi.Models;

namespace zunoapi.Infra.Interface
{

    public interface IPlaylistRepository
    {
        Task<List<Playlist>> GetAllPlaylist();
        Task<Playlist> GetPlaylistByID(int id);
        Task AddPlaylist(Playlist playlist);
        void UpdatePlaylist(Playlist playlist);
        void DeletePlaylist(Playlist playlist);
        Task Save();
    }
}
