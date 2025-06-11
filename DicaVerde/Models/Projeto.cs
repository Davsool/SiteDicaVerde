using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DicaVerde.Models
{
    public class Projeto
    {

        public Projeto()
        {
            Comentarios = new List<Comentario>();
            Avaliacoes = new List<Avaliacao>();
        }


        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O responsável é obrigatório")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }

        public bool Ativo { get; set; } = true;

        [BindNever]
        public List<Comentario> Comentarios { get; set; }

        [BindNever]
        public List<Avaliacao> Avaliacoes { get; set; }
    }
}