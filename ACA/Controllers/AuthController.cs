using ACA.DTO.User;
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
        private readonly InterfacesACA.Interfaces.IUserService<UserDTO> service;

        public AuthController(IUserService<UserDTO> service)
        {
            this.service = service;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUser user)
        {
            try
            {

                UserDTO u = new UserDTO();
                if (ModelState.IsValid) u = service.Login(user.Email, user.Password).Map<UserDTO>();

                if (u is not null)
                {
                    return Ok(u);
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}
