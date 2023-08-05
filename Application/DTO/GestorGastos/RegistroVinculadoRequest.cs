namespace Application.DTO.GestorGastos
{
    public class RegistroVinculadoRequest
    {
        public string? Descripcion { get; set; }
        public int Cuotas { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
