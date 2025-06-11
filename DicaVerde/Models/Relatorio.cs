using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DicaVerde.Models
{
    public class Relatorio
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; }

        [Display(Name = "Arquivo (PDF)")]
        public string CaminhoArquivo { get; set; }

        // Relacionamento com Projeto (opcional)
        [Display(Name = "Projeto")]
        public int? ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
        public Projeto Projeto { get; set; }
    }
}
