using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using amhWebAPI.DTO;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AccessData;
using Domain.Models.MayiBeerCollection;
using amh_web_api.DTO;
using Domain.Models;

namespace amh_web_api.Controllers.MayiBeerCollection
{
    [Route("[controller]")]
    [ApiController]
    public class CervezaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<CervezaController> _logger;

        public CervezaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<CervezaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Cerveza>> Cervezas()
        {
            try
            {
                List<Cerveza> lst = (from tbl in _contexto.Cerveza where tbl.Id > 0 select tbl).ToList();

                List<CervezaDTO> cervezasDTO = _mapper.Map<List<CervezaDTO>>(lst);

                foreach (var item in cervezasDTO)
                {
                    Estilo _estilo = (from h in _contexto.Estilo where h.Id == item.IdEstilo select h).FirstOrDefault();
                    if (_estilo != null)
                    {
                        item.NombreEstilo = _estilo.Nombre;
                    }

                    Marca _marca = (from h in _contexto.Marca where h.Id == item.IdMarca select h).FirstOrDefault();
                    if (_marca != null)
                    {
                        item.NombreMarca = _marca.Nombre;
                    }

                    //Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();
                    //if (_archivo != null)
                    //{
                    //    string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
                    //    item.Imagen = stringArchivo;
                    //}

                    Ciudad _ciudad = (from h in _contexto.Ciudad where h.Id == item.IdCiudad select h).FirstOrDefault();
                    if (_ciudad != null)
                    {
                        Pais _pais = (from h in _contexto.Pais where h.Id == _ciudad.IdPais select h).FirstOrDefault();
                        item.IdPais = _pais.Id;
                        item.NombrePais = _pais.Nombre;
                        item.NombreCiudad = _ciudad.Nombre + " (" + _pais.Nombre + ")";
                    }
                }
                return Ok(cervezasDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("listarProxy/")]
        public ActionResult<IEnumerable<Cerveza>> CervezasProxy()
        {
            try
            {
                List<Cerveza> lst = (from tbl in _contexto.Cerveza where tbl.Id > 0 select tbl).OrderBy(e => e.IdMarca).ToList();

                List<CervezaDTO> cervezasDTO = _mapper.Map<List<CervezaDTO>>(lst);

                foreach (var item in cervezasDTO)
                {
                    Estilo _estilo = (from h in _contexto.Estilo where h.Id == item.IdEstilo select h).FirstOrDefault();
                    if (_estilo != null)
                    {
                        item.NombreEstilo = _estilo.Nombre;
                    }

                    Marca _marca = (from h in _contexto.Marca where h.Id == item.IdMarca select h).FirstOrDefault();
                    if (_marca != null)
                    {
                        item.NombreMarca = _marca.Nombre;
                    }

                    Ciudad _ciudad = (from h in _contexto.Ciudad where h.Id == item.IdCiudad select h).FirstOrDefault();
                    if (_ciudad != null)
                    {
                        Pais _pais = (from h in _contexto.Pais where h.Id == _ciudad.IdPais select h).FirstOrDefault();
                        item.IdPais = _pais.Id;
                        item.NombrePais = _pais.Nombre;
                        item.NombreCiudad = _ciudad.Nombre + " (" + _pais.Nombre + ")";
                    }
                }
                return Ok(cervezasDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("listarMarcas/")]
        public ActionResult<IEnumerable<ReporteDTO>> CervezasMarcas()
        {
            try
            {
                var lista = (from dt in _contexto.Cerveza
                             join d in _contexto.Marca on dt.IdMarca equals d.Id
                             select d).GroupBy(p => p.Nombre)
                   .Select(g => new { name = g.Key, value = g.Count() });


                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("listarEstilos/")]
        public ActionResult<IEnumerable<ReporteDTO>> CervezasEstilos()
        {
            try
            {
                var lista = (from dt in _contexto.Cerveza
                             join d in _contexto.Estilo on dt.IdEstilo equals d.Id
                             select d).GroupBy(p => p.Nombre)
                   .Select(g => new { name = g.Key, value = g.Count() });


                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("listarCiudades/")]
        public ActionResult<IEnumerable<ReporteDTO>> CervezasCiudades()
        {
            try
            {
                var lista = (from dt in _contexto.Cerveza
                             join d in _contexto.Ciudad on dt.IdCiudad equals d.Id
                             select d).GroupBy(p => p.Nombre)
                   .Select(g => new { name = g.Key, value = g.Count() });


                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("listarPaises/")]
        public ActionResult<IEnumerable<ReporteDTO>> CervezasPaises()
        {
            try
            {
                var lista = (from C in _contexto.Cerveza
                             join dc in _contexto.Ciudad on C.IdCiudad equals dc.Id
                             join dp in _contexto.Pais on dc.IdPais equals dp.Id
                             select dp).GroupBy(p => p.Nombre)
                   .Select(g => new { name = g.Key, value = g.Count() });


                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("listarCantidades/")]
        public ActionResult<IEnumerable<ReporteDTO>> CervezasCantidades()
        {
            try
            {
                List<ReporteDTO> lista = new List<ReporteDTO>();
                var listaTotal = (from tbl in _contexto.Cerveza where tbl.Id > 0 select tbl.Id).ToList();
                var listaMarcas = (from d in _contexto.Cerveza
                                   select d).GroupBy(p => p.IdMarca)
                   .Select(g => new { name = g.Key, value = g.Count() });
                var listaEstilos = (from d in _contexto.Cerveza
                                    select d).GroupBy(p => p.IdEstilo)
                                .Select(g => new { name = g.Key, value = g.Count() });
                var listaCiudades = (from d in _contexto.Cerveza
                                     select d).GroupBy(p => p.IdCiudad)
                .Select(g => new { name = g.Key, value = g.Count() });
                var listaPaises = (from dt in _contexto.Cerveza
                                   join d in _contexto.Ciudad on dt.IdCiudad equals d.Id
                                   select d).GroupBy(p => p.IdPais)
                .Select(g => new { name = g.Key, value = g.Count() });

                lista.Add(new ReporteDTO() { name = "Cervezas", value = listaTotal.Count() });
                lista.Add(new ReporteDTO() { name = "Marcas", value = listaMarcas.Count() });
                lista.Add(new ReporteDTO() { name = "Estilos", value = listaEstilos.Count() });
                lista.Add(new ReporteDTO() { name = "Paises", value = listaPaises.Count() });
                lista.Add(new ReporteDTO() { name = "Ciudades", value = listaCiudades.Count() });

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("buscar/{CervezaId}")]
        public ActionResult<Cerveza> Cervezas(int CervezaId)
        {
            try
            {
                Cerveza cl = (from tbl in _contexto.Cerveza where tbl.Id == CervezaId select tbl).FirstOrDefault();

                if (cl == null)
                {
                    return NotFound(CervezaId);
                }

                CervezaDTO item = _mapper.Map<CervezaDTO>(cl);

                Estilo _estilo = (from h in _contexto.Estilo where h.Id == item.IdEstilo select h).FirstOrDefault();
                if (_estilo != null)
                {
                    item.NombreEstilo = _estilo.Nombre;
                }

                Marca _marca = (from h in _contexto.Marca where h.Id == item.IdMarca select h).FirstOrDefault();
                if (_marca != null)
                {
                    item.NombreMarca = _marca.Nombre;
                }

                //Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();
                //if (_archivo != null)
                //{
                //    string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
                //    item.Imagen = stringArchivo;
                //    //item.ImageFile = _archivo.Archivo1;
                //}

                Ciudad _ciudad = (from h in _contexto.Ciudad where h.Id == item.IdCiudad select h).FirstOrDefault();
                if (_ciudad != null)
                {
                    Pais _pais = (from h in _contexto.Pais where h.Id == _ciudad.IdPais select h).FirstOrDefault();
                    item.IdPais = _pais.Id;
                    item.NombrePais = _pais.Nombre;
                    item.NombreCiudad = _ciudad.Nombre + " (" + _pais.Nombre + ")";
                }

                _logger.LogWarning("Búsqueda de Cerveza Id: " + CervezaId + ". Resultados: " + item.Nombre);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("busquedaFiltros")]
        public ActionResult<Cerveza> CervezasByFilter(BusquedaDTO busqueda)
        {
            try
            {
                List<Cerveza> lst = (from tbl in _contexto.Cerveza
                                     where
                              (tbl.IdMarca == busqueda.IdMarca || busqueda.IdMarca == 0) &&
                              (tbl.IdEstilo == busqueda.IdEstilo || busqueda.IdEstilo == 0) &&
                              (tbl.IdCiudad == busqueda.IdCiudad || busqueda.IdCiudad == 0 && busqueda.IdPais == 0 ||
                              busqueda.IdCiudad == 0 && busqueda.IdPais > 0 && (from tblCiudad in _contexto.Ciudad where tblCiudad.IdPais == busqueda.IdPais select tblCiudad.Id).Contains((int)tbl.IdCiudad)
                              )
                                     select tbl).ToList();

                if (lst == null)
                {
                    return NotFound(busqueda);
                }


                List<CervezaDTO> cervezasDTO = _mapper.Map<List<CervezaDTO>>(lst);
                foreach (var item in cervezasDTO)
                {
                    Estilo _estilo = (from h in _contexto.Estilo where h.Id == item.IdEstilo select h).FirstOrDefault();
                    if (_estilo != null)
                    {
                        item.NombreEstilo = _estilo.Nombre;
                    }

                    Marca _marca = (from h in _contexto.Marca where h.Id == item.IdMarca select h).FirstOrDefault();
                    if (_marca != null)
                    {
                        item.NombreMarca = _marca.Nombre;
                    }

                    //Archivo _archivo = (from h in _contexto.Archivo where h.Id == item.IdArchivo select h).FirstOrDefault();
                    //if (_archivo != null)
                    //{
                    //    string stringArchivo = Encoding.ASCII.GetString(_archivo.Archivo1);
                    //    item.Imagen = stringArchivo;
                    //}

                    Ciudad _ciudad = (from h in _contexto.Ciudad where h.Id == item.IdCiudad select h).FirstOrDefault();
                    if (_ciudad != null)
                    {
                        Pais _pais = (from h in _contexto.Pais where h.Id == _ciudad.IdPais select h).FirstOrDefault();
                        item.IdPais = _pais.Id;
                        item.NombrePais = _pais.Nombre;
                        item.NombreCiudad = _ciudad.Nombre + " (" + _pais.Nombre + ")";
                    }
                }
                return Ok(cervezasDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(CervezaDTO nuevo)
        {
            try
            {
                Cerveza _cerveza = _mapper.Map<Cerveza>(nuevo);

                //if (nuevo.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(nuevo.Imagen);
                //    Archivo newArch = new Archivo() { Archivo1 = bytes };
                //    _contexto.Archivo.Add(newArch);
                //    _contexto.SaveChanges();
                //    _cerveza.imagen = "";
                //    _cerveza.IdArchivo = newArch.Id;
                //}

                _contexto.Cerveza.Add(_cerveza);
                _contexto.SaveChanges();

                nuevo.Id = _cerveza.Id;

                _logger.LogWarning("Se insertó una nueva cerveza: " + nuevo.Id + ". Detalle: " + nuevo.Nombre + ", " + nuevo.NombreMarca + ", " + nuevo.NombreEstilo
                     + ", " + nuevo.NombrePais + ", " + nuevo.NombreCiudad + ", Ibu=" + nuevo.Ibu + ", Alcohol=" + nuevo.Alcohol + "%, Contenido=" + nuevo.Contenido + ", " + nuevo.Observaciones);
                return Ok(nuevo);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar la cerveza: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest("Hubo un problema al guardar la cerveza: " + ex.Message);
            }
        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(CervezaDTO actualiza)
        {
            string oldName = "";
            string oldMarca = "";
            string oldEstilo = "";
            string oldCiudad = "";
            string oldIbu = "";
            string oldAlcohol = "";
            string oldContenido = "";
            string oldObservaciones = "";
            try
            {
                Cerveza _cerveza = (from h in _contexto.Cerveza where h.Id == actualiza.Id select h).FirstOrDefault();

                if (_cerveza == null)
                {
                    return NotFound(actualiza);
                }

                //if (actualiza.Imagen != null)
                //{
                //    byte[] bytes = Encoding.ASCII.GetBytes(actualiza.Imagen);
                //    Archivo arch = (from a in _contexto.Archivo where a.Id == _cerveza.IdArchivo select a).FirstOrDefault();

                //    if (arch == null)
                //    {
                //        Archivo newArch = new Archivo() { Archivo1 = bytes };
                //        _contexto.Archivo.Add(newArch);
                //        _contexto.SaveChanges();
                //        _cerveza.IdArchivo = newArch.Id;
                //    }
                //    else
                //    {
                //        arch.Archivo1 = bytes;
                //        _contexto.Archivo.Update(arch);
                //        _contexto.SaveChanges();
                //    }
                //}
                oldName = _cerveza.Nombre;
                oldMarca = _cerveza.IdMarca > 0 ? _cerveza.IdMarca.ToString() : "";
                oldEstilo = _cerveza.IdEstilo > 0 ? _cerveza.IdEstilo.ToString() : "";
                oldCiudad = _cerveza.IdCiudad > 0 ? _cerveza.IdCiudad.ToString() : "";
                oldIbu = _cerveza.IBU > 0 ? _cerveza.IBU.ToString() : "";
                oldAlcohol = _cerveza.Alcohol > 0 ? _cerveza.Alcohol.ToString() : "";
                oldContenido = _cerveza.Contenido > 0 ? _cerveza.Contenido.ToString() : "";
                oldObservaciones = _cerveza.Observaciones;
                _cerveza.Nombre = actualiza.Nombre;
                _cerveza.IBU = actualiza.Ibu;
                _cerveza.Alcohol = actualiza.Alcohol;
                _cerveza.Contenido = actualiza.Contenido;
                _cerveza.Observaciones = actualiza.Observaciones;
                _cerveza.IdCiudad = actualiza.IdCiudad;
                _cerveza.IdEstilo = actualiza.IdEstilo;
                _cerveza.IdMarca = actualiza.IdMarca;

                _contexto.Cerveza.Update(_cerveza);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó la cerveza: " + actualiza.Id + ". Datos anteriores: " + oldName + ", IdMarca=" + oldMarca + ", IdEstilo=" + oldEstilo
                + ", IdCiudad=" + oldCiudad + ", Ibu=" + oldIbu + " ,Alcohol=" + oldIbu + "%, Contenido=" + oldContenido + "ml/cc, Observaciones=" + oldObservaciones);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar la cerveza: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest("Hubo un problema al guardar la cerveza");
            }
        }
        [HttpDelete("eliminar/{CervezaId}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int CervezaId)
        {
            Cerveza _cerveza = (from h in _contexto.Cerveza where h.Id == CervezaId select h).FirstOrDefault();
            try
            {

                if (_cerveza == null)
                {
                    return NotFound(CervezaId);
                }

                //Archivo arch = (from a in _contexto.Archivo where a.Id == _cerveza.IdArchivo select a).FirstOrDefault();

                //if (arch != null)
                //{
                //    _contexto.Archivo.Remove(arch);
                //    _contexto.SaveChanges();
                //}

                _contexto.Cerveza.Remove(_cerveza);
                _contexto.SaveChanges();
                _logger.LogWarning("Se eliminó la cerveza: " + CervezaId + ", " + _cerveza.Nombre);
                return Ok(CervezaId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al eliminar la cerveza: " + CervezaId + ", " + _cerveza.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}