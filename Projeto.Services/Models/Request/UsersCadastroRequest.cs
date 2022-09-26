using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models.Request
{
    public class UsersCadastroRequest
    {
       [Required(ErrorMessage ="Por favor, informe o id do usuário.")]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Por favor, informe o login do usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe o passord do usuário.")]
        public string Password { get; set; }

    }
}