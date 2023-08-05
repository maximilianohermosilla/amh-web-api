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
    public class TarjetaController : ControllerBase
    {
        private AmhWebDbContext _contexto;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<TarjetaController> _logger;

        public TarjetaController(AmhWebDbContext context, IConfiguration configuration, IMapper mapper, ILogger<TarjetaController> logger)
        {
            _contexto = context;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("listar/")]
        public ActionResult<IEnumerable<Tarjeta>> Tarjetas()
        {
            var lst = (from tbl in _contexto.Tarjeta where tbl.Id > 0 select tbl).ToList();
            List<TarjetaDTO> tarjetasDTO = _mapper.Map<List<TarjetaDTO>>(lst);

            foreach (var item in tarjetasDTO)
            {
                var banco = (from h in _contexto.Banco where h.Id == item.IdBanco select h).FirstOrDefault();
                if (banco != null)
                {
                    item.BancoNombre = banco.Nombre;
                }

                var tipoTarjeta = (from h in _contexto.TipoTarjeta where h.Id == item.IdTipoTarjeta select h).FirstOrDefault();
                if (tipoTarjeta != null)
                {
                    item.TipoTarjetaNombre = tipoTarjeta.Nombre;
                }

                var usuario = (from h in _contexto.Usuario where h.Id == item.IdUsuario select h).FirstOrDefault();
                if (usuario != null)
                {
                    item.UsuarioNombre = usuario.Nombre;
                }
            }

            return Ok(tarjetasDTO);
        }


        [HttpGet("buscar/{Id}")]
        public ActionResult<Tarjeta> Tarjeta(int Id)
        {
            var tarjeta = (from tbl in _contexto.Tarjeta where tbl.Id == Id select tbl).FirstOrDefault();
            TarjetaDTO item = _mapper.Map<TarjetaDTO>(tarjeta);
            if (item == null)
            {
                return NotFound(Id);
            }

            var banco = (from h in _contexto.Banco where h.Id == item.IdBanco select h).FirstOrDefault();
            if (banco != null)
            {
                item.BancoNombre = banco.Nombre;
            }

            var tipoTarjeta = (from h in _contexto.TipoTarjeta where h.Id == item.IdTipoTarjeta select h).FirstOrDefault();
            if (tipoTarjeta != null)
            {
                item.TipoTarjetaNombre = tipoTarjeta.Nombre;
            }

            var usuario = (from h in _contexto.Usuario where h.Id == item.IdUsuario select h).FirstOrDefault();
            if (usuario != null)
            {
                item.UsuarioNombre = usuario.Nombre;
            }

            _logger.LogWarning("Búsqueda de tarjeta Id: " + Id + ". Resultados: " + item.Numero);
            return Ok(item);
        }

        [HttpPost("nuevo")]
        [Authorize(Roles = "Administrador")]
        public ActionResult nuevo(TarjetaDTO nuevo)
        {
            try
            {
                Tarjeta tarjeta = _mapper.Map<Tarjeta>(nuevo);
                _contexto.Tarjeta.Add(tarjeta);
                _contexto.SaveChanges();

                nuevo.Id = nuevo.Id;

                _logger.LogWarning("Se insertó una nueva tarjeta: " + nuevo.Id + ". Nombre: " + nuevo.Numero);
                return Ok(nuevo);

            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al insertar la tarjeta: " + nuevo.Numero + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Administrador")]
        public ActionResult actualizar(Tarjeta actualiza)
        {
            string oldName = "";
            try
            {
                var item = (from h in _contexto.Tarjeta where h.Id == actualiza.Id select h).FirstOrDefault();

                if (item == null)
                {
                    return NotFound(actualiza);
                }
                oldName = item.Numero;
                item.Numero = actualiza.Numero;
                item.Vencimiento = actualiza.Vencimiento;
                item.IdBanco = actualiza.IdBanco;
                item.IdTipoTarjeta = actualiza.IdTipoTarjeta;
                item.IdUsuario = actualiza.IdUsuario;
                item.Habilitado = actualiza.Habilitado;

                _contexto.Tarjeta.Update(item);
                _contexto.SaveChanges();
                _logger.LogWarning("Se actualizó la tarjeta: " + actualiza.Id + ". Numero anterior: " + oldName + ". Numero actual: " + actualiza.Numero);
                return Ok(actualiza);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al actualizar la tarjeta: " + oldName + ". Detalle: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult eliminar(int Id)
        {
            var item = (from h in _contexto.Tarjeta where h.Id == Id select h).FirstOrDefault();

            if (item == null)
            {
                return NotFound(Id);
            }

            List<Cuenta> lista = (from tbl in _contexto.Cuenta where tbl.IdTarjeta == Id select tbl).ToList();
            if (lista.Count() > 0)
            {
                return BadRequest("No se puede eliminar la tarjeta porque tiene una o más cuentas asociadas");
            }


            _contexto.Tarjeta.Remove(item);
            _contexto.SaveChanges();
            _logger.LogWarning("Se eliminó la tarjeta: " + Id + ", " + item.Numero);
            return Ok(Id);
        }

    }
}
