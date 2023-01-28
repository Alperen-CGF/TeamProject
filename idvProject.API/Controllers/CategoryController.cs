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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult < List <Category>> result = _categoryService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.CategoryAdd(category);
            return Ok();
        }
        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(Category category)
        {
            _categoryService.CategoryDelete(category);
            return Ok();
        }
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.CategoryUpdate(category);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            IDataResult <Category> result = _categoryService.GetById(id);
            return Ok(result);
        }
    }
}
