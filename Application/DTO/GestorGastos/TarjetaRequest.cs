namespace Application.DTO.GestorGastos
{
    public class TarjetaRequest
    {
        public string? Numero { get; set; }
        public string? Vencimiento { get; set; }
        public int? IdBanco { get; set; }
        public int? IdTipoTarjeta { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Habilitado { get; set; }
    }
}
