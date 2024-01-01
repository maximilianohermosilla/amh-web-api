namespace amh_web_api.DTO
{
    public class UsuarioLoginDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string? PasswordNew { get; set; }
        public int IdSistema { get; set; }
    }
}
