using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface IRegistroCommand
    {
        Task<Registro> Insert(Registro entity);
        Task<List<Registro>> InsertMany(List<Registro> entity);
        Task<Registro> Update(Registro entity);
        Task<List<Registro>> UpdateMany(List<Registro> entity);
        Task Delete(Registro entity);
        Task DeleteMany(List<Registro> entity);
    }
}
