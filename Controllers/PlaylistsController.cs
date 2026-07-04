using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistApi.Data;
using PlaylistApi.Models;

namespace PlaylistApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly PlaylistDbContext _context;

        public PlaylistsController(PlaylistDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Playlist>>> Get()
        {
            return await _context.Playlists
            .Include(p => p.Songs)
            .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> CreatePlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
        }

        [HttpPost("{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            var playlist = await _context.Playlists
                .Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.Id == playlistId);

            if (playlist == null)
                return NotFound("Playlist not found.");

            var song = await _context.Songs.FindAsync(songId);

            if (song == null)
                return NotFound("Song not found.");

            playlist.Songs.Add(song);

            await _context.SaveChangesAsync();

            return Ok("Song added to playlist successfully.");
        }

    }

}
