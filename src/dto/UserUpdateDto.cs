using System.Collections.Generic;

namespace Tickets_API.src.dto
{
    /// <summary>
    /// Data Transfer Object (DTO) usado para transferir dados de atualização de usuário.
    /// É enviado pelo cliente quando deseja atualizar informações de um usuário existente.
    /// Não contém o ID pois este é passado pela URL da requisição e não deve ser modificado.
    /// </summary>
    public class UserUpdateDto
    {
        /// <summary>Novo nome do usuário.</summary>
        public string Nome { get; set; }

        /// <summary>Novo email do usuário (deve ser verificado por unicidade).</summary>
        public string Email { get; set; }

        /// <summary>Nova senha do usuário (será criptografada no servidor).</summary>
        public string Senha { get; set; }

        /// <summary>Tarefas atualizadas atribuídas ao usuário.</summary>
        public List<string> TarefasAtribuidas { get; set; } = new List<string>();

        /// <summary>Permissões atualizadas do usuário (ex: admin, user, editor).</summary>
        public List<string> Permissoes { get; set; } = new List<string>();
    }
}
