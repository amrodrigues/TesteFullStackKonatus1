using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Projeto.Services.Models.Request
{
    public class MaintenanceCadastroRequest
    {
        //     [Required(ErrorMessage = "Por favor, informe o id da manutenção.")]
        //      public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o usuário da manutenção.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Por favor, informe o descrição da manutenção.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o status da manutenção.")]
        public bool Status { get; set; }


    }
}