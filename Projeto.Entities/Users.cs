using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Maintenance> Maintenances { get; set; }

        public Users()
        {

        }

        public Users (int id , string login , string password, DateTime createAt)
        {
            id = Id;
            login = Login;
            password = Password;
            createAt = CreatedAt; 
        }

    }

}
