using AccessData;
using amh_web_api.DTO;
using AutoMapper;
using Domain.Models;
using Domain.Models.GestorExpedientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioSistemaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioSistemaController> _logger;

        public UsuarioSistemaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<UsuarioSistemaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Sistema>> Sistemas()
        {
            var lst = (from tbl in _contexto.Sistema where tbl.Id > 0 select new Acto() { Id = tbl.Id, Nombre = tbl.Descripcion }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscarSistema/{IdSistema}")]
        public ActionResult<Sistema> Sistemas(int IdSistema)
        {
            var item = (from tbl in _contexto.Sistema where tbl.Id == IdSistema select new Sistema() { Id = tbl.Id, Descripcion = tbl.Descripcion }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(IdSistema);
            }

            SistemaDTO sistemaDTO = _mapper.Map<SistemaDTO>(item);

            try
            {
                var usuariosSistema = (from tbl in _contexto.UsuarioSistema
                                       join u in _contexto.Usuario on tbl.IdUsuario equals u.Id
                                       where tbl.IdSistema == IdSistema
                                       select u).ToList();

                List<UsuarioDTO> usuarioSistemaDTO = _mapper.Map<List<UsuarioDTO>>(usuariosSistema);

                if (usuariosSistema != null)
                {
                    sistemaDTO.Usuarios = usuarioSistemaDTO;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al buscar el sistema: " + IdSistema + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


            _logger.LogWarning("Búsqueda de sistema Id: " + IdSistema + ". Resultados: " + item.Descripcion);
            return Ok(sistemaDTO);
        }

        [HttpGet("buscarUsuario/{IdUsuario}")]
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

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(UsuarioSistemaDTO nuevo)
        {
            try
            {
                UsuarioSistema usuarioSistemaDTO = _mapper.Map<UsuarioSistema>(nuevo);

                _contexto.UsuarioSistema.Add(usuarioSistemaDTO);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó una nueva relación de usuario: " + nuevo.IdUsuario + " y sistema: " + nuevo.IdSistema);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar la relación de usuario: " + nuevo.IdUsuario + " y sistema: " + nuevo.IdSistema + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }


        [HttpDelete("eliminar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(UsuarioSistemaDTO eliminar)
        {
            var item = (from h in _contexto.UsuarioSistema where h.IdSistema == eliminar.IdSistema && h.IdUsuario == eliminar.IdUsuario select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(eliminar);
            }

            _contexto.UsuarioSistema.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó la relación del usuario: " + eliminar.IdUsuario + " y el sistema " + eliminar.IdSistema);
            return Ok(eliminar);
        }

    }
}
