using Avaliacao_Atos.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Avaliacao_Atos.Application.Tests.Services
{
    public class CalculoServiceTests
    {
        private readonly CalculoService calculoService;

        public CalculoServiceTests()
        {
            calculoService = new CalculoService();
        }

        #region validações

        [Fact]
        public void GetCalculo_SendingInvalidValorMonetario()
        {
            var exception = Assert.Throws<Exception>(() => calculoService.GetCalculo(0, 2));
            Assert.Equal("O valor monetário informado deve ser positivo", exception.Message);
        }

        [Fact]
        public void GetCalculo_SendingInvalidQuantidadeMeses()
        {
            var exception = Assert.Throws<Exception>(() => calculoService.GetCalculo(100, 1));
            Assert.Equal("A quantidade de meses deve ser maior que 1", exception.Message);
        }

        #endregion

        #region validação de parâmetros corretos

        [Fact]
        public void GetCalculo_SendingValidParameters()
        {
            var result = calculoService.GetCalculo(100, 2);

            Assert.True(result.valor_bruto > 0 && result.valor_liquido > 0);
        }

        #endregion
    }
}
