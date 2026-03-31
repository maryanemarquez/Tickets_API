using System;
using System.Collections.Generic;
using System.Linq;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    /// <summary>
    /// Serviço responsável pela lógica de tickets em memória.
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly List<Ticket> _tickets = new();
        private int _nextId = 1;

        /// <summary>
        /// Inicializa o serviço de tickets com dados de exemplo em memória.
        /// </summary>
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

        /// <summary>
        /// Retorna todos os tickets cadastrados.
        /// </summary>
        /// <returns>Lista de tickets cadastrados.</returns>
        public List<Ticket> GetAll()
        {
            return _tickets.ToList();
        }

        /// <summary>
        /// Busca um ticket pelo ID.
        /// </summary>
        /// <param name="id">Identificador do ticket.</param>
        /// <returns>O ticket encontrado, ou null caso não exista.</returns>
        public Ticket? GetById(int id)
        {
            return _tickets.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Cria um novo ticket.
        /// </summary>
        /// <param name="dto">Dados do ticket a ser criado.</param>
        /// <returns>O ticket criado com seu ID gerado.</returns>
        public Ticket Create(TicketCreateDto dto)
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

        /// <summary>
        /// Atualiza os dados de um ticket existente.
        /// </summary>
        /// <param name="id">Identificador do ticket que será atualizado.</param>
        /// <param name="dto">Dados de atualização do ticket.</param>
        /// <returns>O ticket atualizado, ou null caso não exista.</returns>
        public Ticket? Update(int id, TicketUpdateDto dto)
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

        /// <summary>
        /// Remove um ticket cadastrado.
        /// </summary>
        /// <param name="id">Identificador do ticket a ser removido.</param>
        /// <returns>Verdadeiro se o ticket foi removido; caso contrário, falso.</returns>
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
