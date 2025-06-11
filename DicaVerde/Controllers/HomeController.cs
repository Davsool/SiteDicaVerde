using Microsoft.AspNetCore.Mvc;
using DicaVerde.Context;
using DicaVerde.ViewModels;
using System.Linq;

namespace DicaVerde.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Noticias = _context.Noticias
                    .OrderByDescending(n => n.DataPublicacao)
                    .Take(3)
                    .ToList(),

                RecursosEducativos = _context.RecursosEducativos
                    .Where(r => r.Ativo)
                    .OrderByDescending(r => r.DataPublicacao)
                    .Take(3)
                    .ToList()
            };

            return View(viewModel);
        }

        public IActionResult Sobre() => View();

        public IActionResult Contato() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
