using System.ComponentModel.DataAnnotations;

namespace DicaVerde.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Texto { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Relacionamentos
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public string UserId { get; set; }
        public User Usuario { get; set; }
    }
}
