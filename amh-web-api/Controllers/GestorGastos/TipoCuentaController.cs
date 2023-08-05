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
    public class TipoCuentaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<TipoCuentaController> _logger;

        public TipoCuentaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<TipoCuentaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<TipoCuenta>> TiposTarjeta()
        {
            var lst = (from tbl in _contexto.TipoCuenta where tbl.Id > 0 select new TipoCuenta() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<TipoCuenta> TipoCuenta(int Id)
        {
            var item = (from tbl in _contexto.TipoCuenta where tbl.Id == Id select new TipoCuenta() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(Id);
            }

            _logger.LogWarning("Búsqueda de tipo de cuenta Id: " + Id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(TipoCuenta nuevo)
        {
            try
            {
                _contexto.TipoCuenta.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó un nuevo tipo de cuenta: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el tipo de cuenta: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(TipoCuenta actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.TipoCuenta where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;

                _contexto.TipoCuenta.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el tipo de cuenta: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar el tipo de cuenta: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int Id)
        {
            var item = (from h in _contexto.TipoCuenta where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Cuenta> lista = (from tbl in _contexto.Cuenta where tbl.IdTipoCuenta == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar el tipo de cuenta porque tiene una o más cuentas asociadas");
            }


            _contexto.TipoCuenta.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el tipo de cuenta: " + Id + ", " + item.Nombre);
            return Ok(Id);
        }

    }
}
