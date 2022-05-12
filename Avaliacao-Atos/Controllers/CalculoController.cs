using Avaliacao_Atos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliacao_Atos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculoService calculoService;

        public CalculoController(ICalculoService _calculoService)
        {
            calculoService = _calculoService;
        }

        [HttpGet]
        public IActionResult Get(decimal valorMonetario, int quantidadeMeses)
        {
            return Ok(calculoService.GetCalculo(valorMonetario, quantidadeMeses));
        }
    }
}
