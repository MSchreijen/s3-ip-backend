using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class PlaylistLogic : IPlaylistLogic
    {
        private readonly IPlaylistHandler playlistHandler;

        public PlaylistLogic(IPlaylistHandler playlistHandler)
        {
            this.playlistHandler = playlistHandler;
        }

        public IEnumerable<Playlist> GetAllPlaylists()
        {
            return playlistHandler.GetAllPlaylists();
        }

        public Playlist? GetPlaylistById(int id)
        {
            return playlistHandler.GetPlaylistById(id);
        }

        public bool AddPlaylist(Playlist playlist)
        {
            return playlistHandler.AddPlaylist(playlist);
        }

        public bool UpdatePlaylist(Playlist playlist)
        {
            return playlistHandler.UpdatePlaylist(playlist);
        }

        public bool DeletePlaylistById(int id)
        {
            return playlistHandler.DeletePlaylistById(id);
        }

        public void DeletePlaylist(Playlist playlist)
        {
            playlistHandler.DeletePlaylist(playlist);
        }
    }
}
