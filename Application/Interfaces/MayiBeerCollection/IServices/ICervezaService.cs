﻿using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    public interface ICervezaService
    {
        Task<ResponseModel> GetAll(bool fullresponse);
        Task<ResponseModel> GetById(int? id, bool fullresponse);
        Task<ResponseModel> Insert(CervezaRequest mercaderia);
        Task<ResponseModel> Update(CervezaRequest mercaderia, int id);
        Task<ResponseModel> Delete(int id);
    }
}
