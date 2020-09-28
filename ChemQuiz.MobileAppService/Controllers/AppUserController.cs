using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemQuiz.API.Models;
using ChemQuiz.API.Services;
using ChemQuiz.API.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChemQuiz.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AppUserController : Controller
    {
        private IAppUserService userService;

        public AppUserController(IAppUserService _userService)
        {
            userService = _userService;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Avatar), 200)]
        public IActionResult Get(string id)
        {
                AppUser user = userService.FindByAuthID(id);
                if (user == null) return NotFound();
                return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] AppUser user)
        {
            if (user == null) return BadRequest();
            return new ObjectResult(userService.Create(user));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put([FromBody] AppUser user)
        {
            if (user == null) return BadRequest();//corpo do ooj vazio
            var updatedUser = userService.Update(user);
            if (updatedUser == null) return BadRequest();//obj nao existe no banco de dados
            return new ObjectResult(updatedUser);
        }
    }
}
