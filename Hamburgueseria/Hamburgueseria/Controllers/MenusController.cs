using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hamburgueseria.Models;
using Hamburgueseria.Models.ViewModels;

namespace Hamburgueseria.Controllers
{
    public class MenusController : Controller
    {
        private readonly HamburgueseriaContext _context;

        public MenusController(HamburgueseriaContext context)
        {
            _context = context;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            CrearMenusVM crearMenusVM = new CrearMenusVM
            {
                Principales = await _context.Principales.ToListAsync(),
                Entrantes = await _context.Entrantes.ToListAsync(),
                Postres = await _context.Postres.ToListAsync()
            };


            return View(crearMenusVM);
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Entrante)
                .Include(m => m.Postre)
                .Include(m => m.Principal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            ViewData["EntranteId"] = new SelectList(_context.Set<Entrante>(), "Id", "Id");
            ViewData["PostreId"] = new SelectList(_context.Set<Postre>(), "Id", "Id");
            ViewData["PrincipalId"] = new SelectList(_context.Set<Principal>(), "Id", "Id");
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,PrincipalId,EntranteId,PostreId,PrecioTotal")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntranteId"] = new SelectList(_context.Set<Entrante>(), "Id", "Id", menu.EntranteId);
            ViewData["PostreId"] = new SelectList(_context.Set<Postre>(), "Id", "Id", menu.PostreId);
            ViewData["PrincipalId"] = new SelectList(_context.Set<Principal>(), "Id", "Id", menu.PrincipalId);
            return View(menu);
        }
        [HttpPost]
        public async Task<IActionResult> EleccionMenu(CrearMenusVM crearMenusVM)
        {
            Entrante entrante = await _context.Entrantes.FindAsync(crearMenusVM.Menu.EntranteId);
            Postre postre = await _context.Postres.FindAsync(crearMenusVM.Menu.PostreId);
            Principal principal = await _context.Principales.FindAsync(crearMenusVM.Menu.PrincipalId);

            Menu menu = new Menu
            {
                Entrante = entrante,
                Postre = postre,
                Principal = principal,
                Fecha = DateTime.Now
               
            };

            double precio = 0;
            if (entrante != null)
            {
                precio += entrante.Precio;
            }

            if(principal != null)
            {
                precio += principal.Precio;
            }
            
            if(postre != null)
            {
                precio += postre.Precio;
            }
            menu.PrecioTotal = precio;

            return View(menu);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmarMenu(Menu menu)
        {
            await _context.AddAsync(menu);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["EntranteId"] = new SelectList(_context.Set<Entrante>(), "Id", "Id", menu.EntranteId);
            ViewData["PostreId"] = new SelectList(_context.Set<Postre>(), "Id", "Id", menu.PostreId);
            ViewData["PrincipalId"] = new SelectList(_context.Set<Principal>(), "Id", "Id", menu.PrincipalId);
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,PrincipalId,EntranteId,PostreId,PrecioTotal")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            ViewData["EntranteId"] = new SelectList(_context.Set<Entrante>(), "Id", "Id", menu.EntranteId);
            ViewData["PostreId"] = new SelectList(_context.Set<Postre>(), "Id", "Id", menu.PostreId);
            ViewData["PrincipalId"] = new SelectList(_context.Set<Principal>(), "Id", "Id", menu.PrincipalId);
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Entrante)
                .Include(m => m.Postre)
                .Include(m => m.Principal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
