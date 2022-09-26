using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models.Request
{
    public class UsersConsultaRequest
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}