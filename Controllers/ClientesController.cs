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
            /*
              return _context.cliente != null ? 
                          View(await _context.cliente.ToListAsync()) :
                          Problem("Entity set 'Context.cliente'  is null.");*/

            List<DbCliente> lista = (from c in _context.cliente
                                      join e in _context.estado on c.idestado equals e.idestado
                                      orderby c.nome
                                      select new DbCliente
                                      {
                                          id = c.id,
                                          nome = c.nome,
                                          cpfcnpj = c.cpfcnpj,
                                          rgie = c.rgie,
                                          ativo = c.ativo
                                      }).ToList();
            return View(lista);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cliente == null)
            {
                return NotFound();
            }

            var DtoCli = (from c in _context.cliente
                         join e in _context.estado on c.idestado equals e.idestado
                         where c.id == id
                         orderby c.nome
                         select new DtoCliente
                         {
                             id = c.id,
                             nome = c.nome,
                             cpfcnpj = c.cpfcnpj,
                             rgie = c.rgie,
                             ativo = c.ativo,
                             endereco = c.endereco,
                             numero = c.numero,
                             bairro = c.bairro,
                             complemento = c.complemento,
                             cep = c.cep,
                             nomecidade = c.nomecidade,
                             idestado = c.idestado,
                             siglaestado = e.sigla
                         }).First();

            if (DtoCli == null)
            {
                return NotFound();
            }

            ViewBag.Estado = new SelectList(_context.estado, "idestado", "sigla");

            return View(DtoCli);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewBag.Estado = new SelectList(_context.estado, "idestado", "sigla");

            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,cpfcnpj,rgie,ativo,endereco,numero,bairro,complemento,cep,nomecidade,idestado")] DbCliente dbCliente)
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
            if (id == null || _context.cliente == null)
            {
                return NotFound();
            }

            var DbCli = (from c in _context.cliente
                         join e in _context.estado on c.idestado equals e.idestado
                         where c.id == id
                         orderby c.nome
                         select new DbCliente
                         {
                             id = c.id,
                             nome = c.nome,
                             cpfcnpj = c.cpfcnpj,
                             rgie = c.rgie,
                             ativo = c.ativo,
                             endereco = c.endereco,
                             numero = c.numero,
                             bairro = c.bairro,
                             complemento = c.complemento,
                             cep = c.cep,
                             nomecidade = c.nomecidade,
                             idestado = c.idestado
                         }).First();

            if (DbCli == null)
            {
                return NotFound();
            }

            ViewBag.Estado = new SelectList(_context.estado, "idestado", "sigla");

            return View(DbCli);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,cpfcnpj,rgie,ativo,endereco,numero,bairro,complemento,cep,nomecidade,idestado")] DbCliente dbCliente)
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
            if (id == null || _context.cliente == null)
            {
                return NotFound();
            }

            var DtoCli = (from c in _context.cliente
                          join e in _context.estado on c.idestado equals e.idestado
                          where c.id == id
                          orderby c.nome
                          select new DtoCliente
                          {
                              id = c.id,
                              nome = c.nome,
                              cpfcnpj = c.cpfcnpj,
                              rgie = c.rgie,
                              ativo = c.ativo,
                              endereco = c.endereco,
                              numero = c.numero,
                              bairro = c.bairro,
                              complemento = c.complemento,
                              cep = c.cep,
                              nomecidade = c.nomecidade,
                              idestado = c.idestado,
                              siglaestado = e.sigla
                          }).First();

            if (DtoCli == null)
            {
                return NotFound();
            }

            ViewBag.Estado = new SelectList(_context.estado, "idestado", "sigla");

            return View(DtoCli);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cliente == null)
            {
                return Problem("Entity set 'Context.cliente'  is null.");
            }
            var dbCliente = await _context.cliente.FindAsync(id);
            if (dbCliente != null)
            {
                _context.cliente.Remove(dbCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbClienteExists(int id)
        {
          return (_context.cliente?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
