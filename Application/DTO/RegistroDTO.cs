namespace amh_web_api.DTO
{
    public class RegistroDTO
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdEmpresa { get; set; }
        public string? EmpresaNombre { get; set; }
        public int? IdSuscripcion { get; set; }
        public string? SuscripcionNombre { get; set; }
        public int IdCuenta { get; set; }
        public string? CuentaNombre { get; set; }
        public int? IdRegistroVinculado { get; set; }
        public string? RegistroVinculadoNombre { get; set; }
        public int? NumeroCuota { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public int? IdUsuario { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Observaciones { get; set; }
        public bool? Pagado { get; set; }
        public DateTime? FechaPago { get; set; }
    }

}
