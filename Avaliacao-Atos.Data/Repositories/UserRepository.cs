using Avaliacao_Atos.Data.Context;
using Avaliacao_Atos.Domain.Entites;
using Avaliacao_Atos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
