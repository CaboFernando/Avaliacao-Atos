using Avaliacao_Atos.Application.Interfaces;
using Avaliacao_Atos.Application.Services;
using Avaliacao_Atos.Data.Repositories;
using Avaliacao_Atos.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Avaliacao_Atos.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICalculoService, CalculoService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion


        }
    }
}
