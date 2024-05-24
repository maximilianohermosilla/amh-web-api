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
    public class TipoCuentaService: ITipoCuentaService
    {
        private readonly ITipoCuentaQuery _tipoCuentaQuery;
        private readonly ITipoCuentaCommand _tipoCuentaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<TipoCuentaService> _logger;

        public TipoCuentaService(ITipoCuentaQuery tipoCuentaQuery, ITipoCuentaCommand tipoCuentaCommand, IMapper mapper, ILogger<TipoCuentaService> logger, ICervezaQuery cervezaQuery)
        {
            _tipoCuentaQuery = tipoCuentaQuery;
            _tipoCuentaCommand = tipoCuentaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            TipoCuentaResponse tipoCuentaResponse = new TipoCuentaResponse();
            try
            {
                var tipoCuenta = await _tipoCuentaQuery.GetById(id);

                if (tipoCuenta == null)
                {
                    response.statusCode = 404;
                    response.message = "El tipo de cuenta seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _tipoCuentaCommand.Delete(tipoCuenta);
                tipoCuentaResponse = _mapper.Map<TipoCuentaResponse>(tipoCuenta);

                _logger.LogInformation("Se eliminó el tipo de cuenta: " + id + ", " + tipoCuenta.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Tipo de cuenta eliminado exitosamente";
            response.response = tipoCuentaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<TipoCuenta> lista = await _tipoCuentaQuery.GetAll();
                List<TipoCuentaResponse> listaDTO = _mapper.Map<List<TipoCuentaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdTipoCuenta)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TipoCuenta tipoCuenta = await _tipoCuentaQuery.GetById(IdTipoCuenta);

                if (tipoCuenta == null)
                {
                    response.statusCode = 404;
                    response.message = "El tipo de cuenta seleccionado no existe";
                    response.response = null;
                    return response;
                }

                TipoCuentaResponse TipoCuentaResponse = _mapper.Map<TipoCuentaResponse>(tipoCuenta);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = TipoCuentaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(TipoCuentaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            TipoCuentaResponse tipoCuentaResponse = new TipoCuentaResponse();
            try
            {
                TipoCuenta tipoCuenta = _mapper.Map<TipoCuenta>(entity);
                tipoCuenta = await _tipoCuentaCommand.Insert(tipoCuenta);
                tipoCuentaResponse = _mapper.Map<TipoCuentaResponse>(tipoCuenta);

                _logger.LogInformation("Se insertó un nuevo tipo de cuenta: " + tipoCuenta.Id + ". Nombre: " + tipoCuenta.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Tipo de cuenta insertado exitosamente";
            response.response = tipoCuentaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(TipoCuentaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            TipoCuentaResponse tipoCuentaResponse = new TipoCuentaResponse();
            try
            {
                var tipoCuenta = await _tipoCuentaQuery.GetById(entity.Id);

                if (tipoCuenta == null)
                {
                    response.statusCode = 404;
                    response.message = "El tipo de cuenta seleccionado no existe";
                    response.response = null;
                    return response;
                }

                tipoCuenta.Nombre = entity.Nombre;

                await _tipoCuentaCommand.Update(tipoCuenta);
                tipoCuentaResponse = _mapper.Map<TipoCuentaResponse>(tipoCuenta);

                _logger.LogInformation("Se actualizó el tipo de cuenta: " + tipoCuenta.Id + ". Nombre anterior: " + tipoCuenta.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Tipo de cuenta actualizado exitosamente";
            response.response = tipoCuentaResponse;
            return response;
        }
    }
}