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
    public class SuscripcionService : ISuscripcionService
    {
        private readonly ISuscripcionQuery _suscripcionQuery;
        private readonly IRegistroQuery _registroQuery;
        private readonly ISuscripcionCommand _suscripcionCommand;
        private readonly IRegistroCommand _registroCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<SuscripcionService> _logger;

        public SuscripcionService(ISuscripcionQuery suscripcionQuery, ISuscripcionCommand suscripcionCommand, IMapper mapper, ILogger<SuscripcionService> logger, ICervezaQuery cervezaQuery, IRegistroCommand registroCommand, IRegistroQuery registroQuery)
        {
            _suscripcionQuery = suscripcionQuery;
            _registroQuery = registroQuery;
            _suscripcionCommand = suscripcionCommand;
            _registroCommand = registroCommand;
            _mapper = mapper;
            _logger = logger;
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

                DateTime fecha = entity.ProximoMes? entity.FechaDesde.AddMonths(1) : entity.FechaDesde;
                DateTime fechaHasta = entity.ProximoMes ? entity.FechaHasta.AddMonths(1) : entity.FechaHasta;

                while (fecha <= fechaHasta)
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
                var fechaDesdeActual = suscripcion.FechaDesde;
                var fechaHastaActual = suscripcion.FechaHasta;

                if (suscripcion == null)
                {
                    response.statusCode = 404;
                    response.message = "La suscripcion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                if (fechaDesdeActual < entity.FechaDesde)
                {
                    entity.FechaDesde = fechaDesdeActual;
                }

                suscripcion = _mapper.Map<SuscripcionRequest, Suscripcion>(entity, suscripcion);

                await _suscripcionCommand.Update(suscripcion);
                suscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                //Actualizar registros
                if(entity.FechaUpdate != null)
                {
                    //Modifico registros desde la FechaUpdate en adelante
                    var listaRegistrosActualizar = await _registroQuery.GetAllBySuscripcionAndDate(entity.IdUsuario, entity.Id, entity.FechaUpdate);

                    if (listaRegistrosActualizar.Any())
                    {
                        foreach (var item in listaRegistrosActualizar)
                        {
                            item.Descripcion = entity.Nombre;
                            item.IdEmpresa = entity.IdEmpresa;
                            item.IdCuenta = entity.IdCuenta;
                            item.Valor = entity.ValorActual;
                            item.IdCategoriaGasto = entity.IdCategoriaGasto;
                        }

                        await _registroCommand.UpdateMany(listaRegistrosActualizar);
                    }

                    //FechaHasta superior a FechaHastaActual -> Agrego registros
                    if (entity.FechaHasta > fechaHastaActual)
                    {
                        while (fechaHastaActual < entity.FechaHasta)
                        {
                            fechaHastaActual = fechaHastaActual?.AddMonths(1);

                            Registro registro = new Registro();
                            registro.Descripcion = $"{entity.Nombre}";
                            registro.IdSuscripcion = suscripcion.Id;
                            registro.IdEmpresa = entity.IdEmpresa > 0 ? entity.IdEmpresa : null;
                            registro.IdCuenta = entity.IdCuenta;
                            registro.IdRegistroVinculado = null;
                            registro.NumeroCuota = null;
                            registro.Fecha = (DateTime)(fechaHastaActual == null ? DateTime.Now : fechaHastaActual);
                            registro.Valor = entity.ValorActual;
                            registro.IdUsuario = entity.IdUsuario;
                            registro.Observaciones = "";
                            registro.Pagado = false;
                            registro.FechaPago = null;
                            registro.IdCategoriaGasto = entity.IdCategoriaGasto > 0 ? entity.IdCategoriaGasto : null;
                            registro.Periodo = fechaHastaActual?.ToString("yyyy-MM-dd").Substring(0, 7);

                            await _registroCommand.Insert(registro);
                        }
                    }
                    else
                    {
                        //Elimino registros desde la nueva FechaHasta en adelante
                        var listaRegistrosEliminar = await _registroQuery.GetAllBySuscripcionAndDate(entity.IdUsuario, entity.Id, entity.FechaHasta);

                        await _registroCommand.DeleteMany(listaRegistrosEliminar);
                    }
                }                

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