using System.Collections.Generic;
using Tickets_API.src.dto;
using Tickets_API.src.model;

namespace Tickets_API.src.services
{
    public interface IUserService
    {
        List<Usuario> GetAll();
        Usuario? GetById(int id);
        Usuario Create(UserCreateDto dto);
        Usuario? Update(int id, UserUpdateDto dto);
        bool Delete(int id);
    }
}
