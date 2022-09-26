using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Business.Contracts;
using Projeto.Repository.Contracts;
using Projeto.Entities;

namespace Projeto.Business.Persistence
{
   public class MaintenanceBusiness : BaseBusiness<Maintenance> , IMaintenanceBusiness
    {
        private IMaintenanceRepository repository;

        public MaintenanceBusiness(IMaintenanceRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
