using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AccessData;
using Domain.Models.MayiBeerCollection;
using amh_web_api.DTO;
using Domain.Models;

namespace amh_web_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<CiudadController> _logger;

        public CiudadController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<CiudadController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Ciudades()
        {
            List<Ciudad> lst = (from tbl in _contexto.Ciudad where tbl.Id > 0 select tbl).OrderBy(e => e.IdPais).ThenBy(e => e.Nombre).ToList();

            List<CiudadDTO> ciudadesDTO = _mapper.Map<List<CiudadDTO>>(lst);

            foreach (var item in ciudadesDTO)
            {
                Pais _pais = (from h in _contexto.Pais where h.Id == item.IdPais select h).FirstOrDefault();
                if (_pais != null)
                {
                    item.PaisNombre = _pais.Nombre;
                }
            }

            return Ok(ciudadesDTO);
        }

        [HttpGet("buscarPais/{PaisId}")]
        public ActionResult<IEnumerable<Ciudad>> CiudadesByPais(int PaisId)
        {
            Pais _pais = (from h in _contexto.Pais where h.Id == PaisId select h).FirstOrDefault();
            List<Ciudad> lst = (from tbl in _contexto.Ciudad where tbl.IdPais == PaisId select tbl).ToList();
            List<CiudadDTO> ciudadesDTO = _mapper.Map<List<CiudadDTO>>(lst);


            if (lst == null || _pais == null)
            {
                return NotFound(PaisId);
            }


            foreach (var item in ciudadesDTO)
            {                
                if (_pais != null)
                {
                    item.PaisNombre = _pais.Nombre;
                }
            }
            
            return Ok(ciudadesDTO);
        }

        [HttpGet("buscar/{CiudadId}")]
        public ActionResult<Ciudad> Ciudades(int CiudadId)
        {
            Ciudad cl = (from tbl in _contexto.Ciudad where tbl.Id == CiudadId select tbl).FirstOrDefault();

            if (cl == null)
            {
                return NotFound(CiudadId);
            }
            CiudadDTO ciudadDTO = _mapper.Map<CiudadDTO>(cl);

            Pais _pais = (from h in _contexto.Pais where h.Id == cl.IdPais select h).FirstOrDefault();
            if (_pais != null)
            {
                ciudadDTO.PaisNombre = _pais.Nombre;
            }

            _logger.LogWarning("Búsqueda de Marca Id: " + CiudadId + ". Resultados: " + ciudadDTO.Nombre + ", " + _pais.Nombre);
            return Ok(ciudadDTO);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(CiudadDTO nuevo)
        {
            Ciudad _ciudad = _mapper.Map<Ciudad>(nuevo);

            _contexto.Ciudad.Add(_ciudad);
            _contexto.SaveChanges();

            nuevo.Id = _ciudad.Id;

            _logger.LogWarning("Se insertó una nueva ciudad: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
            return Ok(nuevo);
        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(CiudadDTO actualiza)
        {
            string oldName = "";
            Ciudad _ciudad = (from h in _contexto.Ciudad where h.Id == actualiza.Id select h).FirstOrDefault();

            if (_ciudad == null)
            {
                return NotFound(actualiza);
            }
            oldName = _ciudad.Nombre;
            _ciudad.Nombre = actualiza.Nombre;
            _ciudad.IdPais = actualiza.IdPais;

            _contexto.Ciudad.Update(_ciudad);
            _contexto.SaveChanges();
            _logger.LogWarning("Se actualizó la ciudad: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
            return Ok(actualiza);
        }
        [HttpDelete("eliminar/{CiudadId}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int CiudadId)
        {
            Ciudad _ciudad = (from h in _contexto.Ciudad where h.Id == CiudadId select h).FirstOrDefault();

            if (_ciudad == null)
            {
                return NotFound(CiudadId);
            }

            List<Cerveza> _cervezas = (from tbl in _contexto.Cerveza where tbl.IdCiudad == CiudadId select tbl).ToList();
            if (_cervezas.Count() > 0)
            {
                return BadRequest("No se puede eliminar la ciudad porque tiene una o más cervezas asociadas");
            }

            _contexto.Ciudad.Remove(_ciudad);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó la ciudad: " + CiudadId + ", " + _ciudad.Nombre);
            return Ok(CiudadId);
        }
    }
}