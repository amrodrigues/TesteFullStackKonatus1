using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
   public class Maintenance
    {
        public int Id   { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Users Users { get; set; }

        public List<Stage> Stages { get; set; }

        public Maintenance()
        {

        }

        public Maintenance (int id , int userId , string descripiton , bool status, DateTime createdAd)
        {
            id = Id;
            userId = UserId;
            descripiton = Description;
            status = Status;
            createdAd = CreatedAt;
        }

    }
}
