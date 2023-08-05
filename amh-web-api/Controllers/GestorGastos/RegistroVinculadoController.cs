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
    public class RegistroVinculadoController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroVinculadoController> _logger;

        public RegistroVinculadoController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<RegistroVinculadoController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<RegistroVinculado>> RegistrosVinculados()
        {
            var lst = (from tbl in _contexto.RegistroVinculado where tbl.Id > 0 select tbl).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<RegistroVinculado> RegistroVinculado(int Id)
        {
            var item = (from tbl in _contexto.RegistroVinculado where tbl.Id == Id select tbl).FirstOrDefault();
            if (item == null)
            {
                return NotFound(Id);
            }

            _logger.LogWarning("Búsqueda de Registro Vinculado Id: " + Id + ". Resultados: " + item.Descripcion);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(RegistroVinculado nuevo)
        {
            try
            {
                _contexto.RegistroVinculado.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó un nuevo Registro Vinculado: " + nuevo.Id + ". Nombre: " + nuevo.Descripcion);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el Registro Vinculado: " + nuevo.Descripcion + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(RegistroVinculado actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.RegistroVinculado where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Descripcion;
                item.Descripcion = actualiza.Descripcion;
                item.Cuotas = actualiza.Cuotas;
                item.ValorFinal = actualiza.ValorFinal;

                _contexto.RegistroVinculado.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el Registro Vinculado: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Descripcion);
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
            var item = (from h in _contexto.RegistroVinculado where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Registro> lista = (from tbl in _contexto.Registro where tbl.IdSuscripcion == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar el Registro Vinculado porque tiene uno o más registros asociados");
            }


            _contexto.RegistroVinculado.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el Registro Vinculado: " + Id + ", " + item.Descripcion);
            return Ok(Id);
        }

    }
}