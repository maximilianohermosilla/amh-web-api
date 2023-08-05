using AccessData;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace amh_web_api.Controllers.GestorGastos
{
    [Route("gestorGastos/[controller]")]
    [ApiController]
    public class SuscripcionController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<SuscripcionController> _logger;

        public SuscripcionController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<SuscripcionController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Suscripcion>> Suscripciones()
        {
            var lst = (from tbl in _contexto.Suscripcion where tbl.Id > 0 select tbl).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<Suscripcion> Suscripcion(int Id)
        {
            var item = (from tbl in _contexto.Suscripcion where tbl.Id == Id select tbl).FirstOrDefault();
            if (item == null)
            {
                return NotFound(Id);
            }

            _logger.LogWarning("Búsqueda de suscripcion Id: " + Id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(Suscripcion nuevo)
        {
            try
            {
                _contexto.Suscripcion.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó una nueva suscripcion: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar la suscripcion: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Suscripcion actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Suscripcion where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;
                item.FechaDesde = actualiza.FechaDesde;
                item.FechaHasta = actualiza.FechaHasta;
                item.ValorActual = actualiza.ValorActual;
                item.IdUsuario = actualiza.IdUsuario;

                _contexto.Suscripcion.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó la suscripcion: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar la empresa: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int Id)
        {
            var item = (from h in _contexto.Suscripcion where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Registro> lista = (from tbl in _contexto.Registro where tbl.IdSuscripcion == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar la suscripcion porque tiene uno o más registros asociados");
            }


            _contexto.Suscripcion.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó la suscripcion: " + Id + ", " + item.Nombre);
            return Ok(Id);
        }

    }
}
