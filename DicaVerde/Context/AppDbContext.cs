
using DicaVerde.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DicaVerde.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //public DbSet<User> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public DbSet<Participacao> Participacoes { get; set; }
        public DbSet<RecursoEducativo> RecursosEducativos { get; set; }
    }
}
