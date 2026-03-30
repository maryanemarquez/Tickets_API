using System.Collections.Generic;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    /// <summary>
    /// Interface responsável por definir as operações de serviço para a entidade Usuario.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        List<Usuario> GetAll();

        /// <summary>
        /// Busca um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        Usuario? GetById(int id);

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="dto">Dados do usuário a ser criado.</param>
        Usuario Create(UserCreateDto dto);

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <param name="dto">Dados do usuário atualizados.</param>
        Usuario? Update(int id, UserUpdateDto dto);

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser removido.</param>
        bool Delete(int id);
    }
}
