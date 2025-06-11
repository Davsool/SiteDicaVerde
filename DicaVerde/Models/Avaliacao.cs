using DicaVerde.Models;
using System.ComponentModel.DataAnnotations;

namespace DicaVerde.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Nota { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public string UserId { get; set; }
        public User Usuario { get; set; }
    }
}

