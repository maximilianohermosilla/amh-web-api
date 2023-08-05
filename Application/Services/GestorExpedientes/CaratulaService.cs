using amh_web_api.DTO;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;
using Domain.Models.GestorExpedientes;

namespace Application.Services.GestorExpedientes
{
    public class CaratulaService : ICaratulaService
    {
        private readonly ICaratulaQuery _caratulaQuery;
        private readonly ICaratulaCommand _caratulaCommand;

        public CaratulaService(ICaratulaQuery caratulaQuery, ICaratulaCommand caratulaCommand)
        {
            _caratulaQuery = caratulaQuery;
            _caratulaCommand = caratulaCommand;
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

        public Task<ResponseModel> Insert(Caratula entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(Caratula entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
