using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class StageCadastroRequest
    {
        //[Required(ErrorMessage = "Por favor, informe o id da etapa.")]
        //public int Id { get; set; }
    
        [Required(ErrorMessage = "Por favor, informe o id da etapa.")]
        public int MaintenanceId { get; set; }

        [Required(ErrorMessage = "Por favor, informe o descrição da etapa.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Por favor, informe o tipo da etapa.")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o status da etapa.")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor da etapa.")]
        public string Value { get; set; }

    }
}