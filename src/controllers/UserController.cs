using Microsoft.AspNetCore.Mvc;
using Tickets_API.src.dto;
using Tickets_API.src.model;
using Tickets_API.src.services;

namespace Tickets_API.src.controllers
{
    /// <summary>
    /// Controller responsável pelas operações de usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Inicializa o controller de usuários com o serviço de usuários injetado.
        /// </summary>
        /// <param name="userService">Serviço de usuários para operações de CRUD.</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de todos os usuários existentes.</returns>
        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        /// <summary>
        /// Retorna um usuário pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <returns>O usuário correspondente ao ID, ou NotFound se não existir.</returns>
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

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="dto">Dados do usuário a ser criado.</param>
        /// <returns>O usuário criado com ID gerado.</returns>
        [HttpPost]
        public ActionResult<Usuario> Create([FromBody] UserCreateDto dto)
        {
            var user = _userService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <param name="dto">Dados do usuário para atualização.</param>
        /// <returns>O usuário atualizado, ou NotFound se não existir.</returns>
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

        /// <summary>
        /// Remove um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser removido.</param>
        /// <returns>NoContent se removido, ou NotFound se não existir.</returns>
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
