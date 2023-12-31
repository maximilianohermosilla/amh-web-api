﻿using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Domain.Models.MayiBeerCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.MayiBeerCollection
{
    public class CervezaQuery : ICervezaQuery
    {
        private AmhWebDbContext _context;

        public CervezaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cerveza>> GetAll(int? IdMarca, int? IdEstilo, int? IdCiudad, int? IdPais, bool fullresponse)
        {
            if(fullresponse)
            {
                var lista = await _context.Cerveza.Where(c => (IdMarca == 0 || c.IdMarca == IdMarca)
                                                          && (IdEstilo == 0 || c.IdEstilo == IdEstilo)
                                                          && (IdCiudad == 0 || c.IdCiudad == IdCiudad)
                                                          && (IdPais == 0 || c.Ciudad.IdPais == IdPais))
                    .Include(c => c.Marca).Include(c => c.Estilo).Include(c => c.Ciudad).Include(c => c.Ciudad.Pais).ToListAsync();
                return lista;
            }
            else
            {
                var lista = await _context.Cerveza.Where(c => (IdMarca == 0 || c.IdMarca == IdMarca)
                                                          && (IdEstilo == 0 || c.IdEstilo == IdEstilo)
                                                          && (IdCiudad == 0 || c.IdCiudad == IdCiudad)
                                                          && (IdPais == 0 || c.Ciudad.IdPais == IdPais)).ToListAsync();
                return lista;
            }
        }

        public async Task<Cerveza> GetById(int? id, bool fullresponse)
        {
            if (fullresponse)
            {
                var element = await _context.Cerveza.Where(m => m.Id == id).Include(c => c.Estilo).Include(c => c.Ciudad).Include(c => c.Ciudad.Pais).Include(c => c.Marca).FirstOrDefaultAsync();
                return element;
            }
            else
            {
                var element = await _context.Cerveza.Where(m => m.Id == id).FirstOrDefaultAsync();
                return element;
            }
            
        }

        public async Task<List<ReporteResponse>> GetCountReport()
        {
            var lista = await (from cerveza in _context.Cerveza
                        join ciudad in _context.Ciudad on cerveza.IdCiudad equals ciudad.Id
                        select new ReporteResponse
                        {
                            Id= cerveza.Id,
                            IdMarca = cerveza.IdMarca,
                            IdEstilo = cerveza.IdEstilo,
                            IdCiudad = cerveza.IdCiudad,
                            IdPais = ciudad.IdPais
                        }).ToListAsync();

            return lista;
        }
    }
}
