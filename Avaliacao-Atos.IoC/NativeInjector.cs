using Avaliacao_Atos.Application.Interfaces;
using Avaliacao_Atos.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Avaliacao_Atos.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();


        }
    }
}
