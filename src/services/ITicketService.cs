using System.Collections.Generic;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    /// <summary>
    /// Interface responsável por definir as operações de serviço para a entidade Ticket.
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// Retorna todos os tickets cadastrados.
        /// </summary>
        List<Ticket> GetAll();

        /// <summary>
        /// Busca um ticket pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do ticket.</param>
        Ticket? GetById(int id);

        /// <summary>
        /// Cria um novo ticket.
        /// </summary>
        /// <param name="dto">Dados do ticket a ser criado.</param>
        Ticket Create(TicketCreateDto dto);

        /// <summary>
        /// Atualiza um ticket existente.
        /// </summary>
        /// <param name="id">ID do ticket a ser atualizado.</param>
        /// <param name="dto">Dados do ticket atualizados.</param>
        Ticket? Update(int id, TicketUpdateDto dto);

        /// <summary>
        /// Exclui um ticket pelo ID.
        /// </summary>
        /// <param name="id">ID do ticket a ser removido.</param>
        bool Delete(int id);
    }
}

