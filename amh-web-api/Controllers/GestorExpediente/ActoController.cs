using AccessData;
using AutoMapper;
using Domain.Models.GestorExpedientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace amh_web_api.Controllers.GestorExpediente
{
    [Route("[controller]")]
    [ApiController]
    public class ActoController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<ActoController> _logger;

        public ActoController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<ActoController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Acto>> Actos()
        {
            var lst = (from tbl in _contexto.Acto where tbl.Id > 0 select new Acto() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{IdActo}")]
        public ActionResult<Acto> Actos(int IdActo)
        {
            var item = (from tbl in _contexto.Acto where tbl.Id == IdActo select new Acto() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(IdActo);
            }

            //_logger.LogWarning("Búsqueda de acto Id: " + _id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(Acto nuevo)
        {
            try
            {
                _contexto.Acto.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                //_logger.LogWarning("Se insertó un nuevo acto: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                //_logger.LogError("Ocurrió un error al insertar el acto: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Acto actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Acto where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;

                _contexto.Acto.Update(item);
                _contexto.SaveChanges();
                //_logger.LogWarning("Se actualizó el acto: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Ocurrió un error al actualizar el acto: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{IdActo}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int IdActo)
        {
            var item = (from h in _contexto.Acto where h.Id == IdActo select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(IdActo);
            }

            List<Expediente> expedientes = (from tbl in _contexto.Expediente where tbl.IdActo == IdActo select tbl).ToList();
            if (expedientes.Count() > 0)
            {
                return BadRequest("No se puede eliminar el acto porque tiene uno o más expedientes asociados");
            }


            _contexto.Acto.Remove(item);
            _contexto.SaveChanges();
            //_logger.LogWarning("Se eliminó el acto: " + IdActo + ", " + item.Nombre);
            return Ok(IdActo);
        }

    }
}
