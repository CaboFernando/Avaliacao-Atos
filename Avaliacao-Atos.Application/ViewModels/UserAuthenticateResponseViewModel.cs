using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Application.ViewModels
{
    public class UserAuthenticateResponseViewModel
    {
        public UserAuthenticateResponseViewModel(UserViewModel _user, string _token)
        {
            user = _user;
            token = _token;
        }

        public UserViewModel user { get; set; }
        public string token { get; set; }
    }
}
