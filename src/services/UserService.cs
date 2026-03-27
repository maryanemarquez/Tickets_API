using System;
using System.Collections.Generic;
using System.Linq;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    public class UserService : IUserService
    {
        private readonly List<Usuario> _users = new();
        private int _nextId = 1;

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

        public List<Usuario> GetAll()
        {
            return _users.ToList();
        }

        public Usuario? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

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
