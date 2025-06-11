using System;
using System.ComponentModel.DataAnnotations;

namespace DicaVerde.Models
{
    public class RecursoEducativo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "URL do Jogo ou Atividade")]
        public string Url { get; set; }

        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; } = DateTime.Now;

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; } = true;
    }
}
