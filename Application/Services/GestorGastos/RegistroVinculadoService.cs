using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;

namespace Application.Services.GestorGastos
{
    public class RegistroVinculadoService : IRegistroVinculadoService
    {
        private readonly IRegistroVinculadoQuery _registroVinculadoQuery;
        private readonly IRegistroVinculadoCommand _registroVinculadoCommand;

        public RegistroVinculadoService(IRegistroVinculadoQuery registroVinculadoQuery, IRegistroVinculadoCommand registroVinculadoCommand)
        {
            _registroVinculadoQuery = registroVinculadoQuery;
            _registroVinculadoCommand = registroVinculadoCommand;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(RegistroVinculadoRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(RegistroVinculadoRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
