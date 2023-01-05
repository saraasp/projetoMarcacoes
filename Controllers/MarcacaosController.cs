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
    public class MarcacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarcacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marcacaos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tmarcacoes.Include(m => m.Cliente).Include(m => m.Funcionario_Servico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Marcacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tmarcacoes == null)
            {
                return NotFound();
            }

            var marcacao = await _context.Tmarcacoes
                .Include(m => m.Cliente)
                .Include(m => m.Funcionario_Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcacao == null)
            {
                return NotFound();
            }

            return View(marcacao);
        }

        // GET: Marcacaos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Nome");
            ViewData["Funcionario_ServicoId"] = new SelectList(_context.Tfuncionario_servico, "Id", "Id");
            return View();
        }

        // POST: Marcacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Hora,ClienteId,Funcionario_ServicoId")] Marcacao marcacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Nome", marcacao.ClienteId);
            ViewData["Funcionario_ServicoId"] = new SelectList(_context.Tfuncionario_servico, "Id", "Id", marcacao.Funcionario_ServicoId);
            return View(marcacao);
        }

        // GET: Marcacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tmarcacoes == null)
            {
                return NotFound();
            }

            var marcacao = await _context.Tmarcacoes.FindAsync(id);
            if (marcacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Nome", marcacao.ClienteId);
            ViewData["Funcionario_ServicoId"] = new SelectList(_context.Tfuncionario_servico, "Id", "Id", marcacao.Funcionario_ServicoId);
            return View(marcacao);
        }

        // POST: Marcacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Hora,ClienteId,Funcionario_ServicoId")] Marcacao marcacao)
        {
            if (id != marcacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcacaoExists(marcacao.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Nome", marcacao.ClienteId);
            ViewData["Funcionario_ServicoId"] = new SelectList(_context.Tfuncionario_servico, "Id", "Id", marcacao.Funcionario_ServicoId);
            return View(marcacao);
        }

        // GET: Marcacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tmarcacoes == null)
            {
                return NotFound();
            }

            var marcacao = await _context.Tmarcacoes
                .Include(m => m.Cliente)
                .Include(m => m.Funcionario_Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcacao == null)
            {
                return NotFound();
            }

            return View(marcacao);
        }

        // POST: Marcacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tmarcacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tmarcacoes'  is null.");
            }
            var marcacao = await _context.Tmarcacoes.FindAsync(id);
            if (marcacao != null)
            {
                _context.Tmarcacoes.Remove(marcacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcacaoExists(int id)
        {
          return (_context.Tmarcacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
