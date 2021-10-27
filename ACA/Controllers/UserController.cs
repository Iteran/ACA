using ACA.DTO.User;
using BusinessLogicLayer.Data;
using BusinessLogicLayer.Services;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService<UserClient> service;

        public UserController(IUserService<UserClient> service)
        {
            this.service = service;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                return Ok(service.GetById(Id));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
                throw;
            }
        }
        [HttpPost]
        public IActionResult Register([FromBody] UserAdd user)
        {
            try
            {
                service.Create(user.Map<UserClient>());
                return Ok();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPut("{Id}")]
        public IActionResult ModifyUser([FromRoute] int Id, [FromBody] UserModify User)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (service.GetById(Id) is not null)
                    {
                        return Ok(service.Update(Id, User.Map<UserClient>()));
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                catch (Exception e)
                {
                    return Problem(e.Message);
                    throw;
                }
            }
            else return BadRequest();
        }
        [HttpPatch("{Id}")]
        public IActionResult ModifyPassword([FromRoute] int Id, [FromBody] PasswordModify NewPwd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (service.ModifyPassword(Id, NewPwd.Password))
                    {
                        return Ok();

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
            return BadRequest();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser([FromRoute] int Id)
        {
            try
            {
                return Ok(service.Delete(Id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }

}
