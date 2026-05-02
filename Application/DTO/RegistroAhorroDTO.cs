namespace amh_web_api.DTO
{
    public class RegistroAhorroDTO
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCuenta { get; set; }
        public string? CuentaNombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Diferencia { get; set; }
        public int? IdUsuario { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Observaciones { get; set; }
        public string? Periodo { get; set; }
    }
}
