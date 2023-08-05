using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;
using Application.Interfaces.MayiBeerCollection.ICommands;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Application.Interfaces.MayiBeerCollection.IServices;
using AutoMapper;
using Domain.Models.MayiBeerCollection;
using Microsoft.Extensions.Logging;

namespace Application.Services.MayiBeerCollection
{
    public class CervezaService: ICervezaService
    {
        private readonly ICervezaQuery _cervezaQuery;
        private readonly ICervezaCommand _cervezaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<CervezaService> _logger;

        public CervezaService(ICervezaQuery cervezaQuery, ICervezaCommand cervezaCommand, IMapper mapper, ILogger<CervezaService> logger)
        {
            _cervezaQuery = cervezaQuery;
            _cervezaCommand = cervezaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            CervezaResponse cervezaResponse = new CervezaResponse();
            try
            {
                var cerveza = await _cervezaQuery.GetById(id, false);

                if (cerveza == null)
                {
                    response.statusCode = 404;
                    response.message = "La cerveza seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _cervezaCommand.Delete(cerveza);
                cervezaResponse = _mapper.Map<CervezaResponse>(cerveza);

                _logger.LogInformation("Se eliminó la cerveza: " + id + ", " + cerveza.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Cerveza eliminada exitosamente";
            response.response = cervezaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll(bool fullresponse)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Cerveza> lista = await _cervezaQuery.GetAll(fullresponse);
                List<CervezaResponse> listaDTO = _mapper.Map<List<CervezaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdCerveza, bool fullresponse)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Cerveza cerveza = await _cervezaQuery.GetById(IdCerveza, fullresponse);

                if (cerveza == null)
                {
                    response.statusCode = 404;
                    response.message = "La cerveza seleccionada no existe";
                    response.response = null;
                    return response;
                }

                CervezaResponse CervezaResponse = _mapper.Map<CervezaResponse>(cerveza);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = CervezaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(CervezaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CervezaResponse cervezaResponse = new CervezaResponse();
            try
            {
                Cerveza cerveza = _mapper.Map<Cerveza>(entity);
                cerveza = await _cervezaCommand.Insert(cerveza);
                cervezaResponse = _mapper.Map<CervezaResponse>(cerveza);

                _logger.LogInformation("Se insertó una nueva cerveza: " + cerveza.Id + ". Nombre: " + cerveza.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Cerveza insertada exitosamente";
            response.response = cervezaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(CervezaRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            CervezaResponse cervezaResponse = new CervezaResponse();
            try
            {
                var cerveza = await _cervezaQuery.GetById(id, false);

                if (cerveza == null)
                {
                    response.statusCode = 404;
                    response.message = "La cerveza seleccionada no existe";
                    response.response = null;
                    return response;
                }

                cerveza.Nombre = entity.Nombre;
                cerveza.Imagen = entity.Imagen;

                await _cervezaCommand.Update(cerveza);
                cervezaResponse = _mapper.Map<CervezaResponse>(cerveza);

                _logger.LogInformation("Se actualizó la cerveza: " + cerveza.Id + ". Nombre anterior: " + cerveza.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Cerveza actualizada exitosamente";
            response.response = cervezaResponse;
            return response;
        }
    }
}
