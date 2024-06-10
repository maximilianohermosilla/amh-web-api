namespace Application.DTO.GestorGastos
{
    public class RegistroRequest
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int IdCategoriaGasto { get; set; }
        public int IdCuenta { get; set; }
        public int? IdEmpresa { get; set; } = null;
        public int? IdSuscripcion { get; set; } = null;
        public int? IdRegistroVinculado { get; set; } = null;
        public int? NumeroCuota { get; set; } = null;
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public int? IdUsuario { get; set; }
        public string? Observaciones { get; set; }
        public string? Periodo { get; set; }
        public bool? Pagado { get; set; }
        public DateTime? FechaPago { get; set; } = null;
    }
}
