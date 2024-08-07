﻿using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ITarjetaService
    {
        Task<ResponseModel> GetAll(int idUsuario);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(TarjetaRequest entity);
        Task<ResponseModel> Update(TarjetaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
