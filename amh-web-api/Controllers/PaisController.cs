using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AccessData;
using amh_web_api.DTO;
using Domain.Models;
using Domain.Models.MayiBeerCollection;

#nullable disable
namespace amh_web_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<PaisController> _logger;

        public PaisController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<PaisController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]        
        public ActionResult<IEnumerable<PaisDTO>> Pais()
        {
            List<Pais> lst = (from tbl in _contexto.Pais where tbl.Id > 0 select new Pais() { Id = tbl.Id, Nombre = tbl.Nombre, Imagen = tbl.Imagen }).ToList();

            List<PaisDTO> _paises = _mapper.Map<List<PaisDTO>>(lst);

            foreach (var item in _paises)
            {
                //List<Ciudad> _ciudades = (from tbl in _contexto.Ciudad where tbl.IdPais == item.Id select tbl).ToList();
                //if (_ciudades != null)
                //{
                //    item.ciudades = _ciudades;
                //}

                //Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();
                //if (_archivo != null)
                //{
                //    string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
                //    item.Imagen = stringArchivo;
                //}
            }

            return _paises;
        }

        [HttpGet("listarProxy/")]
        public ActionResult<IEnumerable<PaisDTO>> PaisesProxy()
        {
            List<Pais> lst = (from tbl in _contexto.Pais where tbl.Id > 0 select new Pais() { Id = tbl.Id, Nombre = tbl.Nombre }).OrderBy(e => e.Nombre).ToList();

            List<PaisDTO> _paises = _mapper.Map<List<PaisDTO>>(lst);

            foreach (var item in _paises)
            {
                //List<Ciudad> _ciudades = (from tbl in _contexto.Ciudad where tbl.IdPais == item.Id select tbl).ToList();
                //if (_ciudades != null)
                //{
                //    item.ciudades = _ciudades;
                //}
            }

            return _paises;
        }

        [HttpGet("buscar/{PaisId}")]
        public ActionResult<PaisDTO> Pais(int PaisId)
        {

            var cl = (from tbl in _contexto.Pais where tbl.Id == PaisId select new Pais() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (cl == null)
            {
                return NotFound(PaisId);
            }

            PaisDTO item = _mapper.Map<PaisDTO>(cl);

            //Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();

            //if (_archivo != null)
            //{
            //    string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
            //    item.Imagen = stringArchivo;
            //}

            _logger.LogWarning("Búsqueda de País Id: " + PaisId + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(PaisDTO nuevoPais)
        {
            try
            {
                Pais _pais = _mapper.Map<Pais>(nuevoPais);

                //if (nuevoPais.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(nuevoPais.Imagen);
                //    Archivo newArch = new Archivo() { Archivo1 = bytes };
                //    _contexto.Archivo.Add(newArch);
                //    _contexto.SaveChanges();
                //    _pais.IdArchivo = newArch.Id;
                //}

                _contexto.Pais.Add(_pais);
                _contexto.SaveChanges();

                nuevoPais.Id = _pais.Id;

                _logger.LogWarning("Se insertó un nuevo país: " + nuevoPais.Id + ". Nombre: " + nuevoPais.Nombre);
                return Ok(nuevoPais);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el país: " + nuevoPais.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }   
        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(PaisDTO actualiza)
        {
            string oldName = "";
            try
            {
                Pais _pais = (from h in _contexto.Pais where h.Id == actualiza.Id select h).FirstOrDefault();

                if (_pais == null)
                {
                    return NotFound(actualiza);
                }
                oldName = _pais.Nombre;
                _pais.Nombre = actualiza.Nombre;

                //if (actualiza.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(actualiza.Imagen);
                //    Archivo arch = (from a in _contexto.Archivo where a.Id == _pais.IdArchivo select a).FirstOrDefault();

                //    if (arch == null)
                //    {
                //        Archivo newArch = new Archivo() { Archivo1 = bytes };
                //        _contexto.Archivo.Add(newArch);
                //        _contexto.SaveChanges();
                //        _pais.IdArchivo = newArch.Id;
                //    }
                //    else
                //    {
                //        arch.Archivo1 = bytes;
                //        _contexto.Archivo.Update(arch);
                //        _contexto.SaveChanges();
                //    }
                //}

                _contexto.Pais.Update(_pais);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el país: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar el país: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{PaisId}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int PaisId)
        {
            Pais _pais = (from h in _contexto.Pais where h.Id == PaisId select h).FirstOrDefault();

            if (_pais == null)
            {
                return NotFound("No se encontró el elemento" + PaisId);
            }

            List<Ciudad> _ciudades = (from tbl in _contexto.Ciudad where tbl.IdPais == PaisId select tbl).ToList();
            if (_ciudades.Count() > 0)
            {
                return BadRequest("No se puede eliminar el país porque tiene una o más ciudades asociadas");
            }

            //Archivo arch = (from a in _contexto.Archivo where a.Id == _pais.IdArchivo select a).FirstOrDefault();

            //if (arch != null)
            //{
            //    _contexto.Archivo.Remove(arch);
            //    _contexto.SaveChanges();
            //}

            _contexto.Pais.Remove(_pais);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el país: " + PaisId + ", " + _pais.Nombre);
            return Ok(PaisId);
        }
    }
}