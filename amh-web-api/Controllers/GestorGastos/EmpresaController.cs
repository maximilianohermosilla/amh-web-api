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
    public class EmpresaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<EmpresaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Empresa>> Empresas()
        {
            var lst = (from tbl in _contexto.Empresa where tbl.Id > 0 select new Empresa() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<Empresa> Empresas(int Id)
        {
            var item = (from tbl in _contexto.Empresa where tbl.Id == Id select new Empresa() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(Id);
            }

            _logger.LogWarning("Búsqueda de empresa Id: " + Id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(Empresa nuevo)
        {
            try
            {
                _contexto.Empresa.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó una nueva empresa: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar la empresa: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Empresa actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Empresa where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;

                _contexto.Empresa.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó la empresa: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
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
            var item = (from h in _contexto.Empresa where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Registro> lista = (from tbl in _contexto.Registro where tbl.IdEmpresa == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar la empresa porque tiene uno o más registros asociados");
            }


            _contexto.Empresa.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó la empresa: " + Id + ", " + item.Nombre);
            return Ok(Id);
        }

    }
}
