using Avaliacao_Atos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Application.Interfaces
{
    public interface ICalculoService
    {
        CalculoViewModel GetCalculo(double valor_monetario, int qtd_meses);
    }
}
