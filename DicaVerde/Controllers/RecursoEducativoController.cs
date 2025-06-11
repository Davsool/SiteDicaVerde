using Microsoft.AspNetCore.Mvc;
using DicaVerde.Context;
using System.Linq;

namespace DicaVerde.Controllers
{
    public class RecursoEducativoController : Controller
    {
        private readonly AppDbContext _context;

        public RecursoEducativoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var recursos = _context.RecursosEducativos
                .Where(r => r.Ativo)
                .OrderByDescending(r => r.DataPublicacao)
                .ToList();

            return View(recursos);
        }

        public IActionResult Details(int id)
        {
            var recurso = _context.RecursosEducativos.FirstOrDefault(r => r.Id == id && r.Ativo);
            if (recurso == null) return NotFound();

            return View(recurso);
        }
    }
}
