using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AccessData;
using amh_web_api.DTO;
using Domain.Models.MayiBeerCollection;

namespace amh_web_api.Controllers.MayiBeerCollection
{
    [Route("[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<MarcaController> _logger;

        public MarcaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<MarcaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<MarcaDTO>> Marcas()
        {
            var lst = (from tbl in _contexto.Marca where tbl.Id > 0 select new Marca() { Id = tbl.Id, Nombre = tbl.Nombre }).ToList();

            List<MarcaDTO> marcasDTO = _mapper.Map<List<MarcaDTO>>(lst);

            //foreach (var item in marcasDTO)
            //{
            //    Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();
            //    if (_archivo != null)
            //    {
            //        string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
            //        item.Imagen = stringArchivo;
            //    }
            //}

            return Ok(marcasDTO);
        }

        [HttpGet("listarProxy/")]
        public ActionResult<IEnumerable<MarcaDTO>> MarcasProxy()
        {
            //_logger.LogWarning("Lista de marcas proxy");
            var lst = (from tbl in _contexto.Marca where tbl.Id > 0 select new Marca() { Id = tbl.Id, Nombre = tbl.Nombre }).OrderBy(e => e.Nombre).ToList();

            List<MarcaDTO> marcasDTO = _mapper.Map<List<MarcaDTO>>(lst);


            return Ok(marcasDTO);
        }

        [HttpGet("buscar/{MarcaId}")]
        public ActionResult<MarcaDTO> Marcas(int MarcaId)
        {
            Marca cl = (from tbl in _contexto.Marca where tbl.Id == MarcaId select new Marca() { Id = tbl.Id, Nombre = tbl.Nombre }).FirstOrDefault();
            if (cl == null)
            {
                return NotFound(MarcaId);
            }

            MarcaDTO item = _mapper.Map<MarcaDTO>(cl);

            //Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();

            //if (_archivo != null)
            //{
            //    string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
            //    item.Imagen = stringArchivo;
            //}
            _logger.LogWarning("Búsqueda de Marca Id: " + MarcaId + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(MarcaDTO nuevo)
        {
            try
            {
                Marca _marca = _mapper.Map<Marca>(nuevo);

                //if (nuevo.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(nuevo.Imagen);
                //    Archivo newArch = new Archivo() { Archivo1 = bytes };
                //    _contexto.Archivo.Add(newArch);
                //    _contexto.SaveChanges();
                //    _marca.IdArchivo = newArch.Id;
                //}

                _contexto.Marca.Add(_marca);
                _contexto.SaveChanges();

                nuevo.Id = _marca.Id;

                _logger.LogWarning("Se insertó una nueva marca: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar la marca: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(MarcaDTO actualiza)
        {
            string oldName = "";
            try
            {
                Marca _marca = (from h in _contexto.Marca where h.Id == actualiza.Id select h).FirstOrDefault();

                if (_marca == null)
                {
                    return NotFound(actualiza);
                }
                oldName = _marca.Nombre;
                _marca.Nombre = actualiza.Nombre;
                //if (actualiza.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(actualiza.Imagen);
                //    Archivo arch = (from a in _contexto.Archivo where a.Id == _marca.IdArchivo select a).FirstOrDefault();

                //    if (arch == null)
                //    {
                //        Archivo newArch = new Archivo() { Archivo1 = bytes };
                //        _contexto.Archivo.Add(newArch);
                //        _contexto.SaveChanges();
                //        _marca.IdArchivo = newArch.Id;
                //    }
                //    else
                //    {
                //        arch.Archivo1 = bytes;
                //        _contexto.Archivo.Update(arch);
                //        _contexto.SaveChanges();
                //    }
                //}

                _contexto.Marca.Update(_marca);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó la marca: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar la marca: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{MarcaId}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int MarcaId)
        {
            Marca _marca = (from h in _contexto.Marca where h.Id == MarcaId select h).FirstOrDefault();

            if (_marca == null)
            {
                return NotFound(MarcaId);
            }

            List<Cerveza> _cervezas = (from tbl in _contexto.Cerveza where tbl.IdMarca == MarcaId select tbl).ToList();
            if (_cervezas.Count() > 0)
            {
                return BadRequest("No se puede eliminar la marca porque tiene una o más cervezas asociadas");
            }

            //Archivo arch = (from a in _contexto.Archivo where a.Id == _marca.IdArchivo select a).FirstOrDefault();

            //if (arch != null)
            //{
            //    _contexto.Archivo.Remove(arch);
            //    _contexto.SaveChanges();
            //}

            _contexto.Marca.Remove(_marca);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó la marca: " + MarcaId + ", " + _marca.Nombre);
            return Ok(MarcaId);
        }
    }
}