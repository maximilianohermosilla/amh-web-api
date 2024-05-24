﻿using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IRegistroQuery
    {
        Task<List<Registro>> GetAll(int idUsuario, string? periodo);
        Task<Registro> GetById(int? id);
    }
}
