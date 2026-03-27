using System.Collections.Generic;

namespace Tickets_API.src.model
{
    /// <summary>
    /// Classe que representa um usuário no sistema de tickets.
    /// Contém todas as informações necessárias para identificar, autenticar e autorizar um usuário.
    /// </summary>
    public class Usuario
    {
        /// <summary>Identificador único do usuário no banco de dados.</summary>
        public int Id { get; set; }

        /// <summary>Nome completo do usuário.</summary>
        public string Nome { get; set; }

        /// <summary>Email único do usuário para contato e autenticação.</summary>
        public string Email { get; set; }

        /// <summary>Senha do usuário (deve ser armazenada criptografada no banco de dados).</summary>
        public string Senha { get; set; }

        /// <summary>Lista de tarefas/tickets atribuídos ao usuário.</summary>
        public List<string> TarefasAtribuidas { get; set; } = new List<string>();

        /// <summary>Lista de permissões do usuário para controle de acesso (ex: admin, user, editor).</summary>
        public List<string> Permissoes { get; set; } = new List<string>();
    }
}
