using Microsoft.EntityFrameworkCore;
using PlaylistApi.Models;

namespace PlaylistApi.Data
{
    public class PlaylistDbContext : DbContext
    {
        public PlaylistDbContext(DbContextOptions<PlaylistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}
