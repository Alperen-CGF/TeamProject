using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace idvProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult<List<Role>> result = _roleService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddRole")]
        public IActionResult AddRole(Role role) 
        {
            _roleService.RoleAdd(role);
            return Ok();
        }
        [HttpDelete("DeleteRole")]
        public IActionResult DeleteRole(Role role)
        {
            _roleService.RoleDelete(role);
            return Ok();
        }
        [HttpPut("UpdateRole")]
        public IActionResult UpdateRole(Role role)
        {
            _roleService.RoleUpdate(role);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            IDataResult<Role> result = _roleService.GetById(id);
            return Ok(result);
        }

    }
}
