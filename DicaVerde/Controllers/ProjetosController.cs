using DicaVerde.Context;
using DicaVerde.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DicaVerde.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly AppDbContext _context;

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Projetos
        public IActionResult Index()
        {
            var projetos = _context.Projetos.Where(p => p.Ativo).ToList();
            return View(projetos);
        }

        // GET: /Projetos/Details/5
        public IActionResult Details(int id)
        {
            var projeto = _context.Projetos
                .Include(p => p.Comentarios)
                .Include(p => p.Avaliacoes)
                .FirstOrDefault(p => p.Id == id);

            if (projeto == null) return NotFound();

            ViewBag.Media = projeto.Avaliacoes.Any()
                ? projeto.Avaliacoes.Average(a => a.Nota)
                : 0;

            return View(projeto);
        }

        // POST: /Projetos/Comentar
        [HttpPost]
        [Authorize]
        public IActionResult Comentar(int projetoId, string texto, int nota)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
           

            var comentario = new Comentario
            {
                ProjetoId = projetoId,
                Texto = texto,
                UserId = userId
            };

            var avaliacao = new Avaliacao
            {
                ProjetoId = projetoId,
                Nota = nota,
                UserId = userId
            };

            _context.Comentarios.Add(comentario);
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = projetoId });
        }
    }
}
