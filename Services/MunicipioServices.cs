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
    public class MunicipioServices
    {

        private readonly GestorDeActasNetContext _context;

        public MunicipioServices(GestorDeActasNetContext context)
        {
            _context = context;
        }

        public async Task<bool> Ingresar(Municipio _municipio)
        {

            Ubicaciones municipios = new Ubicaciones();
            municipios.Id = _municipio.id;
            municipios.IdDepartamento = _municipio.id_departamento;
            municipios.Municipio = _municipio.municipio;

            _context.Ubicaciones.Add(municipios);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Editar(Municipio _municipio)
        {

            Ubicaciones municipios = new Ubicaciones();
            municipios.Id = _municipio.id;
            municipios.IdDepartamento = _municipio.id_departamento;
            municipios.Municipio = _municipio.municipio;

            _context.Ubicaciones.Update(municipios);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Eliminar(int id)
        {

            var _municipio = await _context.Ubicaciones.FindAsync(id);
            _context.Ubicaciones.Remove(_municipio);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Municipio>> Obtener()
        {


            return await (
                    from _municipio in _context.Ubicaciones
                    join _depto in _context.Departamentos
                    on _municipio.IdDepartamento equals _depto.Id
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    select
                        new Municipio
                        {
                            id = _municipio.Id,
                            municipio = _municipio.Municipio,
                            id_departamento = _depto.Id,
                            Departamento = new Departamento
                            {
                                id = _depto.Id,
                                departamento = _depto.Departamento,
                                Pais = new Pais
                                {
                                    id = _pais.Id,
                                    pais = _pais.Pais
                                }
                            },
                        }
                    ).ToListAsync();

        }

        public async Task<Municipio> Obtener(int id)
        {

            return await (
                    from _municipio in _context.Ubicaciones
                    join _depto in _context.Departamentos
                    on _municipio.IdDepartamento equals _depto.Id
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    where _municipio.Id == id
                    select
                        new Municipio
                        {
                            id = _municipio.Id,
                            municipio = _municipio.Municipio,
                            id_departamento = _depto.Id,
                            Departamento = new Departamento
                            {
                                id = _depto.Id,
                                departamento = _depto.Departamento,
                                Pais = new Pais
                                {
                                    id = _pais.Id,
                                    pais = _pais.Pais
                                }
                            },
                        }
                    ).FirstOrDefaultAsync();

        }

        public async Task<List<Municipio>> ObtenerPorDepartamento(int id)
        {

            return await (
                    from _municipio in _context.Ubicaciones
                    join _depto in _context.Departamentos
                    on _municipio.IdDepartamento equals _depto.Id
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    where _municipio.IdDepartamento == id
                    select
                        new Municipio
                        {
                            id = _municipio.Id,
                            municipio = _municipio.Municipio,
                            id_departamento = _depto.Id,
                            Departamento = new Departamento
                            {
                                id = _depto.Id,
                                departamento = _depto.Departamento,
                                Pais = new Pais
                                {
                                    id = _pais.Id,
                                    pais = _pais.Pais
                                }
                            },
                        }
                    ).ToListAsync();

        }

        public async Task<DataTable> ObtenerDT()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("id_departamento"));
            dt.Columns.Add(new DataColumn("id_pais"));
            dt.Columns.Add(new DataColumn("municipio"));
            dt.Columns.Add(new DataColumn("departamento"));
            dt.Columns.Add(new DataColumn("pais"));

            var municipios = await Obtener();

            foreach (var item in municipios)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = item.id;
                dr["id_departamento"] = item.Departamento.id;
                dr["id_pais"] = item.Departamento.Pais.id;
                dr["municipio"] = item.municipio;
                dr["departamento"] = item.Departamento.departamento;
                dr["pais"] = item.Departamento.Pais.pais;

                dt.Rows.Add(dr);
            }

            return dt;

        }

    }
}
