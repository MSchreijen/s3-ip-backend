using DTO;

namespace DAL.Interfaces
{
    public interface IPlaylistHandler
    {
        bool AddPlaylist(Playlist playlist);
        void DeletePlaylist(Playlist playlist);
        bool DeletePlaylistById(int id);
        IEnumerable<Playlist> GetAllPlaylists();
        Playlist? GetPlaylistById(int id);
        bool UpdatePlaylist(Playlist playlist);
    }
}