using System;
using System.Collections.Generic;
using System.Linq;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    /// <summary>
    /// Serviço responsável pelo gerenciamento de usuários em memória.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly List<Usuario> _users = new();
        private int _nextId = 1;

        /// <summary>
        /// Inicializa o serviço de usuários com um usuário administrador em memória.
        /// </summary>
        public UserService()
        {
            _users.Add(new Usuario
            {
                Id = _nextId++,
                Nome = "Administrador",
                Email = "admin@tickets.com",
                Senha = "senha123",
                TarefasAtribuidas = new List<string> { "Revisão de tickets" },
                Permissoes = new List<string> { "admin", "user" }
            });
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários cadastrados.</returns>
        public List<Usuario> GetAll()
        {
            return _users.ToList();
        }

        /// <summary>
        /// Busca um usuário pelo ID.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <returns>O usuário encontrado, ou null se não existir.</returns>
        public Usuario? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="dto">Dados do usuário a ser criado.</param>
        /// <returns>O usuário criado com ID gerado.</returns>
        public Usuario Create(UserCreateDto dto)
        {
            var user = new Usuario
            {
                Id = _nextId++,
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                TarefasAtribuidas = dto.TarefasAtribuidas ?? new List<string>(),
                Permissoes = dto.Permissoes ?? new List<string>()
            };

            _users.Add(user);
            return user;
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="id">Identificador do usuário a ser atualizado.</param>
        /// <param name="dto">Dados de atualização do usuário.</param>
        /// <returns>O usuário atualizado, ou null caso não exista.</returns>
        public Usuario? Update(int id, UserUpdateDto dto)
        {
            var user = GetById(id);
            if (user == null)
            {
                return null;
            }

            user.Nome = dto.Nome;
            user.Email = dto.Email;
            user.Senha = dto.Senha;
            user.TarefasAtribuidas = dto.TarefasAtribuidas ?? new List<string>();
            user.Permissoes = dto.Permissoes ?? new List<string>();
            return user;
        }

        /// <summary>
        /// Remove um usuário do sistema.
        /// </summary>
        /// <param name="id">Identificador do usuário a ser removido.</param>
        /// <returns>Verdadeiro se o usuário foi removido; caso contrário, falso.</returns>
        public bool Delete(int id)
        {
            var user = GetById(id);
            if (user == null)
            {
                return false;
            }

            return _users.Remove(user);
        }
    }
}
