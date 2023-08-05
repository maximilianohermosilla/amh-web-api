using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AccessData;
using amh_web_api.DTO;
using Application.Helpers;
using Domain.Models;

namespace amh_web_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly string secretKey;
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IConfiguration config, AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<UsuarioController> logger)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioLoginDTO request)
        {
            var passEncoded = CryptographyHelper.Encrypt(request.Password);
            request.Password = passEncoded;
            //var passDecoded = CryptographyHelper.Decrypt(passEncoded);
            UsuarioDTO userDTO = Authenticate(request);
            if (userDTO != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.Name, request.Login));
                claims.AddClaim(new Claim(ClaimTypes.Role, userDTO.Perfil));
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier , userDTO.Id.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfiguration = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreated = tokenHandler.WriteToken(tokenConfiguration);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreated });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "", error = "Usuario o contraseña incorrectos" });
            }

        }

        private UsuarioDTO Authenticate(UsuarioLoginDTO userLogin)
        {
            var _user = (from tbl in _contexto.Usuario where tbl.Login == userLogin.Login && tbl.Password == userLogin.Password select tbl).FirstOrDefault();

            UsuarioDTO _userDTO = _mapper.Map<UsuarioDTO>(_user);

            if (_userDTO != null)
            {
                var _perfil = (from tbl in _contexto.Perfil where tbl.Id == _userDTO.IdPerfil select tbl).FirstOrDefault();

                if (_perfil != null)
                {
                    _userDTO.Perfil = _perfil.Descripcion;
                }   

                var usuarioSistemas = (from tbl in _contexto.UsuarioSistema
                                       join s in _contexto.Sistema on tbl.IdSistema equals s.Id
                                       where tbl.IdUsuario == _userDTO.Id
                                       select s).ToList();

                List<SistemaDTO> usuarioSistemaDTO = _mapper.Map<List<SistemaDTO>>(usuarioSistemas);

                if (usuarioSistemas != null)
                {
                    _userDTO.Sistemas = usuarioSistemaDTO;
                }
            }

            return _userDTO;             
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<UsuarioDTO>> Usuarios()
        {
            var lst = (from tbl in _contexto.Usuario where tbl.Id > 0 select tbl).ToList();

            List<UsuarioDTO> _usersDTO = _mapper.Map<List<UsuarioDTO>>(lst);

            foreach (var item in _usersDTO)
            {
                var usuariosSistema = (from tbl in _contexto.UsuarioSistema
                                       join s in _contexto.Sistema on tbl.IdSistema equals s.Id
                                       where tbl.IdUsuario == item.Id
                                       select s).ToList();

                List<SistemaDTO> usuarioSistemaDTO = _mapper.Map<List<SistemaDTO>>(usuariosSistema);


                if (usuariosSistema != null)
                {
                    item.Sistemas = usuarioSistemaDTO;                    
                }
            }

            return Ok(_usersDTO);
        }

        [HttpGet("buscar/{IdUsuario}")]
        public ActionResult<Sistema> Usuarios(int IdUsuario)
        {
            var item = (from tbl in _contexto.Usuario where tbl.Id == IdUsuario select tbl).FirstOrDefault();
            if (item == null)
            {
                return NotFound(IdUsuario);
            }

            UsuarioDTO usuarioDTO = _mapper.Map<UsuarioDTO>(item);

            try
            {
                var usuariosSistema = (from tbl in _contexto.UsuarioSistema
                                       join s in _contexto.Sistema on tbl.IdSistema equals s.Id
                                       where tbl.IdUsuario == IdUsuario
                                       select s).ToList();

                List<SistemaDTO> usuarioSistemaDTO = _mapper.Map<List<SistemaDTO>>(usuariosSistema);

                if (usuariosSistema != null)
                {
                    usuarioDTO.Sistemas = usuarioSistemaDTO;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al buscar el usuario: " + IdUsuario + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


            _logger.LogWarning("Búsqueda de usuario Id: " + IdUsuario + ". Resultados: " + usuarioDTO.Nombre);
            return Ok(usuarioDTO);
        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(UsuarioDTO actualiza)
        {
            string oldName = "";
            string oldLogin = "";
            string oldPassword = "";
            string oldCorreo = "";
            string oldHabilitado = "";
            string oldIdPerfil = "";
            try
            {
                var item = (from h in _contexto.Usuario where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }

                oldName = item.Nombre;
                oldLogin = item.Login;
                oldPassword = item.Password;
                oldCorreo = item.Correo;
                oldHabilitado = item.Habilitado.ToString();
                oldIdPerfil = item.IdPerfil.ToString();

                item.Login = actualiza.Login;
                item.Password = actualiza.Password;
                item.Correo = actualiza.Correo;
                item.Habilitado = actualiza.Habilitado;
                item.IdPerfil = actualiza.IdPerfil;

                _contexto.Usuario.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el usuario: " + actualiza.Id + ". Datos anteriores: Nombre=" + oldName + ", Usuario=" + oldLogin + ", Contraseña=" + oldPassword
               + ", Correo=" + oldCorreo + ", Habilitado=" + oldHabilitado + " ,IdPerfil=" + oldIdPerfil);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar el usuario: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{IdUsuario}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int IdUsuario)
        {
            var item = (from h in _contexto.Usuario where h.Id == IdUsuario select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(IdUsuario);

                var usuariosSistema = (from tbl in _contexto.UsuarioSistema where tbl.IdUsuario == IdUsuario select tbl).ToList();

                if (usuariosSistema != null)
                {
                    _contexto.UsuarioSistema.RemoveRange(usuariosSistema);
                }
            }

            _contexto.Usuario.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el Usuario: " + IdUsuario+ ", " + item.Nombre);
            return Ok(IdUsuario);
        }

    }
}
