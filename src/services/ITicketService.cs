using System.Collections.Generic;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    public interface ITicketService
    {
        List<Ticket> GetAll();
        Ticket? GetById(int id);
        Ticket Create(TicketsCreateDto dto);
        Ticket? Update(int id, TicketsUpdateDto dto);
        bool Delete(int id);
    }
}

