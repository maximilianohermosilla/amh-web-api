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
    public class CaratulaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<CaratulaController> _logger;

        public CaratulaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<CaratulaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Caratula>> Caratulas()
        {
            var lst = (from tbl in _contexto.Caratula where tbl.Id > 0 select new Caratula() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{IdCaratula}")]
        public ActionResult<Caratula> Caratulas(int IdCaratula)
        {
            var item = (from tbl in _contexto.Caratula where tbl.Id == IdCaratula select new Caratula() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(IdCaratula);
            }

            //_logger.LogWarning("Búsqueda de caratula Id: " + _id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(Caratula nuevo)
        {
            try
            {
                _contexto.Caratula.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                //_logger.LogWarning("Se insertó una nueva caratula: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                //_logger.LogError("Ocurrió un error al insertar la caratula: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Caratula actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Caratula where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;

                _contexto.Caratula.Update(item);
                _contexto.SaveChanges();
                //_logger.LogWarning("Se actualizó la caratula: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Ocurrió un error al actualizar la caratula: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{IdCaratula}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int IdCaratula)
        {
            var item = (from h in _contexto.Caratula where h.Id == IdCaratula select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(IdCaratula);
            }

            List<Expediente> expedientes = (from tbl in _contexto.Expediente where tbl.IdCaratula == IdCaratula select tbl).ToList();
            if (expedientes.Count() > 0)
            {
                return BadRequest("No se puede eliminar la caratula porque tiene uno o más expedientes asociados");
            }


            _contexto.Caratula.Remove(item);
            _contexto.SaveChanges();
            //_logger.LogWarning("Se eliminó la caratula: " + IdCaratula + ", " + item.Nombre);
            return Ok(IdCaratula);
        }

    }
}
