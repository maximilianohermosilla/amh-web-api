using AccessData;
using AutoMapper;
using Domain.Models.GestorExpedientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amh_web_api.Controllers.GestorExpediente
{
    [Route("[controller]")]
    [ApiController]
    public class SituacionRevistaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<SituacionRevistaController> _logger;

        public SituacionRevistaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<SituacionRevistaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<SituacionRevista>> SituacionesRevista()
        {
            var lst = (from tbl in _contexto.SituacionRevista where tbl.Id > 0 select new SituacionRevista() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{IdSituacionRevista}")]
        public ActionResult<SituacionRevista> SituacionesRevista(int IdSituacionRevista)
        {
            var item = (from tbl in _contexto.SituacionRevista where tbl.Id == IdSituacionRevista select new SituacionRevista() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(IdSituacionRevista);
            }

            //_logger.LogWarning("Búsqueda de situacion de revista Id: " + _id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(SituacionRevista nuevo)
        {
            try
            {
                _contexto.SituacionRevista.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                //_logger.LogWarning("Se insertó una situacion de revista: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                //_logger.LogError("Ocurrió un error al insertar la situacion de revista: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(SituacionRevista actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.SituacionRevista where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;

                _contexto.SituacionRevista.Update(item);
                _contexto.SaveChanges();
                //_logger.LogWarning("Se actualizó la situacion de revista: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Ocurrió un error al actualizar la situacion de revista: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{IdSituacionRevista}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int IdSituacionRevista)
        {
            var item = (from h in _contexto.SituacionRevista where h.Id == IdSituacionRevista select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(IdSituacionRevista);
            }

            List<Expediente> expedientes = (from tbl in _contexto.Expediente where tbl.IdSituacionRevista == IdSituacionRevista select tbl).ToList();
            if (expedientes.Count() > 0)
            {
                return BadRequest("No se puede eliminar la situacion de revista porque tiene uno o más expedientes asociados");
            }


            _contexto.SituacionRevista.Remove(item);
            _contexto.SaveChanges();
            //_logger.LogWarning("Se eliminó el acto: " + IdCaratula + ", " + item.Nombre);
            return Ok(IdSituacionRevista);
        }
    }
}
