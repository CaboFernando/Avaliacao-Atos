using Avaliacao_Atos.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538"), Name = "User Default", Email = "userdefault@atos.com" }
                );

            return builder;
        }
    }
}
