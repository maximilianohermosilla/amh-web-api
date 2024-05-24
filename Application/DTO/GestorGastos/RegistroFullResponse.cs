namespace Application.DTO.GestorGastos
{
    public class RegistroFullResponse
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdEmpresa { get; set; }
        public string? EmpresaNombre { get; set; }
        public int? IdSuscripcion { get; set; }
        public SuscripcionResponse? Suscripcion { get; set; }
        public int? IdCategoriaGasto { get; set; }
        public string? CategoriaGastoNombre { get; set; }
        public int IdCuenta { get; set; }
        public CuentaResponse? Cuenta { get; set; }
        public int? IdRegistroVinculado { get; set; }
        public RegistroVinculadoResponse? RegistroVinculado { get; set; }
        public int? NumeroCuota { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public int? IdUsuario { get; set; }
        public string? Observaciones { get; set; }
        public bool? Pagado { get; set; }
        public DateTime? FechaPago { get; set; }
    }
}
