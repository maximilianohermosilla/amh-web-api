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
    public class CaratulaService : ICaratulaService
    {
        private readonly ICaratulaQuery _caratulaQuery;
        private readonly ICaratulaCommand _caratulaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<CaratulaService> _logger;

        public CaratulaService(ICaratulaQuery caratulaQuery, ICaratulaCommand caratulaCommand, IMapper mapper, ILogger<CaratulaService> logger, ICervezaQuery cervezaQuery)
        {
            _caratulaQuery = caratulaQuery;
            _caratulaCommand = caratulaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            CaratulaResponse caratulaResponse = new CaratulaResponse();
            try
            {
                var caratula = await _caratulaQuery.GetById(id);

                if (caratula == null)
                {
                    response.statusCode = 404;
                    response.message = "La caratula seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _caratulaCommand.Delete(caratula);
                caratulaResponse = _mapper.Map<CaratulaResponse>(caratula);

                _logger.LogInformation("Se eliminó la caratula: " + id + ", " + caratula.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Caratula eliminada exitosamente";
            response.response = caratulaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Caratula> lista = await _caratulaQuery.GetAll();
                List<CaratulaResponse> listaDTO = _mapper.Map<List<CaratulaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdCaratula)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Caratula caratula = await _caratulaQuery.GetById(IdCaratula);

                if (caratula == null)
                {
                    response.statusCode = 404;
                    response.message = "La caratula seleccionada no existe";
                    response.response = null;
                    return response;
                }

                CaratulaResponse CaratulaResponse = _mapper.Map<CaratulaResponse>(caratula);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = CaratulaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(CaratulaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CaratulaResponse caratulaResponse = new CaratulaResponse();
            try
            {
                Caratula caratula = _mapper.Map<Caratula>(entity);
                caratula = await _caratulaCommand.Insert(caratula);
                caratulaResponse = _mapper.Map<CaratulaResponse>(caratula);

                _logger.LogInformation("Se insertó una nueva caratula: " + caratula.Id + ". Nombre: " + caratula.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Caratula insertada exitosamente";
            response.response = caratulaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(CaratulaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CaratulaResponse caratulaResponse = new CaratulaResponse();
            try
            {
                var caratula = await _caratulaQuery.GetById(entity.Id);

                if (caratula == null)
                {
                    response.statusCode = 404;
                    response.message = "La caratula seleccionada no existe";
                    response.response = null;
                    return response;
                }

                caratula = _mapper.Map<CaratulaRequest, Caratula>(entity, caratula);

                await _caratulaCommand.Update(caratula);
                caratulaResponse = _mapper.Map<CaratulaResponse>(caratula);

                _logger.LogInformation("Se actualizó la caratula: " + caratula.Id + ". Nombre anterior: " + caratula.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Caratula actualizada exitosamente";
            response.response = caratulaResponse;
            return response;
        }
    }
}