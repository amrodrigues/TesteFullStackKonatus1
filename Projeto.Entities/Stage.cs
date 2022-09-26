using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Stage
    {
    public int Id { get; set; }
    public int MaintenanceId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public int Type { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
    
        // chave estrangeira
        public Maintenance Maintenance { get; set; }
    public Stage()
    {

    }

    public Stage(int id, int maintenanceId , string description, bool status , int type, string value , DateTime createdAt)
    {
        Id = id;
        MaintenanceId = maintenanceId;
        Description = description;
            Type = type;
            Status = status;
            Value = value;
            CreatedAt = createdAt;
    }
}
}