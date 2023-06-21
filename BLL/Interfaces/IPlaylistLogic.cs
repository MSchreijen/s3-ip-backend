using DTO;

namespace BLL.Interfaces
{
    public interface IPlaylistLogic
    {
        bool AddPlaylist(Playlist playlist);
        void DeletePlaylist(Playlist playlist);
        bool DeletePlaylistById(int id);
        IEnumerable<Playlist> GetAllPlaylists();
        Playlist? GetPlaylistById(int id);
        bool UpdatePlaylist(Playlist playlist);
    }
}