using System.Collections.Generic;
using DicaVerde.Models;

namespace DicaVerde.ViewModels
{
    public class HomeViewModel
    {
        public List<Noticia> Noticias { get; set; }
        public List<RecursoEducativo> RecursosEducativos { get; set; }
    }
}
