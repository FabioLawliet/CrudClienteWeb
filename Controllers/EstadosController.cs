using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudClienteWeb.Models;

namespace CrudClienteWeb.Controllers
{
    public class EstadosController : Controller
    {
        private readonly Context _context;

        public EstadosController(Context context)
        {
            _context = context;
        }

        // GET: Estados
        public async Task<IActionResult> Index()
        {
              return _context.estados != null ? 
                          View(await _context.estados.ToListAsync()) :
                          Problem("Entity set 'Context.estados'  is null.");
        }

        // GET: Estados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estados == null)
            {
                return NotFound();
            }

            var dbEstado = await _context.estados
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbEstado == null)
            {
                return NotFound();
            }

            return View(dbEstado);
        }

        // GET: Estados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome")] DbEstado dbEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbEstado);
        }

        // GET: Estados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estados == null)
            {
                return NotFound();
            }

            var dbEstado = await _context.estados.FindAsync(id);
            if (dbEstado == null)
            {
                return NotFound();
            }
            return View(dbEstado);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome")] DbEstado dbEstado)
        {
            if (id != dbEstado.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbEstadoExists(dbEstado.id))
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
            return View(dbEstado);
        }

        // GET: Estados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estados == null)
            {
                return NotFound();
            }

            var dbEstado = await _context.estados
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbEstado == null)
            {
                return NotFound();
            }

            return View(dbEstado);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estados == null)
            {
                return Problem("Entity set 'Context.estados'  is null.");
            }
            var dbEstado = await _context.estados.FindAsync(id);
            if (dbEstado != null)
            {
                _context.estados.Remove(dbEstado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbEstadoExists(int id)
        {
          return (_context.estados?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
