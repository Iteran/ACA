using ACA.DTO.User;
using ACA.Token;
using BusinessLogicLayer.Data;
using InterfacesACA.Interfaces;
using Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly InterfacesACA.Interfaces.IUserService<UserClient> service;
        private readonly TokenManager _token;

        public AuthController(IUserService<UserClient> service, TokenManager token)
        {
            _token = token;
            this.service = service;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUser user)
        {
            try
            {

                UserDTO u = new UserDTO();
                if (ModelState.IsValid) u = _token.Authenticate(service.Login(user.Email, user.Password).Map<UserDTO>());

                if (u is null) return new ForbidResult("Interdit");

                return Ok(u);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}
