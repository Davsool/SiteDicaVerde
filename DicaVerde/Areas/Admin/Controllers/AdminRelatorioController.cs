using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DicaVerde.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using DicaVerde.Context;

namespace DicaVerde.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRelatorioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminRelatorioController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var relatorios = await _context.Relatorios.Include(r => r.Projeto).ToListAsync();
            return View(relatorios);
        }

        public IActionResult Create()
        {
            ViewBag.Projetos = _context.Projetos.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Relatorio relatorio, IFormFile arquivo)
        {
            if (arquivo != null && arquivo.Length > 0)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploads);

                var filePath = Path.Combine(uploads, arquivo.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                relatorio.CaminhoArquivo = "/uploads/" + arquivo.FileName;
            }

            relatorio.DataPublicacao = DateTime.Now;

            _context.Add(relatorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var relatorio = await _context.Relatorios.Include(r => r.Projeto).FirstOrDefaultAsync(r => r.Id == id);
            return View(relatorio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            ViewBag.Projetos = _context.Projetos.ToList();
            return View(relatorio);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Relatorio relatorio)
        {
            _context.Update(relatorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            return View(relatorio);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            _context.Relatorios.Remove(relatorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
