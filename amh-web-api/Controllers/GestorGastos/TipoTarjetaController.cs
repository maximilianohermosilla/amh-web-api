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
    public class TipoTarjetaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<TipoTarjetaController> _logger;

        public TipoTarjetaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<TipoTarjetaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<TipoTarjeta>> TiposTarjeta()
        {
            var lst = (from tbl in _contexto.TipoTarjeta where tbl.Id > 0 select new TipoTarjeta() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<TipoTarjeta> TipoTarjeta(int Id)
        {
            var item = (from tbl in _contexto.TipoTarjeta where tbl.Id == Id select new TipoTarjeta() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(Id);
            }

            _logger.LogWarning("Búsqueda de tipo de tarjeta Id: " + Id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(TipoTarjeta nuevo)
        {
            try
            {
                _contexto.TipoTarjeta.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó un nuevo tipo de tarjeta: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el tipo de tarjeta: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(TipoTarjeta actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.TipoTarjeta where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;

                _contexto.TipoTarjeta.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el tipo de tarjeta: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar el tipo de tarjeta: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int Id)
        {
            var item = (from h in _contexto.TipoTarjeta where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Tarjeta> lista = (from tbl in _contexto.Tarjeta where tbl.IdTipoTarjeta == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar el tipo de tarjeta porque tiene una o más tarjetas asociadas");
            }


            _contexto.TipoTarjeta.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el tipo de tarjeta: " + Id + ", " + item.Nombre);
            return Ok(Id);
        }

    }
}
