using Microsoft.AspNetCore.Mvc;
using Tickets_API.src.dto;
using Tickets_API.src.model;
using Tickets_API.src.services;

namespace Tickets_API.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> GetAll()
        {
            return Ok(_ticketService.GetAll());
        }

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

        [HttpPost]
        public ActionResult<Ticket> Create([FromBody] TicketsCreateDto dto)
        {
            var ticket = _ticketService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Ticket> Update(int id, [FromBody] TicketsUpdateDto dto)
        {
            var updated = _ticketService.Update(id, dto);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

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
