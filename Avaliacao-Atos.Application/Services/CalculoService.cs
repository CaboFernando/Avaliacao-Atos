using AutoMapper;
using Avaliacao_Atos.Application.Interfaces;
using Avaliacao_Atos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao_Atos.Application.Services
{
    public class CalculoService : ICalculoService
    {
        public CalculoService() { }

        public CalculoViewModel GetCalculo(decimal valor_monetario, int qtd_meses)
        {
            if (valor_monetario <= 0)
                throw new Exception("O valor monetário informado deve ser positivo");

            if(qtd_meses <= 1)
                throw new Exception("A quantidade de meses deve ser maior que 1");

            decimal Val_final_bruto;
            decimal Val_final_liquido = 0.00m;
            decimal val = 0.00m;

            if (qtd_meses > 1)
            {
                for (int i = 0; i < qtd_meses; i++)
                {
                    if (val != 0)
                        val = 1 + (1.08m * val);
                    else
                        val = 1 + (1.08m * 0.009m);
                }
            }

            Val_final_bruto = valor_monetario * (val == 0 ? (1 + (1.08m * 0.009m)) : val);

            if (qtd_meses > 1 && qtd_meses < 7)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.225m);
            if (qtd_meses > 6 && qtd_meses < 13)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.2m);
            if (qtd_meses > 12 && qtd_meses < 25)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.175m);
            if (qtd_meses > 24)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.15m);

            var retorno = new CalculoViewModel
            {
                valor_bruto = Math.Round(Val_final_bruto, 2),
                valor_liquido = Math.Round(Val_final_liquido, 2)
            };

            return retorno;
        }

    }
}
