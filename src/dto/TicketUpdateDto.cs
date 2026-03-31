namespace Tickets_API.src.dto
{
    /// <summary>
    /// DTO usado para atualizar um ticket existente.
    /// </summary>
    public class TicketUpdateDto
    {
        /// <summary>Novo título do ticket.</summary>
        public string Titulo { get; set; }

        /// <summary>Nova descrição do ticket.</summary>
        public string Descricao { get; set; }

        /// <summary>Nova prioridade do ticket.</summary>
        public string Prioridade { get; set; }

        /// <summary>Novo status do ticket.</summary>
        public string Status { get; set; }

        /// <summary>ID do usuário responsável pelo ticket.</summary>
        public int ResponsavelId { get; set; }
    }
}
