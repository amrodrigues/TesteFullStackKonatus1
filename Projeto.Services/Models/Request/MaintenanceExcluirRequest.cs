using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models.Request
{
    public class MaintenanceExcluirRequest
    {
           [Required(ErrorMessage = "Por favor, informe o id da manutenção.")]
             public int Id { get; set; }
    }
}