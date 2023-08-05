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
    public class RegistroController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroController> _logger;

        public RegistroController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<RegistroController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Registro>> Registros()
        {
            var lst = (from tbl in _contexto.Registro where tbl.Id > 0 select tbl).ToList();
            List<RegistroDTO> listaDTO = _mapper.Map<List<RegistroDTO>>(lst);

            foreach (var item in listaDTO)
            {
                var empresa = (from h in _contexto.Empresa where h.Id == item.IdEmpresa select h).FirstOrDefault();
                if (empresa != null)
                {
                    item.EmpresaNombre = empresa.Nombre;
                }

                var suscripcion = (from h in _contexto.Suscripcion where h.Id == item.IdSuscripcion select h).FirstOrDefault();
                if (suscripcion != null)
                {
                    item.SuscripcionNombre = suscripcion.Nombre;
                }

                var cuenta = (from h in _contexto.Cuenta where h.Id == item.IdCuenta select h).FirstOrDefault();
                if (cuenta != null)
                {
                    item.CuentaNombre = cuenta.Nombre;
                }

                var registroVinculado = (from h in _contexto.RegistroVinculado where h.Id == item.IdRegistroVinculado select h).FirstOrDefault();
                if (registroVinculado != null)
                {
                    item.RegistroVinculadoNombre = registroVinculado.Descripcion;
                }

                var usuario = (from h in _contexto.Usuario where h.Id == item.IdUsuario select h).FirstOrDefault();
                if (usuario != null)
                {
                    item.UsuarioNombre = usuario.Nombre;
                }
            }

            return Ok(listaDTO);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<Registro> Registro(int Id)
        {
            var registro = (from tbl in _contexto.Registro where tbl.Id == Id select tbl).FirstOrDefault();
            RegistroDTO item = _mapper.Map<RegistroDTO>(registro);
            if (item == null)
            {
                return NotFound(Id);
            }

            var empresa = (from h in _contexto.Empresa where h.Id == item.IdEmpresa select h).FirstOrDefault();
            if (empresa != null)
            {
                item.EmpresaNombre = empresa.Nombre;
            }

            var suscripcion = (from h in _contexto.Suscripcion where h.Id == item.IdSuscripcion select h).FirstOrDefault();
            if (suscripcion != null)
            {
                item.SuscripcionNombre = suscripcion.Nombre;
            }

            var cuenta = (from h in _contexto.Cuenta where h.Id == item.IdCuenta select h).FirstOrDefault();
            if (cuenta != null)
            {
                item.CuentaNombre = cuenta.Nombre;
            }

            var registroVinculado = (from h in _contexto.RegistroVinculado where h.Id == item.IdRegistroVinculado select h).FirstOrDefault();
            if (registroVinculado != null)
            {
                item.RegistroVinculadoNombre = registroVinculado.Descripcion;
            }

            var usuario = (from h in _contexto.Usuario where h.Id == item.IdUsuario select h).FirstOrDefault();
            if (usuario != null)
            {
                item.UsuarioNombre = usuario.Nombre;
            }

            _logger.LogWarning("Búsqueda de registro Id: " + Id + ". Resultados: " + item.Descripcion);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(RegistroDTO nuevo)
        {
            try
            {
                Registro item = _mapper.Map<Registro>(nuevo);
                _contexto.Registro.Add(item);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó un nuevo registro: " + nuevo.Id + ". Descripcion: " + nuevo.Descripcion);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar el registro: " + nuevo.Descripcion + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Registro actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Registro where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Descripcion;
                item.Descripcion = actualiza.Descripcion;
                item.IdEmpresa = actualiza.IdEmpresa;
                item.IdSuscripcion = actualiza.IdSuscripcion;
                item.IdCuenta = actualiza.IdCuenta;
                item.IdRegistroVinculado= actualiza.IdRegistroVinculado;
                item.NumeroCuota = actualiza.NumeroCuota;
                item.Fecha = actualiza.Fecha;
                item.Valor = actualiza.Valor;
                item.IdUsuario = actualiza.IdUsuario;
                item.Observaciones = actualiza.Observaciones;
                item.Pagado = actualiza.Pagado;
                item.FechaPago = actualiza.FechaPago;

                _contexto.Registro.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó el registro: " + actualiza.Id + ". Nombre anterior: " + oldName + ". Nombre actual: " + actualiza.Descripcion);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar el registro: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int Id)
        {
            var item = (from h in _contexto.Registro where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            _contexto.Registro.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó el registro: " + Id + ", " + item.Descripcion);
            return Ok(Id);
        }

    }
}
