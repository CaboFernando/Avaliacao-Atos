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
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService _userService) 
        {
            userService = _userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            userService.Test();

            return Ok("Ok");
        }

    }
}
