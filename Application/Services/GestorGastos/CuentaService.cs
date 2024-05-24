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
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaQuery _cuentaQuery;
        private readonly ICuentaCommand _cuentaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<CuentaService> _logger;

        public CuentaService(ICuentaQuery cuentaQuery, ICuentaCommand cuentaCommand, IMapper mapper, ILogger<CuentaService> logger, ICervezaQuery cervezaQuery)
        {
            _cuentaQuery = cuentaQuery;
            _cuentaCommand = cuentaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            CuentaResponse cuentaResponse = new CuentaResponse();
            try
            {
                var cuenta = await _cuentaQuery.GetById(id);

                if (cuenta == null)
                {
                    response.statusCode = 404;
                    response.message = "La cuenta seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _cuentaCommand.Delete(cuenta);
                cuentaResponse = _mapper.Map<CuentaResponse>(cuenta);

                _logger.LogInformation("Se eliminó la cuenta: " + id + ", " + cuenta.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Cuenta eliminada exitosamente";
            response.response = cuentaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll(int idUsuario)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Cuenta> lista = await _cuentaQuery.GetAll(idUsuario);
                List<CuentaResponse> listaDTO = _mapper.Map<List<CuentaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdCuenta)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Cuenta cuenta = await _cuentaQuery.GetById(IdCuenta);

                if (cuenta == null)
                {
                    response.statusCode = 404;
                    response.message = "La cuenta seleccionada no existe";
                    response.response = null;
                    return response;
                }

                CuentaResponse CuentaResponse = _mapper.Map<CuentaResponse>(cuenta);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = CuentaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(CuentaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CuentaResponse cuentaResponse = new CuentaResponse();
            try
            {
                entity.IdTarjeta = entity.IdTarjeta == 0 ? null : entity.IdTarjeta;
                Cuenta cuenta = _mapper.Map<Cuenta>(entity);
                cuenta = await _cuentaCommand.Insert(cuenta);
                cuentaResponse = _mapper.Map<CuentaResponse>(cuenta);

                _logger.LogInformation("Se insertó una nueva cuenta: " + cuenta.Id + ". Nombre: " + cuenta.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Cuenta insertada exitosamente";
            response.response = cuentaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(CuentaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CuentaResponse cuentaResponse = new CuentaResponse();
            try
            {
                var cuenta = await _cuentaQuery.GetById(entity.Id);

                if (cuenta == null)
                {
                    response.statusCode = 404;
                    response.message = "La cuenta seleccionada no existe";
                    response.response = null;
                    return response;
                }
                                
                cuenta = _mapper.Map<CuentaRequest, Cuenta>(entity, cuenta);

                await _cuentaCommand.Update(cuenta);
                cuentaResponse = _mapper.Map<CuentaResponse>(cuenta);

                _logger.LogInformation("Se actualizó la cuenta: " + cuenta.Id + ". Nombre anterior: " + cuenta.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Cuenta actualizada exitosamente";
            response.response = cuentaResponse;
            return response;
        }
    }
}