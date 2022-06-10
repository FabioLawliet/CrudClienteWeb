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
    public class CidadesController : Controller
    {
        private readonly Context _context;

        public CidadesController(Context context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
              return _context.cidades != null ? 
                          View(await _context.cidades.ToListAsync()) :
                          Problem("Entity set 'Context.cidades'  is null.");
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cidades == null)
            {
                return NotFound();
            }

            var dbCidade = await _context.cidades
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCidade == null)
            {
                return NotFound();
            }

            return View(dbCidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome")] DbCidade dbCidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbCidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbCidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cidades == null)
            {
                return NotFound();
            }

            var dbCidade = await _context.cidades.FindAsync(id);
            if (dbCidade == null)
            {
                return NotFound();
            }
            return View(dbCidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome")] DbCidade dbCidade)
        {
            if (id != dbCidade.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbCidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbCidadeExists(dbCidade.id))
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
            return View(dbCidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cidades == null)
            {
                return NotFound();
            }

            var dbCidade = await _context.cidades
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCidade == null)
            {
                return NotFound();
            }

            return View(dbCidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cidades == null)
            {
                return Problem("Entity set 'Context.cidades'  is null.");
            }
            var dbCidade = await _context.cidades.FindAsync(id);
            if (dbCidade != null)
            {
                _context.cidades.Remove(dbCidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbCidadeExists(int id)
        {
          return (_context.cidades?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
