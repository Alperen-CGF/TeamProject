using idvProject.Business.Abstract;
using idvProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace idvProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpGet("GetAll")]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetAll()
        {
            List<Actor> result = _actorService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddActor")]
        [Authorize(Roles = "admin")]
        public IActionResult AddActor(Actor actor)
        {
            _actorService.ActorAdd(actor);
            return Ok();
        }
        [HttpDelete("DeleteActor")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteActor(Actor actor)
        {
            _actorService.ActorDelete(actor);
            return Ok();
        }
        [HttpPut("UpdateActor")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateActor(Actor actor)
        {
            _actorService.ActorUpdate(actor);
            return Ok();
        }
        [HttpGet("GetById")]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetById(Guid id)
        {
            Actor result = _actorService.GetById(id);
            return Ok(result);
        }
    }
}
