namespace Application.DTO.General
{
    public class EmailRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Whatsapp { get; set; }
        public string? Email { get; set; }
        public string? Asunto { get; set; }
        public string? Mensaje { get; set; }
        public string Destinatario { get; set; }
        public DateTime DateTime { get; set; }
    }
}
