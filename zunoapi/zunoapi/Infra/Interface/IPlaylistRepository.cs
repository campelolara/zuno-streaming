using zunoapi.Models;

namespace zunoapi.Infra.Interface
{

    public interface IPlaylistRepository
    {
        List<Playlist> GetAllPlaylist();
        Playlist GetPlaylistByID(int id);
        void AddPlaylist(Playlist playlist);
        void UpdatePlaylist(Playlist playlist);
        void DeletePlaylist(Playlist playlist);
        Task Save();
    }
}
