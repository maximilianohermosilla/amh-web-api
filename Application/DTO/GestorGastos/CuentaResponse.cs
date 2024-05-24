namespace Application.DTO.GestorGastos
{
    public class CuentaResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int IdTipoCuenta { get; set; }
        public string? TipoCuentaNombre { get; set; }
        public int? IdTarjeta { get; set; }
        public string? TarjetaNumero { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioNombre { get; set; }
        public bool? Habilitado { get; set; }
    }
}
