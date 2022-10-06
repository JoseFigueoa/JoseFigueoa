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
    public class BautizosController : Controller
    {
        private readonly GestorDeActasNetContext _context;

        public BautizosController(GestorDeActasNetContext context)
        {
            _context = context;
        }

        // GET: Bautizos
        public async Task<IActionResult> Index()
        {
            var gestorDeActasNetContext = _context.Bautizos.Include(b => b.IdMadreNavigation).Include(b => b.IdMadrinaNavigation).Include(b => b.IdNombreNavigation).Include(b => b.IdPadreNavigation).Include(b => b.IdPadrinoNavigation);
            return View(await gestorDeActasNetContext.ToListAsync());
        }

        // GET: Bautizos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bautizos = await _context.Bautizos
                .Include(b => b.IdMadreNavigation)
                .Include(b => b.IdMadrinaNavigation)
                .Include(b => b.IdNombreNavigation)
                .Include(b => b.IdPadreNavigation)
                .Include(b => b.IdPadrinoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bautizos == null)
            {
                return NotFound();
            }

            return View(bautizos);
        }

        // GET: Bautizos/Create
        public IActionResult Create()
        {
            ViewData["IdMadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            ViewData["IdNombre"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            ViewData["IdPadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            return View();
        }

        // POST: Bautizos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdNombre,FechaEvento,IdPadre,IdMadre,IdPadrino,IdMadrina,Libro,Folio,Nota,FechaRegistro,NoRegistro")] Bautizos bautizos, DateTime fechaReg)
        {
            if (ModelState.IsValid)
            {


                string Date = DateTime.Now.ToShortDateString().ToString();
              
                fechaReg = DateTime.Parse(Date);
              
                bautizos.FechaRegistro =fechaReg;
                _context.Add(bautizos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdMadre);
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdMadrina);
            ViewData["IdNombre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdNombre);
            ViewData["IdPadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdPadre);
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdPadrino);
            return View(bautizos);
        }

        // GET: Bautizos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bautizos = await _context.Bautizos.FindAsync(id);
            if (bautizos == null)
            {
                return NotFound();
            }
            ViewData["IdMadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdMadre);
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdMadrina);
            ViewData["IdNombre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdNombre);
            ViewData["IdPadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdPadre);
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdPadrino);
            return View(bautizos);
        }

        // POST: Bautizos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdNombre,FechaEvento,IdPadre,IdMadre,IdPadrino,IdMadrina,Libro,Folio,Nota,FechaRegistro,NoRegistro")] Bautizos bautizos)
        {
            if (id != bautizos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bautizos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BautizosExists(bautizos.Id))
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
            ViewData["IdMadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdMadre);
            ViewData["IdMadrina"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdMadrina);
            ViewData["IdNombre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdNombre);
            ViewData["IdPadre"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdPadre);
            ViewData["IdPadrino"] = new SelectList(_context.Personas, "Id", "PrimerApellido", bautizos.IdPadrino);
            return View(bautizos);
        }

        // GET: Bautizos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bautizos = await _context.Bautizos
                .Include(b => b.IdMadreNavigation)
                .Include(b => b.IdMadrinaNavigation)
                .Include(b => b.IdNombreNavigation)
                .Include(b => b.IdPadreNavigation)
                .Include(b => b.IdPadrinoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bautizos == null)
            {
                return NotFound();
            }

            return View(bautizos);
        }

        // POST: Bautizos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bautizos = await _context.Bautizos.FindAsync(id);
            _context.Bautizos.Remove(bautizos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BautizosExists(int id)
        {
            return _context.Bautizos.Any(e => e.Id == id);
        }
    }
}
