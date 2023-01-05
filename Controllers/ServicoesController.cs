using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetoMarcacoes.Data;
using projetoMarcacoes.Models;

namespace projetoMarcacoes.Controllers
{
    public class ServicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Servicoes
        public async Task<IActionResult> Index()
        {
              return _context.Tservicos != null ? 
                          View(await _context.Tservicos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Tservicos'  is null.");
        }

        // GET: Servicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tservicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Tservicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Servicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Custo,DuracaoHora")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servico);
        }

        // GET: Servicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tservicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Tservicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }

        // POST: Servicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Custo,DuracaoHora")] Servico servico)
        {
            if (id != servico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.Id))
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
            return View(servico);
        }

        // GET: Servicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tservicos == null)
            {
                return NotFound();
            }

            var servico = await _context.Tservicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Servicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tservicos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tservicos'  is null.");
            }
            var servico = await _context.Tservicos.FindAsync(id);
            if (servico != null)
            {
                _context.Tservicos.Remove(servico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
          return (_context.Tservicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
