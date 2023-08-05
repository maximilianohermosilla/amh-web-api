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
    public class BancoController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<BancoController> _logger;

        public BancoController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<BancoController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Banco>> Bancos()
        {
            var lst = (from tbl in _contexto.Banco where tbl.Id > 0 select new Banco() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            return Ok(lst);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<Banco> Banco(int Id)
        {
            var item = (from tbl in _contexto.Banco where tbl.Id == Id select new Banco() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (item == null)
            {
                return NotFound(Id);
            }

            _logger.LogWarning("Búsqueda de banco Id: " + Id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(Banco nuevo)
        {
            try
            {
                _contexto.Banco.Add(nuevo);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó un nuevo banco: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el banco: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Banco actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Banco where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = actualiza.Nombre;

                _contexto.Banco.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el banco: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar el banco: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int Id)
        {
            var item = (from h in _contexto.Banco where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Tarjeta> lista = (from tbl in _contexto.Tarjeta where tbl.IdBanco == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar el banco porque tiene una o más tarjetas asociadas");
            }


            _contexto.Banco.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el tipo de tarjeta: " + Id + ", " + item.Nombre);
            return Ok(Id);
        }

    }
}
