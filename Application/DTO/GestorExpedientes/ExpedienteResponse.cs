namespace Application.DTO.GestorExpedientes
{
    public class ExpedienteResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Expediente1 { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public string? Documento { get; set; }
        public int? IdCaratula { get; set; }
        public string? CaratulaNombre { get; set; }
        public int? IdActo { get; set; }
        public string? ActoNombre { get; set; }
        public int? IdSituacionRevista { get; set; }
        public string? SituacionRevistaNombre { get; set; }
        public DateTime? FechaExpediente { get; set; }
        public bool? FirmadoSumario { get; set; }
        public bool? FirmadoLaborales { get; set; }
        public bool? EnviadoLaborales { get; set; }
        public bool? Avisado { get; set; }
        public string? Observaciones { get; set; }
    }
}
