using AccessData;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace amh_web_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<SistemaController> _logger;

        public SistemaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<SistemaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Sistema>> Sistemas()
        {
            var lst = (from tbl in _contexto.Sistema where tbl.Id > 0 select new Sistema() { Id = tbl.Id, Descripcion = tbl.Descripcion }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{IdSistema}")]
        public ActionResult<Sistema> Sistemas(int IdSistema)
        {
            var item = (from tbl in _contexto.Sistema where tbl.Id == IdSistema select new Sistema() { Id = tbl.Id, Descripcion = tbl.Descripcion }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(IdSistema);
            }

            _logger.LogWarning("Búsqueda de sistema Id: " + IdSistema + ". Resultados: " + item.Descripcion);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(Sistema nuevo)
        {
            try
            {
                _contexto.Sistema.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó un nuevo sistema: " + nuevo.Id + ". Nombre: " + nuevo.Descripcion);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el sistema: " + nuevo.Descripcion + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Sistema actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Sistema where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Descripcion;
                item.Descripcion = actualiza.Descripcion;

                _contexto.Sistema.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el sistema: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Descripcion);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar el sistema: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{IdSistema}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int IdSistema)
        {
            var item = (from h in _contexto.Sistema where h.Id == IdSistema select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(IdSistema);
            }

            List<UsuarioSistema> usuarios = (from tbl in _contexto.UsuarioSistema where tbl.IdSistema == IdSistema select tbl).ToList();
            if (usuarios.Count() > 0)
            {
                return BadRequest("No se puede eliminar el sistema porque tiene uno o más usuarios asociados");
            }


            _contexto.Sistema.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el sistema: " + IdSistema + ", " + item.Descripcion);
            return Ok(IdSistema);
        }

    }
}
