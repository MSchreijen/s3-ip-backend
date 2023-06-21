using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("/playlists")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistLogic playlistLogic;

        public PlaylistController(IPlaylistLogic playlistLogic)
        {
            this.playlistLogic = playlistLogic;
        }

        [HttpGet]
        public IEnumerable<Playlist> GetAllPlaylists()
        {
            return playlistLogic.GetAllPlaylists();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPlaylistById(int id)
        {
            Playlist? playlist = playlistLogic.GetPlaylistById(id);
            if (playlist == null) return NotFound();
            return Ok(playlist);
        }

        [HttpPost]
        public IActionResult CreatePlaylist(Playlist playlist)
        {
            if (playlist != null)
            {
                playlistLogic.AddPlaylist(playlist);
                return Ok($"Playlist {playlist.Name} created");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdatePlaylist(Playlist playlist)
        {
            if (playlist != null)
            {
                playlistLogic.UpdatePlaylist(playlist);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}/merged")]
        public IActionResult UpdateMergedPlaylists([FromRoute] int id, [FromBody] IList<string> mergedPlaylistsId)
        {
            Playlist? playlist = playlistLogic.GetPlaylistById(id); 
            if (playlist == null) return NotFound();

            playlist.MergedPlaylistIds = mergedPlaylistsId;
            if (playlistLogic.UpdatePlaylist(playlist)) return NoContent();

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeletePlaylist(Playlist playlist)
        {
            if (playlist != null)
            {
                playlistLogic.DeletePlaylist(playlist);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePlaylistById(int id)
        {
            if (playlistLogic.DeletePlaylistById(id)) return NoContent();
            return BadRequest();
        }
    }
}
