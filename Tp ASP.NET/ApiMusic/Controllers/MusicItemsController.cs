using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMusic.Models;
using TpMusic.Data;
using TpMusic.Models;

namespace ApiMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicItemsController : ControllerBase
    {
        private readonly MvcMusicContext _context;

        public MusicItemsController(MvcMusicContext context)
        {
            _context = context;
        }

        // GET: api/MusicItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicItemDTO>>> GetMusicItems()
        {
            return await _context.Music.Select(x => MusicToDTO(x)).ToListAsync();
        }

        // GET: api/MusicItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicItemDTO>> GetMusicItem(int id)
        {
            var musicItem = await _context.Music.FindAsync(id);

            if (musicItem == null)
            {
                return NotFound();
            }

            return MusicToDTO(musicItem);
        }

        // PUT: api/MusicItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicItem(int id, MusicItemDTO musicItemDTO)
        {
            if (id != musicItemDTO.Id)
            {
                return BadRequest();
            }

            var musicItem = await _context.Music.FindAsync(id);
            if (musicItem == null)
            {
                return NotFound();
            }

            musicItem.Title = musicItemDTO.Title;
            musicItem.ReleaseDate = musicItemDTO.ReleaseDate;
            musicItem.Price = musicItemDTO.Price;
            musicItem.Genre = musicItemDTO.Genre;
            musicItem.Rating = musicItemDTO.Rating;
      

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!MusicItemExists(id))
            {
                if (!MusicItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MusicItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicItemDTO>> PostMusicItem(MusicItemDTO musicItemDTO)
        {

            var musicItem = new Music
            {
               Title = musicItemDTO.Title,
                ReleaseDate = musicItemDTO.ReleaseDate,
                Price = musicItemDTO.Price,
                Genre = musicItemDTO.Genre,
                Rating = musicItemDTO.Rating
        };

            _context.Music.Add(musicItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusicItem), 
                new { id = musicItem.Id }, 
                MusicToDTO(musicItem));
        }

        // DELETE: api/MusicItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicItem(int id)
        {
            var musicItem = await _context.Music.FindAsync(id);
            if (musicItem == null)
            {
                return NotFound();
            }

            _context.Music.Remove(musicItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool MusicItemExists(int id)
        {
            return _context.Music.Any(e => e.Id == id);
        }

        private static MusicItemDTO MusicToDTO(Music musicItem) =>
        new MusicItemDTO
        {
        Id = musicItem.Id,
        Title = musicItem.Title,
        ReleaseDate = musicItem.ReleaseDate,
        Price = musicItem.Price,
        Genre = musicItem.Genre,
        Rating = musicItem.Rating,
        };
    }
}
