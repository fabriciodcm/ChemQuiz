using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemQuiz.API.Models;
using ChemQuiz.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChemQuiz.API.Controllers
{

    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private IService<Category> categoryService;

        public CategoryController(IService<Category> _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Category>), 200)]
        public IActionResult Get() => Ok(categoryService.FindAll());
    }
}
