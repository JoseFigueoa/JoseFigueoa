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
    public class MatrimoniosController : Controller
    {
        private readonly GestorDeActasNetContext _context;

        public MatrimoniosController(GestorDeActasNetContext context)
        {
            _context = context;
        }

        // GET: Matrimonios
        public async Task<IActionResult> Index()
        {
            var gestorDeActasNetContext = _context.Matrimonios.Include(m => m.IdEsposaNavigation).Include(m => m.IdEsposoNavigation);
            return View(await gestorDeActasNetContext.ToListAsync());
        }

        // GET: Matrimonios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrimonios = await _context.Matrimonios
                .Include(m => m.IdEsposaNavigation)
                .Include(m => m.IdEsposoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matrimonios == null)
            {
                return NotFound();
            }

            return View(matrimonios);
        }

        // GET: Matrimonios/Create
        public IActionResult Create()
        {
            ViewData["IdEsposa"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            ViewData["IdEsposo"] = new SelectList(_context.Personas, "Id", "PrimerApellido");
            return View();
        }

        // POST: Matrimonios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEsposo,IdEsposa,FechaEvento,Libro,Folio,Nota,FechaRegistro,NoRegistro")] Matrimonios matrimonios, DateTime fechaReg)
        {
            if (ModelState.IsValid)
            {
                fechaReg = DateTime.Now;
                matrimonios.FechaRegistro = fechaReg;
                _context.Add(matrimonios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEsposa"] = new SelectList(_context.Personas, "Id", "PrimerApellido", matrimonios.IdEsposa);
            ViewData["IdEsposo"] = new SelectList(_context.Personas, "Id", "PrimerApellido", matrimonios.IdEsposo);
            return View(matrimonios);
        }

        // GET: Matrimonios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrimonios = await _context.Matrimonios.FindAsync(id);
            if (matrimonios == null)
            {
                return NotFound();
            }
            ViewData["IdEsposa"] = new SelectList(_context.Personas, "Id", "PrimerApellido", matrimonios.IdEsposa);
            ViewData["IdEsposo"] = new SelectList(_context.Personas, "Id", "PrimerApellido", matrimonios.IdEsposo);
            return View(matrimonios);
        }

        // POST: Matrimonios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEsposo,IdEsposa,FechaEvento,Libro,Folio,Nota,FechaRegistro,NoRegistro")] Matrimonios matrimonios)
        {
            if (id != matrimonios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matrimonios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatrimoniosExists(matrimonios.Id))
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
            ViewData["IdEsposa"] = new SelectList(_context.Personas, "Id", "PrimerApellido", matrimonios.IdEsposa);
            ViewData["IdEsposo"] = new SelectList(_context.Personas, "Id", "PrimerApellido", matrimonios.IdEsposo);
            return View(matrimonios);
        }

        // GET: Matrimonios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrimonios = await _context.Matrimonios
                .Include(m => m.IdEsposaNavigation)
                .Include(m => m.IdEsposoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matrimonios == null)
            {
                return NotFound();
            }

            return View(matrimonios);
        }

        // POST: Matrimonios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matrimonios = await _context.Matrimonios.FindAsync(id);
            _context.Matrimonios.Remove(matrimonios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatrimoniosExists(int id)
        {
            return _context.Matrimonios.Any(e => e.Id == id);
        }
    }
}
