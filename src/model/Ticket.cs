using System;

namespace Tickets_API.src.model
{
    /// <summary>
    /// Representa um ticket no sistema de atendimento.
    /// </summary>
    public class Ticket
    {
        /// <summary>Identificador único do ticket.</summary>
        public int Id { get; set; }

        /// <summary>Título resumido do ticket.</summary>
        public string Titulo { get; set; }

        /// <summary>Descrição completa do ticket.</summary>
        public string Descricao { get; set; }

        /// <summary>Prioridade do ticket (ex: baixa, média, alta).</summary>
        public string Prioridade { get; set; }

        /// <summary>Status atual do ticket (ex: novo, em progresso, resolvido).</summary>
        public string Status { get; set; }

        /// <summary>ID do usuário responsável pelo ticket.</summary>
        public int ResponsavelId { get; set; }

        /// <summary>Data de criação do ticket.</summary>
        public DateTime CriadoEm { get; set; }

        /// <summary>Data da última atualização do ticket.</summary>
        public DateTime AtualizadoEm { get; set; }
    }
}
