namespace amh_web_api.DTO
{
    public class CuentaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int IdTipoCuenta { get; set; }
        public string? TipoCuentaNombre { get; set; }
        public int? IdTarjeta { get; set; }
        public string? TarjetaNombre { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioNombre { get; set; }
        public bool? Habilitado { get; set; }
    }
}
