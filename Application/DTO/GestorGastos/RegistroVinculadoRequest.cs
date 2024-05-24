namespace Application.DTO.GestorGastos
{
    public class RegistroVinculadoRequest
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Cuotas { get; set; }
        public decimal ValorFinal { get; set; }
        public int IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCuenta { get; set; }
        public int IdCategoriaGasto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
