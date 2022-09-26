using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models.Request
{
    public class StageExcluirRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id da etapa.")]
        public int Id { get; set; }

    }
}