namespace Tickets_API.src.dto
{
    /// <summary>
    /// DTO usado para criar um novo ticket no sistema.
    /// </summary>
    public class TicketCreateDto
    {
        /// <summary>Título do ticket.</summary>
        public string Titulo { get; set; }

        /// <summary>Descrição detalhada do problema ou solicitação.</summary>
        public string Descricao { get; set; }

        /// <summary>Prioridade do ticket (ex: baixa, média, alta).</summary>
        public string Prioridade { get; set; }

        /// <summary>Status inicial do ticket (ex: novo, aberto, em progresso).</summary>
        public string Status { get; set; }

        /// <summary>ID do usuário responsável pelo ticket.</summary>
        public int ResponsavelId { get; set; }
    }
}
