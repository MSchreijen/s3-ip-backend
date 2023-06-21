using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class PlaylistHandler : IPlaylistHandler
    {
        private readonly MergerContext mergerContext;

        public PlaylistHandler(MergerContext mergerContext)
        {
            this.mergerContext = mergerContext;
        }

        public IEnumerable<Playlist> GetAllPlaylists()
        {
            return mergerContext.Playlists.ToList();
        }

        public Playlist? GetPlaylistById(int id)
        {
            return mergerContext.Playlists.Find(id);
        }

        public bool AddPlaylist(Playlist playlist)
        {
            mergerContext.Playlists.Add(playlist);
            return mergerContext.SaveChanges() > 0;
        }

        public bool UpdatePlaylist(Playlist playlist)
        {
            Playlist? toUpdate = mergerContext.Playlists.Find(playlist.Id);
            if (toUpdate != null)
            {
                toUpdate.Name = playlist.Name;
                toUpdate.SpotifyId = playlist.SpotifyId;
                toUpdate.MergedPlaylistIds = playlist.MergedPlaylistIds;
                mergerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeletePlaylistById(int id)
        {
            Playlist? toRemove = mergerContext.Playlists.Find(id);
            if (toRemove != null)
            {
                mergerContext.Playlists.Remove(toRemove);
                mergerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeletePlaylist(Playlist playlist)
        {
            mergerContext.Remove(playlist);
            mergerContext.SaveChanges();
        }
    }
}
