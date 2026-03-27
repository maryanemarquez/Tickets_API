using System.Collections.Generic;

namespace Tickets_API.src.dto
{
    /// <summary>
    /// Data Transfer Object (DTO) usado para transferir dados de criação de usuário.
    /// É enviado pelo cliente quando deseja criar um novo usuário no sistema.
    /// Não contém o ID pois é gerado automaticamente pelo banco de dados.
    /// </summary>
    public class UserCreateDto
    {
        /// <summary>Nome completo do novo usuário.</summary>
        public string Nome { get; set; }

        /// <summary>Email único para o novo usuário.</summary>
        public string Email { get; set; }

        /// <summary>Senha do novo usuário (será criptografada no servidor).</summary>
        public string Senha { get; set; }

        /// <summary>Tarefas iniciais atribuídas ao novo usuário.</summary>
        public List<string> TarefasAtribuidas { get; set; } = new List<string>();

        /// <summary>Permissões iniciais do novo usuário (ex: user, editor).</summary>
        public List<string> Permissoes { get; set; } = new List<string>();
    }
}
