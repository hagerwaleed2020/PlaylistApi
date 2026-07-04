using Microsoft.AspNetCore.Mvc;
using PlaylistApi.Data;
using PlaylistApi.Models;

namespace PlaylistApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly PlaylistDbContext _context;

        public SongsController(PlaylistDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(Song song)
        {
            _context.Songs.Add(song);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateSong), new { id = song.Id }, song);
        }
    }
}