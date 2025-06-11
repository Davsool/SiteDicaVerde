using DicaVerde.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DicaVerde.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly AppDbContext _context;

        public AdminDashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var totalUsuarios = _context.Usuarios.Count();
            var totalProjetos = _context.Projetos.Count();
            var totalNoticias = _context.Noticias.Count();
            var totalRelatorios = _context.Relatorios.Count();

            var model = new DashboardViewModel
            {
                //TotalUsuarios = totalUsuarios,
                TotalProjetos = totalProjetos,
                TotalNoticias = totalNoticias,
                TotalRelatorios = totalRelatorios
            };

            return View(model);
        }

    }

    public class DashboardViewModel
    {
        public int TotalUsuarios { get; set; }
        public int TotalProjetos { get; set; }
        public int TotalNoticias { get; set; }
        public int TotalRelatorios { get; set; }

    }
}
