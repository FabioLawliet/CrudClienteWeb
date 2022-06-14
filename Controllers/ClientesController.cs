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
    public class ClientesController : Controller
    {
        private readonly Context _context;

        public ClientesController(Context context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
              return _context.clientes != null ? 
                          View(await _context.clientes.ToListAsync()) :
                          Problem("Entity set 'Context.clientes'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var dbCliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCliente == null)
            {
                return NotFound();
            }

            return View(dbCliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,cpfcnpj,rgie,ativo,endereco,numero,bairro,complemento,cep,idcidade,idestado")] DbCliente dbCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbCliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var dbCliente = await _context.clientes.FindAsync(id);
            if (dbCliente == null)
            {
                return NotFound();
            }
            return View(dbCliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,cpfcnpj,rgie,ativo,endereco,numero,bairro,complemento,cep,idcidade,idestado")] DbCliente dbCliente)
        {
            if (id != dbCliente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbClienteExists(dbCliente.id))
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
            return View(dbCliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var dbCliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCliente == null)
            {
                return NotFound();
            }

            return View(dbCliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.clientes == null)
            {
                return Problem("Entity set 'Context.clientes'  is null.");
            }
            var dbCliente = await _context.clientes.FindAsync(id);
            if (dbCliente != null)
            {
                _context.clientes.Remove(dbCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbClienteExists(int id)
        {
          return (_context.clientes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
