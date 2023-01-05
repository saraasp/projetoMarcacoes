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
    public class Funcionario_ServicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Funcionario_ServicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionario_Servico
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tfuncionario_servico.Include(f => f.Funcionario).Include(f => f.Servico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Funcionario_Servico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tfuncionario_servico == null)
            {
                return NotFound();
            }

            var funcionario_Servico = await _context.Tfuncionario_servico
                .Include(f => f.Funcionario)
                .Include(f => f.Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario_Servico == null)
            {
                return NotFound();
            }

            return View(funcionario_Servico);
        }

        // GET: Funcionario_Servico/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Nome");
            ViewData["ServicoId"] = new SelectList(_context.Tservicos, "Id", "Nome");
            return View();
        }

        // POST: Funcionario_Servico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuncionarioId,ServicoId")] Funcionario_Servico funcionario_Servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario_Servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Nome", funcionario_Servico.FuncionarioId);
            ViewData["ServicoId"] = new SelectList(_context.Tservicos, "Id", "Nome", funcionario_Servico.ServicoId);
            return View(funcionario_Servico);
        }

        // GET: Funcionario_Servico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tfuncionario_servico == null)
            {
                return NotFound();
            }

            var funcionario_Servico = await _context.Tfuncionario_servico.FindAsync(id);
            if (funcionario_Servico == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Nome", funcionario_Servico.FuncionarioId);
            ViewData["ServicoId"] = new SelectList(_context.Tservicos, "Id", "Nome", funcionario_Servico.ServicoId);
            return View(funcionario_Servico);
        }

        // POST: Funcionario_Servico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuncionarioId,ServicoId")] Funcionario_Servico funcionario_Servico)
        {
            if (id != funcionario_Servico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario_Servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Funcionario_ServicoExists(funcionario_Servico.Id))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Nome", funcionario_Servico.FuncionarioId);
            ViewData["ServicoId"] = new SelectList(_context.Tservicos, "Id", "Nome", funcionario_Servico.ServicoId);
            return View(funcionario_Servico);
        }

        // GET: Funcionario_Servico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tfuncionario_servico == null)
            {
                return NotFound();
            }

            var funcionario_Servico = await _context.Tfuncionario_servico
                .Include(f => f.Funcionario)
                .Include(f => f.Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario_Servico == null)
            {
                return NotFound();
            }

            return View(funcionario_Servico);
        }

        // POST: Funcionario_Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tfuncionario_servico == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tfuncionario_servico'  is null.");
            }
            var funcionario_Servico = await _context.Tfuncionario_servico.FindAsync(id);
            if (funcionario_Servico != null)
            {
                _context.Tfuncionario_servico.Remove(funcionario_Servico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Funcionario_ServicoExists(int id)
        {
          return (_context.Tfuncionario_servico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
