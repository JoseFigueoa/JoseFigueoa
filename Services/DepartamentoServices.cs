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
    public class DepartamentoServices
    {
        private readonly GestorDeActasNetContext _context;

        public DepartamentoServices(GestorDeActasNetContext context)
        {
            _context = context;
        }

        public async Task<bool> Ingresar(Departamento _departamento)
        {

            Departamentos departamentos = new Departamentos();
            departamentos.Id = _departamento.id;
            departamentos.IdPais = _departamento.id_pais;
            departamentos.Departamento = _departamento.departamento;

            _context.Departamentos.Add(departamentos);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Editar(Departamento _departamento)
        {

            Departamentos departamentos = new Departamentos();
            departamentos.Id = _departamento.id;
            departamentos.IdPais = _departamento.id_pais;
            departamentos.Departamento = _departamento.departamento;

            _context.Departamentos.Update(departamentos);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Eliminar(int id)
        {

            var departamento = await _context.Departamentos.FindAsync(id);
            _context.Departamentos.Remove(departamento);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Departamento>> Obtener()
        {

            return await (
                    from _depto in _context.Departamentos
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    select
                        new Departamento
                        {
                            id = _depto.Id,
                            departamento = _depto.Departamento,
                            Pais = new Pais()
                            {
                                id = _pais.Id,
                                pais = _pais.Pais
                            }
                        }
                    ).ToListAsync();

        }

        public async Task<Departamento> Obtener(int id)
        {

            return await (
                    from _depto in _context.Departamentos
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    where _depto.Id == id
                    select
                        new Departamento
                        {
                            id = _depto.Id,
                            departamento = _depto.Departamento,
                            Pais = new Pais()
                            {
                                id = _pais.Id,
                                pais = _pais.Pais
                            }
                        }
                    ).FirstOrDefaultAsync();

        }



        public async Task<List<Departamento>> ObtenerPorPais(int id_pais)
        {

            return await (
                    from _depto in _context.Departamentos
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    where _pais.Id == id_pais
                    select
                        new Departamento
                        {
                            id = _depto.Id,
                            departamento = _depto.Departamento,
                            Pais = new Pais()
                            {
                                id = _pais.Id,
                                pais = _pais.Pais
                            }
                        }
                    ).ToListAsync();

        }

        public async Task<DataTable> ObtenerDT()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id")); 
            dt.Columns.Add(new DataColumn("id_pais")); 
            dt.Columns.Add(new DataColumn("departamento")); 
            dt.Columns.Add(new DataColumn("pais"));

            var departamentos = await Obtener();

            foreach (var item in departamentos)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = item.id;
                dr["id_pais"] = item.Pais.id;
                dr["departamento"] = item.departamento;
                dr["pais"] = item.Pais.pais;

                dt.Rows.Add(dr);
            }

            return dt;

        }

    }
}
