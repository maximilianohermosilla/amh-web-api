using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;

namespace Application.Services.GestorGastos
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroQuery _registroQuery;
        private readonly IRegistroCommand _registroCommand;

        public RegistroService(IRegistroQuery registroQuery, IRegistroCommand registroCommand)
        {
            _registroQuery = registroQuery;
            _registroCommand = registroCommand;
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

        public Task<ResponseModel> Insert(RegistroRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(RegistroRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
