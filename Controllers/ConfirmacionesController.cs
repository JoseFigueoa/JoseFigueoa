using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor2._0.Data.DB_BASE;

namespace Gestor2._0.Controllers
{
    public class ConfirmacionesController : Controller
    {
        private readonly GestorDeActasNetContext _context;

        public ConfirmacionesController(GestorDeActasNetContext context)
        {
            _context = context;
        }

        // GET: Confirmaciones
        public async Task<IActionResult> Index()
        {
            var gestorDeActasNetContext = _context.Confirmaciones.Include(c => c.IdMadrinaNavigation).Include(c => c.IdPadrinoNavigation).Include(c => c.IdPersonaNavigation);
            return View(await gestorDeActasNetContext.ToListAsync());
        }

        // GET: Confirmaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmaciones = await _context.Confirmaciones
                .Include(c => c.IdMadrinaNavigation)
                .Include(c => c.IdPadrinoNavigation)
                .Include(c => c.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confirmaciones == null)
            {
                return NotFound();
            }

            return View(confirmaciones);
        }

        // GET: Confirmaciones/Create
        public IActionResult Create()
        {
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            return View();
        }

        // POST: Confirmaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPersona,FechaEvento,IdPadrino,IdMadrina,Libro,Folio,Nota,FechaRegistro,NoRegistro")] Confirmaciones confirmaciones, DateTime fechaReg)
        {
            if (ModelState.IsValid)
            {
                fechaReg = DateTime.Now;
                confirmaciones.FechaRegistro = fechaReg;
                _context.Add(confirmaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdMadrina);
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdPadrino);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdPersona);
            return View(confirmaciones);
        }

        // GET: Confirmaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmaciones = await _context.Confirmaciones.FindAsync(id);
            if (confirmaciones == null)
            {
                return NotFound();
            }
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdMadrina);
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdPadrino);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdPersona);
            return View(confirmaciones);
        }

        // POST: Confirmaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPersona,FechaEvento,IdPadrino,IdMadrina,Libro,Folio,Nota,FechaRegistro,NoRegistro")] Confirmaciones confirmaciones)
        {
            if (id != confirmaciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confirmaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfirmacionesExists(confirmaciones.Id))
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
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdMadrina);
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdPadrino);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "Id", "PrimerApellido", confirmaciones.IdPersona);
            return View(confirmaciones);
        }

        // GET: Confirmaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmaciones = await _context.Confirmaciones
                .Include(c => c.IdMadrinaNavigation)
                .Include(c => c.IdPadrinoNavigation)
                .Include(c => c.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confirmaciones == null)
            {
                return NotFound();
            }

            return View(confirmaciones);
        }

        // POST: Confirmaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confirmaciones = await _context.Confirmaciones.FindAsync(id);
            _context.Confirmaciones.Remove(confirmaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfirmacionesExists(int id)
        {
            return _context.Confirmaciones.Any(e => e.Id == id);
        }
    }
}
