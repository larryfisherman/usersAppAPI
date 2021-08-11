using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rekrutacja.Entities;
using rekrutacja.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rekrutacja.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _userService.Delete(id);
            return Ok("User removed");
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] User dto, [FromRoute] int id)
        {
            _userService.Update(id, dto);

            return Ok();
        }


        [HttpPost]
        public ActionResult CreateUser([FromBody] User dto)
        {
            var id = _userService.Create(dto);
            return Created($"/api/account/{id}", null);
        }
    }
}
