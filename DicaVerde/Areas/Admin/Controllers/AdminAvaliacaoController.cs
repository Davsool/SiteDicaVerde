using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DicaVerde.Models;
using DicaVerde.Context;

namespace DicaVerde.Controllers
{
    public class AdminAvaliacaoController : Controller
    {
        private readonly AppDbContext _context;

        public AdminAvaliacaoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int projetoId)
        {
            ViewBag.ProjetoId = projetoId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                avaliacao.DataCriacao = DateTime.Now;
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Projeto", new { id = avaliacao.ProjetoId });
            }
            return View(avaliacao);
        }
    }
}
