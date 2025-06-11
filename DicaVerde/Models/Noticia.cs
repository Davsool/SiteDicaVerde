using System;
using System.ComponentModel.DataAnnotations;

namespace DicaVerde.Models
{
    public class Noticia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        public string Conteudo { get; set; }

        [Display(Name = "Data de Publicação")]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        //[StringLength(200)]
        //public string ImagemUrl { get; set; }
    }
}
