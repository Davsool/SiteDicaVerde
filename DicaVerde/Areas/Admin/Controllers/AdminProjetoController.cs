using DicaVerde.Context;
using DicaVerde.Models;
using DicaVerde.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DicaVerde.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProjetoController : Controller
    {
        private readonly AppDbContext _context;

        public AdminProjetoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Projeto
        public async Task<IActionResult> Index()
        {
            var projetos = await _context.Projetos.ToListAsync();

            // Converter lista de entidades para lista de ViewModels
            var viewModelList = projetos.Select(p => new ProjetoViewmodel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Responsavel = p.Responsavel,
                DataInicio = p.DataInicio,
                DataFim = p.DataFim,
                Ativo = p.Ativo
            }).ToList();

            return View(viewModelList);
        }

        // GET: Projeto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.Id == id);
            if (projeto == null) return NotFound();

            // Converter para ViewModel
            var viewModel = new Projeto
            {
                Id = projeto.Id,
                Nome = projeto.Nome,
                Descricao = projeto.Descricao,
                Responsavel = projeto.Responsavel,
                DataInicio = projeto.DataInicio,
                DataFim = projeto.DataFim,
                Ativo = projeto.Ativo,
                Avaliacoes = projeto.Avaliacoes,
                Comentarios = projeto.Comentarios,
            };

            return View(viewModel);
        }

        // GET: Projeto/Create
        public IActionResult Create()
        {
            // Retorna uma ViewModel vazia para o formulário
            return View(new ProjetoViewmodel());
        }

        // POST: Projeto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjetoViewmodel projeto)
        {
            if (ModelState.IsValid)
            {
                var entity = new Projeto
                {
                    Nome = projeto.Nome,
                    Descricao = projeto.Descricao,
                    Responsavel = projeto.Responsavel,
                    DataInicio = projeto.DataInicio,
                    DataFim = projeto.DataFim,
                    Ativo = projeto.Ativo,
                    Comentarios = new List<Comentario>(),
                    Avaliacoes = new List<Avaliacao>()
                };

                _context.Add(entity);
                await _context.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Projeto criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            return View(projeto);
        }

        // GET: Projeto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null) return NotFound();

            // Converter entidade para ViewModel para popular o formulário
            var viewModel = new ProjetoViewmodel
            {
                Id = projeto.Id,
                Nome = projeto.Nome,
                Descricao = projeto.Descricao,
                Responsavel = projeto.Responsavel,
                DataInicio = projeto.DataInicio,
                DataFim = projeto.DataFim,
                Ativo = projeto.Ativo
            };

            return View(viewModel);
        }

        // POST: Projeto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjetoViewmodel projeto)
        {
            if (id != projeto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await _context.Projetos.FindAsync(id);
                    if (entity == null) return NotFound();

                    entity.Nome = projeto.Nome;
                    entity.Descricao = projeto.Descricao;
                    entity.Responsavel = projeto.Responsavel;
                    entity.DataInicio = projeto.DataInicio;
                    entity.DataFim = projeto.DataFim;
                    entity.Ativo = projeto.Ativo;

                    _context.Update(entity);
                    await _context.SaveChangesAsync();

                    TempData["MensagemSucesso"] = "Projeto atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            return View(projeto);
        }

        // GET: Projeto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.Id == id);
            if (projeto == null) return NotFound();

            // Converter para ViewModel para a View Delete (caso necessário)
            var viewModel = new ProjetoViewmodel
            {
                Id = projeto.Id,
                Nome = projeto.Nome,
                Descricao = projeto.Descricao,
                Responsavel = projeto.Responsavel,
                DataInicio = projeto.DataInicio,
                DataFim = projeto.DataFim,
                Ativo = projeto.Ativo
            };

            return View(viewModel);
        }

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projetos.Any(e => e.Id == id);
        }
    }
}
