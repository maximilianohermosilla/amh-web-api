using AccessData;
using amh_web_api.DTO;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace amh_web_api.Controllers.GestorGastos
{
    [Route("gestorGastos/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<CuentaController> _logger;

        public CuentaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<CuentaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Cuenta>> Cuentas()
        {
            var lst = (from tbl in _contexto.Cuenta where tbl.Id > 0 select tbl).ToList();
            List<CuentaDTO> cuentasDTO = _mapper.Map<List<CuentaDTO>>(lst);

            foreach (var item in cuentasDTO)
            {
                var tarjeta = (from h in _contexto.Tarjeta where h.Id == item.IdTarjeta select h).FirstOrDefault();
                if (tarjeta != null)
                {
                    item.TarjetaNombre = tarjeta.Numero;
                }

                var tipoCuenta = (from h in _contexto.TipoCuenta where h.Id == item.IdTipoCuenta select h).FirstOrDefault();
                if (tipoCuenta != null)
                {
                    item.TipoCuentaNombre = tipoCuenta.Nombre;
                }

                var usuario = (from h in _contexto.Usuario where h.Id == item.IdUsuario select h).FirstOrDefault();
                if (usuario != null)
                {
                    item.UsuarioNombre = usuario.Nombre;
                }
            }
            
            return Ok(cuentasDTO);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<Cuenta> Cuenta(int Id)
        {
            var cuenta = (from tbl in _contexto.Cuenta where tbl.Id == Id select tbl).FirstOrDefault();
            CuentaDTO item = _mapper.Map<CuentaDTO>(cuenta);
            if (item == null)
            {
                return NotFound(Id);
            }

            var tarjeta = (from h in _contexto.Tarjeta where h.Id == item.IdTarjeta select h).FirstOrDefault();
            if (tarjeta != null)
            {
                item.TarjetaNombre = tarjeta.Numero;
            }

            var tipoCuenta = (from h in _contexto.TipoCuenta where h.Id == item.IdTipoCuenta select h).FirstOrDefault();
            if (tipoCuenta != null)
            {
                item.TipoCuentaNombre = tipoCuenta.Nombre;
            }

            var usuario = (from h in _contexto.Usuario where h.Id == item.IdUsuario select h).FirstOrDefault();
            if (usuario != null)
            {
                item.UsuarioNombre = usuario.Nombre;
            }

            _logger.LogWarning("Búsqueda de cuenta Id: " + Id + ". Resultados: " + item.Nombre);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(CuentaDTO nuevo)
        {
            try
            {
                Cuenta cuenta = _mapper.Map<Cuenta>(nuevo);
                _contexto.Cuenta.Add(cuenta);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó una nueva cuenta: " + nuevo.Id + ". Nombre: " + nuevo.Nombre);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar la cuenta: " + nuevo.Nombre + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Cuenta actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Cuenta where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Nombre;
                item.Nombre = item.Nombre;
                item.IdTipoCuenta = actualiza.IdTipoCuenta;
                item.IdTarjeta = actualiza.IdTarjeta;
                item.IdUsuario = actualiza.IdUsuario;
                item.Habilitado = actualiza.Habilitado;

                _contexto.Cuenta.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó la cuenta: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Nombre);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar la cuenta: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int Id)
        {
            var item = (from h in _contexto.Cuenta where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Registro> lista = (from tbl in _contexto.Registro where tbl.IdCuenta == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar la cuenta porque tiene uno o más registros asociados");
            }


            _contexto.Cuenta.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó la cuenta: " + Id + ", " + item.Nombre);
            return Ok(Id);
        }

    }
}
