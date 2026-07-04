using System.ComponentModel.DataAnnotations;
namespace PlaylistApi.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";

        public List<Song> Songs { get; set; } = new();
    
    }
}
