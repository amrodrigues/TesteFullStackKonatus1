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
    public class UsersBusiness : BaseBusiness<Users>, IUsersBusiness
    {
        private IUsersRepository repository;

        public UsersBusiness(IUsersRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
