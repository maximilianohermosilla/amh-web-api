using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorGastos
{
    public class SuscripcionService : ISuscripcionService
    {
        private readonly ISuscripcionQuery _suscripcionQuery;
        private readonly ISuscripcionCommand _suscripcionCommand;
        private readonly IRegistroCommand _registroCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<SuscripcionService> _logger;

        public SuscripcionService(ISuscripcionQuery suscripcionQuery, ISuscripcionCommand suscripcionCommand, IMapper mapper, ILogger<SuscripcionService> logger, ICervezaQuery cervezaQuery, IRegistroCommand registroCommand)
        {
            _suscripcionQuery = suscripcionQuery;
            _suscripcionCommand = suscripcionCommand;
            _mapper = mapper;
            _logger = logger;
            _registroCommand = registroCommand;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            SuscripcionResponse suscripcionResponse = new SuscripcionResponse();
            try
            {
                var suscripcion = await _suscripcionQuery.GetById(id);

                if (suscripcion == null)
                {
                    response.statusCode = 404;
                    response.message = "La suscripcion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _suscripcionCommand.Delete(suscripcion);
                suscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                _logger.LogInformation("Se eliminó la suscripcion: " + id + ", " + suscripcion.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Suscripcion eliminada exitosamente";
            response.response = suscripcionResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll(int idUsuario, string? periodo)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Suscripcion> lista = await _suscripcionQuery.GetAll(idUsuario, periodo);
                List<SuscripcionFullResponse> listaDTO = _mapper.Map<List<SuscripcionFullResponse>>(lista);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listaDTO;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }


        public async Task<ResponseModel> GetById(int? IdSuscripcion)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Suscripcion suscripcion = await _suscripcionQuery.GetById(IdSuscripcion);

                if (suscripcion == null)
                {
                    response.statusCode = 404;
                    response.message = "La suscripcion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                SuscripcionFullResponse SuscripcionResponse = _mapper.Map<SuscripcionFullResponse>(suscripcion);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = SuscripcionResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(SuscripcionRequest entity)
        {
            ResponseModel response = new ResponseModel();
            SuscripcionResponse suscripcionResponse = new SuscripcionResponse();
            try
            {
                Suscripcion suscripcion = _mapper.Map<Suscripcion>(entity);
                suscripcion = await _suscripcionCommand.Insert(suscripcion);
                suscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                DateTime fecha = entity.FechaDesde;

                while (fecha <= entity.FechaHasta)
                {
                    Registro registro = new Registro();
                    registro.Descripcion = $"{entity.Nombre}";
                    registro.IdSuscripcion = suscripcion.Id;
                    registro.IdEmpresa = entity.IdEmpresa > 0 ? entity.IdEmpresa : null;
                    registro.IdCuenta = entity.IdCuenta;
                    registro.IdRegistroVinculado = null;
                    registro.NumeroCuota = null;
                    registro.Fecha = fecha;
                    registro.Valor = entity.ValorActual;
                    registro.IdUsuario = entity.IdUsuario;
                    registro.Observaciones = "";
                    registro.Pagado = false;
                    registro.FechaPago = null;
                    registro.IdCategoriaGasto = entity.IdCategoriaGasto > 0 ? entity.IdCategoriaGasto : null;
                    registro.Periodo = fecha.ToString("yyyy-MM-dd").Substring(0, 7);

                    await _registroCommand.Insert(registro);

                    fecha = fecha.AddMonths(1);
                }     

                _logger.LogInformation("Se insertó una nueva suscripcion: " + suscripcion.Id + ". Nombre: " + suscripcion.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Suscripcion insertada exitosamente";
            response.response = suscripcionResponse;
            return response;
        }


        public async Task<ResponseModel> Update(SuscripcionRequest entity)
        {
            ResponseModel response = new ResponseModel();
            SuscripcionResponse suscripcionResponse = new SuscripcionResponse();
            try
            {
                var suscripcion = await _suscripcionQuery.GetById(entity.Id);

                if (suscripcion == null)
                {
                    response.statusCode = 404;
                    response.message = "La suscripcion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                suscripcion = _mapper.Map<SuscripcionRequest, Suscripcion>(entity, suscripcion);

                await _suscripcionCommand.Update(suscripcion);
                suscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                _logger.LogInformation("Se actualizó la suscripcion: " + suscripcion.Id + ". Nombre anterior: " + suscripcion.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Suscripcion actualizada exitosamente";
            response.response = suscripcionResponse;
            return response;
        }
    }
}