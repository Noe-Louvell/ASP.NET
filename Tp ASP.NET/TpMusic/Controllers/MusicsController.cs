﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpMusic.Data;
using TpMusic.Models;

namespace TpMusic.Controllers
{
    public class MusicsController : Controller
    {
        private readonly MvcMusicContext _context;

        public MusicsController(MvcMusicContext context)
        {
            _context = context;
        }

        // GET: Musics
        public async Task<IActionResult> Index(string musicsGenre, string searchString)
        {

            IQueryable<string> genreQuery = from m in _context.Music
                                           orderby m.Genre
                                           select m.Genre;


            var musics = from m in _context.Music
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                musics = musics.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(musicsGenre))
            {
                musics = musics.Where(x => x.Genre == musicsGenre);
            }

            var musicsGenreVM = new MusicGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                MusicS = await musics.ToListAsync()
            };

            return View(musicsGenreVM);
        }

        // GET: Musics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // GET: Musics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Validation")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        // GET: Musics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        // POST: Musics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Validation")] Music music)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicExists(music.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        // GET: Musics/Validation/5
        public async Task<IActionResult> Validation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        // POST: Musics/Validation/5
        [HttpPost, ActionName("Validation")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Validation(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (music == null)
            {

                return NotFound();
            }

            music.Validation = "Oui";
            _context.Update(music);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Musics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // POST: Musics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var music = await _context.Music.FindAsync(id);
            _context.Music.Remove(music);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      

     

        private bool MusicExists(int id)
        {
            return _context.Music.Any(e => e.Id == id);
        }
    }
}
