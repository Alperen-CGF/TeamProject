using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace idvProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult < List <User>> result = _userService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            _userService.UserAdd(user);
            return Ok();
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {
            _userService.UserDelete(user);
            return Ok();
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            _userService.UserUpdate(user);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            IDataResult < User> result = _userService.GetById(id);
            return Ok(result);
        }
    }
}
