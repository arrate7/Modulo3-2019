using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Videoclub.Models;

namespace Videoclub.Controllers
{
    public class UserFilmsController : Controller
    {
        private readonly VideoclubContext _context;

        public UserFilmsController(VideoclubContext context)
        {
            _context = context;
        }

        // GET: UserFilms
        public async Task<IActionResult> Index(string pendiente)
        {
            List<UserFilm> alquileres =await  _context.UserFilms
                .Include(u => u.Film)
                .Include(u => u.User)
                .Where(x=>x.UserId == 1).ToListAsync();

            if (String.IsNullOrEmpty(pendiente))
            {
                return View(alquileres);
            }

            if (pendiente == "si")
            {
                alquileres = alquileres.Where(x => x.DateReturned == null).ToList();
            }
            else
            {
                alquileres = alquileres.Where(x => x.DateReturned != null).ToList();
            }

            return View(alquileres);
        }

        // GET: UserFilms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilms
                .Include(u => u.Film)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }

        // GET: UserFilms/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Genero");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: UserFilms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateRented,DateReturned,UserId,FilmId")] UserFilm userFilm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFilm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Genero", userFilm.FilmId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userFilm.UserId);
            return View(userFilm);
        }

        // GET: UserFilms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilms.FindAsync(id);
            if (userFilm == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Genero", userFilm.FilmId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userFilm.UserId);
            return View(userFilm);
        }

        // POST: UserFilms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateRented,DateReturned,UserId,FilmId")] UserFilm userFilm)
        {
            if (id != userFilm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFilm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFilmExists(userFilm.Id))
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
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Genero", userFilm.FilmId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userFilm.UserId);
            return View(userFilm);
        }

        // GET: UserFilms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilms
                .Include(u => u.Film)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }

        // POST: UserFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userFilm = await _context.UserFilms.FindAsync(id);
            _context.UserFilms.Remove(userFilm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFilmExists(int id)
        {
            return _context.UserFilms.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ConfirmarAlquiler(int id)
        {
            Film film =await _context.Films.FindAsync(id);
            User user = await _context.Users.FindAsync(1);

            UserFilm alquiler = new UserFilm
            {
                Film = film,
                User = user,
                DateRented = DateTime.Now,

            };

            _context.Add(alquiler);
            film.Rented = true;
            _context.Update(film);
           await  _context.SaveChangesAsync();

            return RedirectToAction("Index");
            //RedirectToAction("Index","Films");
            //RedirectToAction(nameof(Index));
        }

    }
}
