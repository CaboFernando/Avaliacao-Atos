using Avaliacao_Atos.Application.Interfaces;
using Avaliacao_Atos.Application.ViewModels;
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

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(userService.Get());
        }

        [HttpPost]
        public IActionResult Post(UserViewModel userViewModel)
        {
            return Ok(userService.Post(userViewModel));
        }

        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(userService.Put(userViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(userService.Delete(id));
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(userService.Authenticate(userViewModel));
        }

    }
}
