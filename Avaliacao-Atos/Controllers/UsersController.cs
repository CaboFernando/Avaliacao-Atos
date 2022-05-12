using Avaliacao_Atos.Application.Interfaces;
using Avaliacao_Atos.Application.ViewModels;
using Avaliacao_Atos.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avaliacao_Atos.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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

        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(userService.Get());
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserViewModel userViewModel)
        {
            return Ok(userService.Post(userViewModel));
        }

        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(userService.Put(userViewModel));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            string _userId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

            return Ok(userService.Delete(_userId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(userService.Authenticate(userViewModel));
        }

    }
}
