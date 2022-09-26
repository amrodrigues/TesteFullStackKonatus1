using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository.Context;
using Projeto.Repository.Contracts;

namespace Projeto.Repository.Persistence
{
    public class StageRepository : BaseRepository<Stage>, IStageRepository
    {
     
    }
}
