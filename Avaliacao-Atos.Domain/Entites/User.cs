using Avaliacao_Atos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Domain.Entites
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
