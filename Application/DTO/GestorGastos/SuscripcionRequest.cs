namespace Application.DTO.GestorGastos
{
    public class SuscripcionRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public decimal ValorActual { get; set; }
        public int? IdUsuario { get; set; }
    }
}
