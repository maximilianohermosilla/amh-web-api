﻿using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ISuscripcionService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(SuscripcionRequest entity);
        Task<ResponseModel> Update(SuscripcionRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
