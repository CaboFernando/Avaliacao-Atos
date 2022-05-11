using Avaliacao_Atos.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
    }
}
