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
    public class IngresoService: IIngresoService
    {
        private readonly IIngresoQuery _IngresoQuery;
        private readonly IIngresoCommand _IngresoCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<IngresoService> _logger;

        public IngresoService(IIngresoQuery IngresoQuery, IIngresoCommand IngresoCommand, IMapper mapper, ILogger<IngresoService> logger, ICervezaQuery cervezaQuery)
        {
            _IngresoQuery = IngresoQuery;
            _IngresoCommand = IngresoCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            IngresoResponse IngresoResponse = new IngresoResponse();
            try
            {
                var Ingreso = await _IngresoQuery.GetById(id);

                if (Ingreso == null)
                {
                    response.statusCode = 404;
                    response.message = "El Ingreso seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _IngresoCommand.Delete(Ingreso);
                IngresoResponse = _mapper.Map<IngresoResponse>(Ingreso);

                _logger.LogInformation("Se eliminó el Ingreso: " + id + ", " + Ingreso.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Ingreso eliminado exitosamente";
            response.response = IngresoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll(int idUsuario, string? periodo, int? categoria)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Ingreso> lista = await _IngresoQuery.GetAll(idUsuario, periodo, categoria);
                List<IngresoResponse> listaDTO = _mapper.Map<List<IngresoResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdIngreso)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Ingreso Ingreso = await _IngresoQuery.GetById(IdIngreso);

                if (Ingreso == null)
                {
                    response.statusCode = 404;
                    response.message = "El Ingreso seleccionado no existe";
                    response.response = null;
                    return response;
                }

                IngresoResponse IngresoResponse = _mapper.Map<IngresoResponse>(Ingreso);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = IngresoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(IngresoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            IngresoResponse IngresoResponse = new IngresoResponse();
            try
            {
                Ingreso Ingreso = _mapper.Map<Ingreso>(entity);
                Ingreso = await _IngresoCommand.Insert(Ingreso);
                IngresoResponse = _mapper.Map<IngresoResponse>(Ingreso);

                _logger.LogInformation("Se insertó un nuevo Ingreso: " + Ingreso.Id + ". Nombre: " + Ingreso.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Ingreso insertado exitosamente";
            response.response = IngresoResponse;
            return response;
        }


        public async Task<ResponseModel> Update(IngresoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            IngresoResponse IngresoResponse = new IngresoResponse();
            try
            {
                var Ingreso = await _IngresoQuery.GetById(entity.Id);

                if (Ingreso == null)
                {
                    response.statusCode = 404;
                    response.message = "El Ingreso seleccionado no existe";
                    response.response = null;
                    return response;
                }
     
                Ingreso = _mapper.Map<IngresoRequest, Ingreso>(entity, Ingreso);

                await _IngresoCommand.Update(Ingreso);
                IngresoResponse = _mapper.Map<IngresoResponse>(Ingreso);

                _logger.LogInformation("Se actualizó el Ingreso: " + Ingreso.Id + ". Nombre anterior: " + Ingreso.Descripcion + ". Nombre actual: " + entity.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Ingreso actualizado exitosamente";
            response.response = IngresoResponse;
            return response;
        }
    }
}
