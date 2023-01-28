﻿using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetAll()
        {
            IDataResult<List<Actor>> result = _actorService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddActor")]
        public IActionResult AddActor(Actor actor)
        {
            _actorService.ActorAdd(actor);
            return Ok();
        }
        [HttpDelete("DeleteActor")]
        public IActionResult DeleteActor(Actor actor)
        {
            _actorService.ActorDelete(actor);
            return Ok();
        }
        [HttpPut("UpdateActor")]
        public IActionResult UpdateActor(Actor actor)
        {
            _actorService.ActorUpdate(actor);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            IDataResult<Actor> result = _actorService.GetById(id);
            return Ok(result);
        }
    }
}
