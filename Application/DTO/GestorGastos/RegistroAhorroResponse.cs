namespace Application.DTO.GestorGastos
{
    public class RegistroAhorroResponse
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCuenta { get; set; }
        public string? CuentaNombre { get; set; }
        public CuentaResponse? Cuenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Diferencia { get; set; }
        public int? IdUsuario { get; set; }
        public string? Observaciones { get; set; }
        public string? Periodo { get; set; }
    }
}
