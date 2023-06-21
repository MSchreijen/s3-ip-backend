using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class Playlist
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string SpotifyId { get; set; }
        public string MergedPlaylists { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IList<string> MergedPlaylistIds
        {
            get
            {
                return MergedPlaylists.Split(",");
            }
            set
            {
                MergedPlaylists = string.Join(",", value);
            }
        }
    }
}
