using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace Application.Services.GestorGastos
{
    public class RegistroVinculadoService : IRegistroVinculadoService
    {
        private readonly IRegistroVinculadoQuery _registroVinculadoQuery;
        private readonly IRegistroVinculadoCommand _registroVinculadoCommand;
        private readonly IRegistroCommand _registroCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroVinculadoService> _logger;

        public RegistroVinculadoService(IRegistroVinculadoQuery registroVinculadoQuery, IRegistroVinculadoCommand registroVinculadoCommand, IMapper mapper, ILogger<RegistroVinculadoService> logger, ICervezaQuery cervezaQuery, IRegistroCommand registroCommand)
        {
            _registroVinculadoQuery = registroVinculadoQuery;
            _registroVinculadoCommand = registroVinculadoCommand;
            _registroCommand = registroCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            RegistroVinculadoResponse registroVinculadoResponse = new RegistroVinculadoResponse();
            try
            {
                var registroVinculado = await _registroVinculadoQuery.GetById(id);

                if (registroVinculado == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro vinculado seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _registroVinculadoCommand.Delete(registroVinculado);
                registroVinculadoResponse = _mapper.Map<RegistroVinculadoResponse>(registroVinculado);

                _logger.LogInformation("Se eliminó el registro vinculado: " + id + ", " + registroVinculado.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Registro vinculado eliminado exitosamente";
            response.response = registroVinculadoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll(int idUsuario, string? periodo)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<RegistroVinculado> lista = await _registroVinculadoQuery.GetAll(idUsuario, periodo);
                List<RegistroVinculadoFullResponse> listaDTO = _mapper.Map<List<RegistroVinculadoFullResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdRegistroVinculado)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                RegistroVinculado registroVinculado = await _registroVinculadoQuery.GetById(IdRegistroVinculado);

                if (registroVinculado == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro vinculado seleccionado no existe";
                    response.response = null;
                    return response;
                }

                RegistroVinculadoFullResponse RegistroVinculadoResponse = _mapper.Map<RegistroVinculadoFullResponse>(registroVinculado);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = RegistroVinculadoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(RegistroVinculadoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            RegistroVinculadoResponse registroVinculadoResponse = new RegistroVinculadoResponse();
            try
            {
                RegistroVinculado registroVinculado = _mapper.Map<RegistroVinculado>(entity);
                registroVinculado = await _registroVinculadoCommand.Insert(registroVinculado);
                registroVinculadoResponse = _mapper.Map<RegistroVinculadoResponse>(registroVinculado);

                for (int i = 1; i <= registroVinculado.Cuotas; i++)
                {                    
                    Registro registro = new Registro();
                    registro.Descripcion = $"{entity.Descripcion} - Cuota {i}/{entity.Cuotas}";
                    registro.IdSuscripcion = null;
                    registro.IdEmpresa = entity.IdEmpresa > 0? entity.IdEmpresa: null;
                    registro.IdCuenta = entity.IdCuenta;
                    registro.IdRegistroVinculado = registroVinculado.Id;
                    registro.NumeroCuota = i;
                    registro.Fecha = entity.Fecha.AddMonths(i - 1);
                    registro.Valor = entity.ValorFinal / entity.Cuotas;
                    registro.IdUsuario = entity.IdUsuario;
                    registro.Observaciones = "";
                    registro.Pagado = false;
                    registro.FechaPago = null;
                    registro.IdCategoriaGasto = entity.IdCategoriaGasto > 0 ? entity.IdCategoriaGasto : null;
                    registro.Periodo = entity.Fecha.AddMonths(i - 1).ToString("yyyy-MM-dd").Substring(0, 7);

                    await _registroCommand.Insert(registro);
                }

                _logger.LogInformation("Se insertó un nuevo registro vinculado: " + registroVinculado.Id + ". Descripcion: " + registroVinculado.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Registro vinculado insertado exitosamente";
            response.response = registroVinculadoResponse;
            return response;
        }


        public async Task<ResponseModel> Update(RegistroVinculadoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            RegistroVinculadoResponse registroVinculadoResponse = new RegistroVinculadoResponse();
            try
            {
                var registroVinculado = await _registroVinculadoQuery.GetById(entity.Id);

                if (registroVinculado == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro vinculado seleccionado no existe";
                    response.response = null;
                    return response;
                }
                                
                registroVinculado = _mapper.Map<RegistroVinculadoRequest, RegistroVinculado>(entity, registroVinculado);

                await _registroVinculadoCommand.Update(registroVinculado);
                registroVinculadoResponse = _mapper.Map<RegistroVinculadoResponse>(registroVinculado);

                _logger.LogInformation("Se actualizó el registro vinculado: " + registroVinculado.Id + ". Descripcion anterior: " + registroVinculado.Descripcion + ". Descripcion actual: " + entity.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Registro vinculado actualizado exitosamente";
            response.response = registroVinculadoResponse;
            return response;
        }
    }
}