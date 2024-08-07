namespace Application.DTO.GestorGastos
{
    public class CuentaFullRequest
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int IdTipoCuenta { get; set; }
        public TarjetaRequest? Tarjeta { get; set; }
        public int IdUsuario { get; set; }
        public bool? Habilitado { get; set; }
    }
}
