using Microsoft.AspNetCore.Mvc;
using Tickets_API.src.dto;
using Tickets_API.src.model;
using Tickets_API.src.services;

namespace Tickets_API.src.controllers
{
    /// <summary>
    /// Controller responsável por expor operações de gerenciamento de tickets.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        /// <summary>
        /// Inicializa o controller de tickets com o serviço de tickets injetado.
        /// </summary>
        /// <param name="ticketService">Serviço de tickets para operações de CRUD.</param>
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Retorna todos os tickets cadastrados.
        /// </summary>
        /// <returns>Lista de todos os tickets existentes.</returns>
        [HttpGet]
        public ActionResult<List<Ticket>> GetAll()
        {
            return Ok(_ticketService.GetAll());
        }

        /// <summary>
        /// Retorna um ticket específico pelo ID.
        /// </summary>
        /// <param name="id">Identificador do ticket.</param>
        /// <returns>O ticket correspondente ao ID, ou NotFound se não existir.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<Ticket> GetById(int id)
        {
            var ticket = _ticketService.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        /// <summary>
        /// Cria um novo ticket no sistema.
        /// </summary>
        /// <param name="dto">Dados do ticket a ser criado.</param>
        /// <returns>O ticket criado com o ID gerado.</returns>
        [HttpPost]
        public ActionResult<Ticket> Create([FromBody] TicketCreateDto dto)
        {
            var ticket = _ticketService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        /// <summary>
        /// Atualiza os dados de um ticket existente.
        /// </summary>
        /// <param name="id">ID do ticket a ser atualizado.</param>
        /// <param name="dto">Dados de atualização do ticket.</param>
        /// <returns>O ticket atualizado, ou NotFound se não existir.</returns>
        [HttpPut("{id:int}")]
        public ActionResult<Ticket> Update(int id, [FromBody] TicketUpdateDto dto)
        {
            var updated = _ticketService.Update(id, dto);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        /// <summary>
        /// Remove um ticket pelo ID.
        /// </summary>
        /// <param name="id">ID do ticket a ser removido.</param>
        /// <returns>NoContent se removido, ou NotFound se não existir.</returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (!_ticketService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
