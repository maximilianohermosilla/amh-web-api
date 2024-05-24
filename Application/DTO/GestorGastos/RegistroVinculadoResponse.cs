namespace Application.DTO.GestorGastos
{
    public class RegistroVinculadoResponse
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Cuotas { get; set; }
        public decimal ValorFinal { get; set; }
        public int IdUsuario { get; set; }
    }
}
