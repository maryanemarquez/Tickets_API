using Microsoft.AspNetCore.Mvc;
using Tickets_API.src.dto;
using Tickets_API.src.model;
using Tickets_API.src.services;

namespace Tickets_API.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<Usuario> Create([FromBody] UserCreateDto dto)
        {
            var user = _userService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Usuario> Update(int id, [FromBody] UserUpdateDto dto)
        {
            var updated = _userService.Update(id, dto);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (!_userService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
