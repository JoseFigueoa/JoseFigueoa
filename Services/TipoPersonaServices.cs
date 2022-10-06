using Gestor2._0.Data.DB_BASE;
using Gestor2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Services
{
    public class TipoPersonaServices
    {
        private readonly GestorDeActasNetContext _context;

        public TipoPersonaServices(GestorDeActasNetContext context)
        {
            _context = context;
        }

        public async Task<bool> Ingresar(TipoPersona _tipo)
        {

            TipoPersonas tipoPersonas = new TipoPersonas();
            tipoPersonas.Id = _tipo.id;
            tipoPersonas.TipoPersona = _tipo.tipo_persona;

            _context.TipoPersonas.Add(tipoPersonas);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Editar(TipoPersona _tipo)
        {

            TipoPersonas tipoPersonas = new TipoPersonas();
            tipoPersonas.Id = _tipo.id;
            tipoPersonas.TipoPersona = _tipo.tipo_persona;

            _context.TipoPersonas.Update(tipoPersonas);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Eliminar(int id)
        {

            var _tipo = await _context.TipoPersonas.FindAsync(id);
            _context.TipoPersonas.Remove(_tipo);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<TipoPersona> Obtener(int id)
        {

            return await (
                    from _tipo in _context.TipoPersonas
                    where _tipo.Id == id
                    select
                        new TipoPersona
                        {
                            id = _tipo.Id,
                            tipo_persona = _tipo.TipoPersona
                        }
                    ).FirstOrDefaultAsync();

        }

        public async Task<List<TipoPersona>> Obtener()
        {

            return await (
                    from _tipo in _context.TipoPersonas
                    select
                        new TipoPersona
                        {
                            id = _tipo.Id,
                            tipo_persona = _tipo.TipoPersona
                        }
                    ).ToListAsync();

        }

        public async Task<DataTable> ObtenerDT()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("tipo_persona"));

            var tipo = await Obtener();

            foreach (var item in tipo)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = item.id;
                dr["tipo_persona"] = item.tipo_persona;
                
                dt.Rows.Add(dr);
            }

            return dt;

        }

    }
}
