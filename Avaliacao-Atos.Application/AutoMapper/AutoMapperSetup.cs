using AutoMapper;
using Avaliacao_Atos.Application.ViewModels;
using Avaliacao_Atos.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel -> Domain

            CreateMap<UserViewModel, User>();

            #endregion

            #region Domain -> ViewModel

            CreateMap<User, UserViewModel>();

            #endregion
        }
    }
}
