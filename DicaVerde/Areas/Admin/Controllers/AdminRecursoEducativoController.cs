using Microsoft.AspNetCore.Mvc;
using DicaVerde.Models;
using DicaVerde.Context;
using System.Linq;

namespace DicaVerde.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRecursoEducativoController : Controller
    {
        private readonly AppDbContext _context;

        public AdminRecursoEducativoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var recursos = _context.RecursosEducativos
                                   .OrderByDescending(r => r.DataPublicacao)
                                   .ToList();
            return View(recursos);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecursoEducativo recurso)
        {
            if (ModelState.IsValid)
            {
                _context.RecursosEducativos.Add(recurso);
                _context.SaveChanges();
                TempData["Sucesso"] = "Recurso cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        public IActionResult Edit(int id)
        {
            var recurso = _context.RecursosEducativos.Find(id);
            if (recurso == null) return NotFound();
            return View(recurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RecursoEducativo recurso)
        {
            if (ModelState.IsValid)
            {
                _context.RecursosEducativos.Update(recurso);
                _context.SaveChanges();
                TempData["Sucesso"] = "Recurso atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        public IActionResult Delete(int id)
        {
            var recurso = _context.RecursosEducativos.Find(id);
            if (recurso == null) return NotFound();
            return View(recurso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var recurso = _context.RecursosEducativos.Find(id);
            _context.RecursosEducativos.Remove(recurso);
            _context.SaveChanges();
            TempData["Sucesso"] = "Recurso removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var recurso = _context.RecursosEducativos.Find(id);
            if (recurso == null) return NotFound();
            return View(recurso);
        }
    }
}
