using idvProject.Business.Abstract;
using idvProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace idvProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<UserRole> result = _userRoleService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddUserRole")]
        public IActionResult AddUserRole(UserRole userRole)
        {
            _userRoleService.UserRoleAdd(userRole);
            return Ok();
        }
        [HttpDelete("DeleteUserRole")]
        public IActionResult DeleteUserRole(UserRole userRole)
        {
            _userRoleService.UserRoleDelete(userRole);
            return Ok();
        }
        [HttpPut("UpdateUserRole")]
        public IActionResult UpdateUserRole(UserRole userRole)
        {
            _userRoleService.UserRoleUpdate(userRole);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            UserRole result = _userRoleService.GetById(id);
            return Ok(result);
        }
    }
}
