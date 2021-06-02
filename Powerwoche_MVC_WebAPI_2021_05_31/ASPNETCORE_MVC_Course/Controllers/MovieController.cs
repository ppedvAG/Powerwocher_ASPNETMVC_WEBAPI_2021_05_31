using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE_MVC_Course.Data;
using ASPNETCORE_MVC_Course.Models;

namespace ASPNETCORE_MVC_Course.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index(string query)
        {
            
            if (!string.IsNullOrEmpty(query))
            {
                ViewData["FilterQuery"] = query;
            }
            IList<Movie> filteredList =  string.IsNullOrEmpty(query) ? await _context.Movie.ToListAsync() : await _context.Movie.Where(q => q.Title.Contains(query)).ToListAsync();

            return View(filteredList);
        }

        [HttpPost]
        public IActionResult Wish(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            // Hier überlege ich mir eine Struktur (DB oder Session)

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Buy(int? id)
        {
            Movie currentMovie = _context.Movie.Find(id.Value);

            if (currentMovie == null)
                return NotFound();

            
            // Hier kommt ein Beispiel für das SessionHandling

            //Buy soll nur darstellen, dass man auch zwei Buttons in einem Formular haben darf.
            return RedirectToAction(nameof(Index));
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create() //Leeres Formular ohne Daten wird erstellt. 
        {
            return View(); 
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Genre,Price")] Movie movie) //Formulardaten konventieren in Movie-Objekt = ModelBinding
        {

            if (movie.Genre == 0)
            {
                ModelState.AddModelError("Genre", "Bitte wählen sie ein Genre aus");
            }

            if (ModelState.IsValid) //Serverseitige Validierung
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie); //
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie); //Formulat das an Browser übergeben wird hat sogar Daten
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Genre,Price")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
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
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
