using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface IRegistroAhorroCommand
    {
        Task<RegistroAhorro> Insert(RegistroAhorro entity);
        Task<List<RegistroAhorro>> InsertMany(List<RegistroAhorro> entities);
        Task<RegistroAhorro> Update(RegistroAhorro entity);
        Task<List<RegistroAhorro>> UpdateMany(List<RegistroAhorro> entities);
        Task Delete(RegistroAhorro entity);
        Task DeleteMany(List<RegistroAhorro> entities);
    }
}
