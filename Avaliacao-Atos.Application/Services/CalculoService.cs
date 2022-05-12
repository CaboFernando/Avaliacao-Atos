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
        private readonly IMapper mapper;

        public CalculoService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public CalculoViewModel GetCalculo(double valor_monetario, int qtd_meses)
        {
            double Val_final_bruto;
            double Val_final_liquido = 0.00;
            double val = 0.00;

            if (qtd_meses > 1)
            {
                for (int i = 0; i < qtd_meses; i++)
                {
                    if (val != 0)
                        val = 1 + (1.08 * val);
                    else
                        val = 1 + (1.08 * 0.009);
                }
            }

            Val_final_bruto = valor_monetario * (val == 0 ? (1 + (1.08 * 0.009)) : val);

            if (qtd_meses > 1 && qtd_meses < 7)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.225);
            if (qtd_meses > 6 && qtd_meses < 13)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.2);
            if (qtd_meses > 12 && qtd_meses < 25)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.175);
            if (qtd_meses > 24)
                Val_final_liquido = Val_final_bruto - (Val_final_bruto * 0.15);

            var retorno = new CalculoViewModel
            {
                valor_bruto = Val_final_bruto,
                valor_liquido = Val_final_liquido
            };

            return retorno;

            //return mapper.Map<CalculoViewModel>(user);
        }

    }
}
