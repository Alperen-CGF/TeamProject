using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace idvProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("GetAll")]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetAll()
        {
            IDataResult<List<Movie>> result = _movieService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddMovie")]
        [Authorize(Roles = "admin")]
        public IActionResult AddMovie(Movie movie)
        {
            _movieService.MovieAdd(movie);
            return Ok();
        }
        [HttpDelete("DeleteMovie")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteMovie(Movie movie)
        {
            _movieService.MovieDelete(movie);
            return Ok();
        }
        [HttpPut("UpdateMovie")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateMovie(Movie movie)
        {
            _movieService.MovieUpdate(movie);
            return Ok();
        }
        [HttpGet("GetById")]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetById(Guid id)
        {
            IDataResult<Movie> result = _movieService.GetById(id);
            return Ok(result);
        }
    }
}
