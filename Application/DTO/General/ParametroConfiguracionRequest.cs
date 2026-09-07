namespace Application.DTO.General
{
    public class ParametroConfiguracionRequest
    {
        public int Id { get; set; }
        public int IdSistema { get; set; }
        public string Nombre { get; set; } = null!;
        public string Valor { get; set; } = null!;
    }
}
