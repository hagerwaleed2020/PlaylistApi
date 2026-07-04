using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace PlaylistApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Artist { get; set; } = "";
        [JsonIgnore]
        public List<Playlist> Playlists { get; set; } = new();
    }
}
