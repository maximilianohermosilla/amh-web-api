namespace amh_web_api.DTO
{
    public class TarjetaDTO
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Vencimiento { get; set; }
        public int? IdBanco { get; set; }
        public string? BancoNombre { get; set; }
        public int? IdTipoTarjeta { get; set; }
        public string? TipoTarjetaNombre { get; set; }
        public int? IdUsuario { get; set; }
        public string? UsuarioNombre { get; set; }
        public bool? Habilitado { get; set; }
        public List<CuentaDTO>? cuentas { get; set; }

    }
}