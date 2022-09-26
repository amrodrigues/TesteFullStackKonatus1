using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class UsersExcluirRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id do usuário.")]
        public int Id { get; set; }
    }
}