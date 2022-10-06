using Gestor2._0.Data.DB_BASE;
using Gestor2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Services
{
    public class PaisServices
    {
        private readonly GestorDeActasNetContext _context;

        public PaisServices(GestorDeActasNetContext context)
        {
            _context = context;
        }

        public async Task<List<Pais>> ObtenerPaises()
        {

            return await (from _pais in _context.Paises
                          select new Pais { id = _pais.Id, pais = _pais.Pais }
                    ).ToListAsync();

        }

    }
}
