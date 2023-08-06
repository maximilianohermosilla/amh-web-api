using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.GestorExpedientes;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorExpedientes
{
    public class SituacionRevistaService : ISituacionRevistaService
    {
        private readonly ISituacionRevistaQuery _situacionRevistaQuery;
        private readonly ISituacionRevistaCommand _situacionRevistaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<SituacionRevistaService> _logger;

        public SituacionRevistaService(ISituacionRevistaQuery situacionRevistaQuery, ISituacionRevistaCommand situacionRevistaCommand, IMapper mapper, ILogger<SituacionRevistaService> logger, ICervezaQuery cervezaQuery)
        {
            _situacionRevistaQuery = situacionRevistaQuery;
            _situacionRevistaCommand = situacionRevistaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            SituacionRevistaResponse situacionRevistaResponse = new SituacionRevistaResponse();
            try
            {
                var situacionRevista = await _situacionRevistaQuery.GetById(id);

                if (situacionRevista == null)
                {
                    response.statusCode = 404;
                    response.message = "La situacion revista seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _situacionRevistaCommand.Delete(situacionRevista);
                situacionRevistaResponse = _mapper.Map<SituacionRevistaResponse>(situacionRevista);

                _logger.LogInformation("Se eliminó la situacion revista: " + id + ", " + situacionRevista.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Situacion Revista eliminada exitosamente";
            response.response = situacionRevistaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<SituacionRevista> lista = await _situacionRevistaQuery.GetAll();
                List<SituacionRevistaResponse> listaDTO = _mapper.Map<List<SituacionRevistaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdSituacionRevista)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                SituacionRevista situacionRevista = await _situacionRevistaQuery.GetById(IdSituacionRevista);

                if (situacionRevista == null)
                {
                    response.statusCode = 404;
                    response.message = "La situacion revista seleccionada no existe";
                    response.response = null;
                    return response;
                }

                SituacionRevistaResponse SituacionRevistaResponse = _mapper.Map<SituacionRevistaResponse>(situacionRevista);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = SituacionRevistaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(SituacionRevistaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            SituacionRevistaResponse situacionRevistaResponse = new SituacionRevistaResponse();
            try
            {
                SituacionRevista situacionRevista = _mapper.Map<SituacionRevista>(entity);
                situacionRevista = await _situacionRevistaCommand.Insert(situacionRevista);
                situacionRevistaResponse = _mapper.Map<SituacionRevistaResponse>(situacionRevista);

                _logger.LogInformation("Se insertó una nueva situacion revista: " + situacionRevista.Id + ". Nombre: " + situacionRevista.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Situacion Revista insertada exitosamente";
            response.response = situacionRevistaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(SituacionRevistaRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            SituacionRevistaResponse situacionRevistaResponse = new SituacionRevistaResponse();
            try
            {
                var situacionRevista = await _situacionRevistaQuery.GetById(id);

                if (situacionRevista == null)
                {
                    response.statusCode = 404;
                    response.message = "La situacion revista seleccionada no existe";
                    response.response = null;
                    return response;
                }

                situacionRevista.Nombre = entity.Nombre;

                await _situacionRevistaCommand.Update(situacionRevista);
                situacionRevistaResponse = _mapper.Map<SituacionRevistaResponse>(situacionRevista);

                _logger.LogInformation("Se actualizó la situacion revista: " + situacionRevista.Id + ". Nombre anterior: " + situacionRevista.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Situacion Revista actualizada exitosamente";
            response.response = situacionRevistaResponse;
            return response;
        }
    }
}