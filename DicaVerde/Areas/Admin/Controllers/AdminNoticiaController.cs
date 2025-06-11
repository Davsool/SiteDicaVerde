using Microsoft.AspNetCore.Mvc;
using DicaVerde.Models;
using System.Linq;
using DicaVerde.Context;

namespace DicaVerde.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNoticiaController : Controller
    {
        private readonly AppDbContext _context;

        public AdminNoticiaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var noticias = _context.Noticias.OrderByDescending(n => n.DataPublicacao).ToList();
            return View(noticias);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _context.Noticias.Add(noticia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        public IActionResult Edit(int id)
        {
            var noticia = _context.Noticias.Find(id);
            if (noticia == null) return NotFound();
            return View(noticia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _context.Noticias.Update(noticia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        public IActionResult Delete(int id)
        {
            var noticia = _context.Noticias.Find(id);
            if (noticia == null) return NotFound();
            return View(noticia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var noticia = _context.Noticias.Find(id);
            _context.Noticias.Remove(noticia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var noticia = _context.Noticias.Find(id);
            if (noticia == null) return NotFound();
            return View(noticia);
        }
    }
}
