using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DicaVerde.Models
{
    public class Participacao
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Usuário")]
        public string NomeUsuario { get; set; }

        [Required]
        public string Mensagem { get; set; }

        [Display(Name = "Data de Envio")]
        public DateTime DataEnvio { get; set; } = DateTime.Now;

        [Display(Name = "Projeto Relacionado")]
        public int? ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
        public Projeto Projeto { get; set; }
    }
}
