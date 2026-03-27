using System;
using System.Collections.Generic;
using System.Linq;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    public class TicketService : ITicketService
    {
        private readonly List<Ticket> _tickets = new();
        private int _nextId = 1;

        public TicketService()
        {
            _tickets.Add(new Ticket
            {
                Id = _nextId++,
                Titulo = "Solicitação de acesso ao sistema",
                Descricao = "Usuário precisa de acesso ao novo módulo de relatórios.",
                Prioridade = "média",
                Status = "novo",
                ResponsavelId = 1,
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow
            });
        }

        public List<Ticket> GetAll()
        {
            return _tickets.ToList();
        }

        public Ticket? GetById(int id)
        {
            return _tickets.FirstOrDefault(t => t.Id == id);
        }

        public Ticket Create(TicketsCreateDto dto)
        {
            var ticket = new Ticket
            {
                Id = _nextId++,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Prioridade = dto.Prioridade,
                Status = dto.Status,
                ResponsavelId = dto.ResponsavelId,
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow
            };

            _tickets.Add(ticket);
            return ticket;
        }

        public Ticket? Update(int id, TicketsUpdateDto dto)
        {
            var ticket = GetById(id);
            if (ticket == null)
            {
                return null;
            }

            ticket.Titulo = dto.Titulo;
            ticket.Descricao = dto.Descricao;
            ticket.Prioridade = dto.Prioridade;
            ticket.Status = dto.Status;
            ticket.ResponsavelId = dto.ResponsavelId;
            ticket.AtualizadoEm = DateTime.UtcNow;
            return ticket;
        }

        public bool Delete(int id)
        {
            var ticket = GetById(id);
            if (ticket == null)
            {
                return false;
            }

            return _tickets.Remove(ticket);
        }
    }
}
