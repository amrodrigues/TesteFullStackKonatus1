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
    
   public class StageBusiness : BaseBusiness<Stage>, IStageBusiness
    {
        private IStageRepository repository;

        public StageBusiness(IStageRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
