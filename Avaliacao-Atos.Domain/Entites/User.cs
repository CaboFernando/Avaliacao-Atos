using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Domain.Entites
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
