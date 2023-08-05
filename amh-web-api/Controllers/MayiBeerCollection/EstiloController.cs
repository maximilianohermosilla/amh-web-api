using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AccessData;
using amh_web_api.DTO;
using Domain.Models.MayiBeerCollection;

namespace amh_web_api.Controllers.MayiBeerCollection
{
    [Route("[controller]")]
    [ApiController]
    public class EstiloController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<EstiloController> _logger;
        public EstiloController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<EstiloController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<EstiloDTO>> Estilos()
        {
            var lst = (from tbl in _contexto.Estilo where tbl.Id > 0 select new Estilo() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            List<EstiloDTO> estilosDTO = _mapper.Map<List<EstiloDTO>>(lst);

            //foreach (var item in estilosDTO)
            //{
            //    Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();
            //    if (_archivo != null)
            //    {
            //        string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
            //        item.Imagen = stringArchivo;
            //    }
            //}

            return Ok(estilosDTO);
        }

        [HttpGet("listarProxy/")]
        public ActionResult<IEnumerable<EstiloDTO>> EstilosProxy()
        {
            var lst = (from tbl in _contexto.Estilo where tbl.Id > 0 select new Estilo() { Id = tbl.Id, Nombre = tbl.Nombre }).OrderBy(e => e.Nombre).ToList();

            List<EstiloDTO> estilosDTO = _mapper.Map<List<EstiloDTO>>(lst);

            return Ok(estilosDTO);
        }

        [HttpGet("buscar/{EstiloId}")]
        public ActionResult<EstiloDTO> Estilos(int EstiloId)
        {
            Estilo cl = (from tbl in _contexto.Estilo where tbl.Id == EstiloId select new Estilo() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (cl == null)
            {
                return NotFound(EstiloId);
            }

            EstiloDTO item = _mapper.Map<EstiloDTO>(cl);

            //Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();

            //if (_archivo != null)
            //{
            //    string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
            //    item.Imagen = stringArchivo;
            //}
            _logger.LogWarning("Búsqueda de Estilo Id: " + EstiloId + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(EstiloDTO nuevo)
        {
            try
            {
                Estilo _estilo = _mapper.Map<Estilo>(nuevo);

                //if (nuevo.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(nuevo.Imagen);
                //    Archivo newArch = new Archivo() { Archivo1 = bytes };
                //    _contexto.Archivo.Add(newArch);
                //    _contexto.SaveChanges();
                //    _estilo.IdArchivo = newArch.Id;
                //}

                _contexto.Estilo.Add(_estilo);
                _contexto.SaveChanges();

                nuevo.Id = _estilo.Id;

                _logger.LogWarning("Se insertó un nuevo estilo: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el estilo: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(EstiloDTO actualiza)
        {
            string oldName = "";
            try
            {
                Estilo _estilo = (from h in _contexto.Estilo where h.Id == actualiza.Id select h).FirstOrDefault();

                if (_estilo == null)
                {
                    return NotFound(actualiza);
                }
                oldName = _estilo.Nombre;
                _estilo.Nombre = actualiza.Nombre;

                //if (actualiza.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(actualiza.Imagen);
                //    Archivo arch = (from a in _contexto.Archivo where a.Id == _estilo.IdArchivo select a).FirstOrDefault();

                //    if (arch == null)
                //    {
                //        Archivo newArch = new Archivo() { Archivo1 = bytes };
                //        _contexto.Archivo.Add(newArch);
                //        _contexto.SaveChanges();
                //        _estilo.IdArchivo = newArch.Id;
                //    }
                //    else
                //    {
                //        arch.Archivo1 = bytes;
                //        _contexto.Archivo.Update(arch);
                //        _contexto.SaveChanges();
                //    }
                //}

                _contexto.Estilo.Update(_estilo);
                _contexto.SaveChanges();

                _logger.LogWarning("Se actualizó el estilo: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("eliminar/{EstiloId}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int EstiloId)
        {
            Estilo _estilo = (from h in _contexto.Estilo where h.Id == EstiloId select h).FirstOrDefault();

            if (_estilo == null)
            {
                return NotFound(EstiloId);
            }

            //Archivo arch = (from a in _contexto.Archivo where a.Id == _estilo.IdArchivo select a).FirstOrDefault();

            List<Cerveza> _cervezas = (from tbl in _contexto.Cerveza where tbl.IdEstilo == EstiloId select tbl).ToList();
            if (_cervezas.Count() > 0)
            {
                return BadRequest("No se puede eliminar el estilo porque tiene una o más cervezas asociadas");
            }

            //if (arch != null)
            //{
            //    _contexto.Archivo.Remove(arch);
            //    _contexto.SaveChanges();
            //}

            _contexto.Estilo.Remove(_estilo);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el estilo: " + EstiloId + ", " + _estilo.Nombre);
            return Ok(EstiloId);
        }
    }
}