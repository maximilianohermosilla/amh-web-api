namespace Application.DTO.General
{
    public class CancionResponse
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Autor { get; set; }

        public string? Url { get; set; }

        public string? NombreSolicitante { get; set; }

        public bool? Habilitado { get; set; }
    }
}
