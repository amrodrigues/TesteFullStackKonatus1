using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models.Request
{
    public class StageConsultaRequest
    {
        public int Id { get; set; }
        public int MaintenanceId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public int Type { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }

        // chave estrangeira
       // public Maintenance Maintenance { get; set; }
    }
}