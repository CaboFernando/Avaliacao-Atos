using Avaliacao_Atos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Application.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(string id);
        List<UserViewModel> Get();
        bool Post(UserViewModel userViewModel);
        bool Put(UserViewModel userViewModel);


    }
}
