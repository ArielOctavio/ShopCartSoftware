using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopCartSoftware.Data;
using ShopCartSoftware.Models;

namespace ShopCartSoftware.Controllers
{
    public class VentaCabecerasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaCabecerasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VentaCabeceras
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentaCabecera.ToListAsync());
        }

        // GET: VentaCabeceras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaCabecera = await _context.VentaCabecera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaCabecera == null)
            {
                return NotFound();
            }

            return View(ventaCabecera);
        }

        // GET: VentaCabeceras/Create
        public IActionResult Create()
        {
            var cabecera = new VentaCabecera();
            return View(cabecera);
        }

        // POST: VentaCabeceras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,IdUsuario")] VentaCabecera ventaCabecera)
        {
            if (ModelState.IsValid)
            {

                if( User.Identity.IsAuthenticated)
                {
                 var user = User.Identity.Name;
                 ventaCabecera.IdUsuario = user;
                _context.Add(ventaCabecera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            }
            return View(ventaCabecera);
        }

        // GET: VentaCabeceras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaCabecera = await _context.VentaCabecera.FindAsync(id);
            if (ventaCabecera == null)
            {
                return NotFound();
            }
            return View(ventaCabecera);
        }

        // POST: VentaCabeceras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,IdUsuario")] VentaCabecera ventaCabecera)
        {
            if (id != ventaCabecera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaCabecera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaCabeceraExists(ventaCabecera.Id))
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
            return View(ventaCabecera);
        }

        // GET: VentaCabeceras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaCabecera = await _context.VentaCabecera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaCabecera == null)
            {
                return NotFound();
            }

            return View(ventaCabecera);
        }

        // POST: VentaCabeceras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaCabecera = await _context.VentaCabecera.FindAsync(id);
            _context.VentaCabecera.Remove(ventaCabecera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaCabeceraExists(int id)
        {
            return _context.VentaCabecera.Any(e => e.Id == id);
        }
    }
}
