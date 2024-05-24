using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorGastos
{
    public class CategoriaIngresoService : ICategoriaIngresoService
    {
        private readonly ICategoriaIngresoQuery _CategoriaIngresoQuery;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriaIngresoService> _logger;

        public CategoriaIngresoService(ICategoriaIngresoQuery CategoriaIngresoQuery, IMapper mapper, ILogger<CategoriaIngresoService> logger)
        {
            _CategoriaIngresoQuery = CategoriaIngresoQuery;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<CategoriaIngreso> lista = await _CategoriaIngresoQuery.GetAll();
                List<CategoriaIngresoResponse> listaDTO = _mapper.Map<List<CategoriaIngresoResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdCategoriaIngreso)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                CategoriaIngreso CategoriaIngreso = await _CategoriaIngresoQuery.GetById(IdCategoriaIngreso);

                if (CategoriaIngreso == null)
                {
                    response.statusCode = 404;
                    response.message = "La Categoria seleccionada no existe";
                    response.response = null;
                    return response;
                }

                CategoriaIngresoResponse CategoriaIngresoResponse = _mapper.Map<CategoriaIngresoResponse>(CategoriaIngreso);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = CategoriaIngresoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }
    }
}
