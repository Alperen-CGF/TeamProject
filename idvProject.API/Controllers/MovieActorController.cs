using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace idvProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorController : ControllerBase
    {
        private readonly IMovieActorService _movieActorService;
        public MovieActorController(IMovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult <List<MovieActor>> result = _movieActorService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddMovieActor")]
        public IActionResult AddMovieActor(MovieActor movieActor)
        {
            _movieActorService.MovieActorAdd(movieActor);
            return Ok();
        }
        [HttpDelete("DeleteMovieActor")]
        public IActionResult DeleteMovieActor(MovieActor movieActor)
        {
            _movieActorService.MovieActorDelete(movieActor);
            return Ok();
        }
        [HttpPut("UpdateRole")]
        public IActionResult UpdateMovieActor(MovieActor movieActor)
        {
            _movieActorService.MovieActorUpdate(movieActor);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            IDataResult <MovieActor> result = _movieActorService.GetById(id);
            return Ok(result);
        }
    }
}
