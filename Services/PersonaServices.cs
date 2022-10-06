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
    public class PersonaServices
    {
        private readonly GestorDeActasNetContext _context;

        public PersonaServices(GestorDeActasNetContext context)
        {
            _context = context;
        }

        public async Task<bool> Ingresar(Persona _persona)
        {

            Personas personas = new Personas();
            personas.Id = _persona.id;
            personas.PrimerNombre = _persona.primer_nombre;

            if (_persona.segundo_nombre.Length > 0)
                personas.SegundoNombre = _persona.segundo_nombre;

            if (_persona.tercer_nombre.Length > 0)
                personas.TercerNombre = _persona.tercer_nombre;

            personas.PrimerApellido = _persona.primer_nombre;

            if (_persona.segundo_apellido.Length > 0)
                personas.SegundoApellido = _persona.segundo_apellido;

            if (_persona.apellido_casada.Length > 0)
                personas.ApellidoCasada = _persona.apellido_casada;

            personas.FechaNacimiento = _persona.fecha_nacimiento;
            personas.Direccion = _persona.direccion;
            personas.IdUbicacion = _persona.id_ubicacion;
            personas.IdTipoPersona = _persona.id_tipopersona;
            personas.IdGenero = _persona.id_genero;

            _context.Personas.Add(personas);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Editar(Persona _persona)
        {

            Personas personas = new Personas();
            personas.Id = _persona.id;
            personas.PrimerNombre = _persona.primer_nombre;
            
            if (_persona.segundo_nombre.Length > 0)
                personas.SegundoNombre = _persona.segundo_nombre;

            if (_persona.tercer_nombre.Length > 0)
                personas.TercerNombre = _persona.tercer_nombre;

                personas.PrimerApellido = _persona.primer_nombre;

            if (_persona.segundo_apellido.Length > 0)
                personas.SegundoApellido = _persona.segundo_apellido;

            if (_persona.apellido_casada.Length > 0)
                personas.ApellidoCasada = _persona.apellido_casada;

            personas.FechaNacimiento = _persona.fecha_nacimiento;
            personas.Direccion = _persona.direccion;
            personas.IdUbicacion = _persona.id_ubicacion;
            personas.IdTipoPersona = _persona.id_tipopersona;
            personas.IdGenero = _persona.id_genero;

            _context.Personas.Update(personas);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Eliminar(int id)
        {

            var persona = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(persona);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Persona>> Obtener()
        {

            return await (
                    from _persona in _context.Personas
                    join _tipoPersona in _context.TipoPersonas
                    on _persona.IdTipoPersona equals _tipoPersona.Id
                    join _genero in _context.Generos
                    on _persona.IdGenero equals _genero.Id
                    join _ubicacion in _context.Ubicaciones
                    on _persona.IdUbicacion equals _ubicacion.Id
                    join _depto in _context.Departamentos
                    on _ubicacion.IdDepartamento equals _depto.Id
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    select
                        new Persona
                        {
                            id = _persona.Id,
                            primer_nombre = _persona.PrimerNombre,
                            segundo_nombre = _persona.SegundoNombre,
                            primer_apellido = _persona.PrimerApellido,
                            segundo_apellido = _persona.SegundoApellido,
                            tercer_nombre = _persona.TercerNombre,
                            id_genero = _persona.IdGenero,
                            id_tipopersona = _persona.IdTipoPersona,
                            id_ubicacion = _persona.IdUbicacion,
                            fecha_nacimiento = _persona.FechaNacimiento,
                            direccion = _persona.Direccion,
                            Ubicacion = new Municipio
                            {
                                id = _ubicacion.Id,
                                id_departamento = _ubicacion.IdDepartamento,
                                municipio = _ubicacion.Municipio,
                                Departamento = new Departamento
                                {
                                    id = _depto.Id,
                                    id_pais = _depto.IdPais,
                                    departamento = _depto.Departamento,
                                    Pais = new Pais
                                    {
                                        id = _pais.Id,
                                        pais = _pais.Pais
                                    }
                                }

                            },
                            TipoPersona = new TipoPersona 
                            { 
                                id = _tipoPersona.Id,
                                tipo_persona = _tipoPersona.TipoPersona
                            },
                            Genero = new Genero
                            {
                                id = _genero.Id,
                                genero = _genero.Genero
                            }                            
                        }
                    ).ToListAsync();

        }

        public async Task<Persona> Obtener(int id)
        {

            return await (
                    from _persona in _context.Personas
                    join _tipoPersona in _context.TipoPersonas
                    on _persona.IdTipoPersona equals _tipoPersona.Id
                    join _genero in _context.Generos
                    on _persona.IdGenero equals _genero.Id
                    join _ubicacion in _context.Ubicaciones
                    on _persona.IdUbicacion equals _ubicacion.Id
                    join _depto in _context.Departamentos
                    on _ubicacion.IdDepartamento equals _depto.Id
                    join _pais in _context.Paises
                    on _depto.IdPais equals _pais.Id
                    where _persona.Id == id
                    select
                        new Persona
                        {
                            id = _persona.Id,
                            primer_nombre = _persona.PrimerNombre,
                            segundo_nombre = _persona.SegundoNombre,
                            primer_apellido = _persona.PrimerApellido,
                            segundo_apellido = _persona.SegundoApellido,
                            tercer_nombre = _persona.TercerNombre,
                            id_genero = _persona.IdGenero,
                            id_tipopersona = _persona.IdTipoPersona,
                            id_ubicacion = _persona.IdUbicacion,
                            fecha_nacimiento = _persona.FechaNacimiento,
                            direccion = _persona.Direccion,
                            Ubicacion = new Municipio
                            {
                                id = _ubicacion.Id,
                                id_departamento = _ubicacion.IdDepartamento,
                                municipio = _ubicacion.Municipio,
                                Departamento = new Departamento
                                {
                                    id = _depto.Id,
                                    id_pais = _depto.IdPais,
                                    departamento = _depto.Departamento,
                                    Pais = new Pais
                                    {
                                        id = _pais.Id,
                                        pais = _pais.Pais
                                    }
                                }
                            },
                            TipoPersona = new TipoPersona
                            {
                                id = _tipoPersona.Id,
                                tipo_persona = _tipoPersona.TipoPersona
                            },
                            Genero = new Genero
                            {
                                id = _genero.Id,
                                genero = _genero.Genero
                            }
                        }
                    ).FirstOrDefaultAsync();

        }

        public async Task<DataTable> ObtenerDT()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("primer_nombre"));
            dt.Columns.Add(new DataColumn("segundo_nombre"));
            dt.Columns.Add(new DataColumn("tercer_nombre"));
            dt.Columns.Add(new DataColumn("primer_apellido"));
            dt.Columns.Add(new DataColumn("segundo_apellido"));
            dt.Columns.Add(new DataColumn("apellido_casada"));
            dt.Columns.Add(new DataColumn("fecha_nacimiento"));
            dt.Columns.Add(new DataColumn("direccion"));
            dt.Columns.Add(new DataColumn("municipio"));
            dt.Columns.Add(new DataColumn("departamento"));
            dt.Columns.Add(new DataColumn("pais"));
            dt.Columns.Add(new DataColumn("genero"));
            dt.Columns.Add(new DataColumn("tipo_persona"));

            var persona = await Obtener();

            foreach (var item in persona)
            {                                
                DataRow dr = dt.NewRow();
                dr["id"] = item.id;
                dr["primer_nombre"] = item.primer_nombre;
                dr["segundo_nombre"] = item.segundo_nombre;
                dr["tercer_nombre"] = item.tercer_nombre;
                dr["primer_apellido"] = item.primer_apellido;
                dr["segundo_apellido"] = item.segundo_apellido;
                dr["apellido_casada"] = item.apellido_casada;
                dr["fecha_nacimiento"] = item.fecha_nacimiento.ToShortDateString();
                dr["direccion"] = item.direccion;
                dr["municipio"] = item.Ubicacion.municipio;
                dr["departamento"] = item.Ubicacion.Departamento.departamento;
                dr["pais"] = item.Ubicacion.Departamento.Pais.pais;
                dr["genero"] = item.Genero.genero;
                dr["tipo_persona"] = item.TipoPersona.tipo_persona;

                dt.Rows.Add(dr);
            }

            return dt;

        }

        public async Task<DataTable> ObtenerDT(int id)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("primer_nombre"));
            dt.Columns.Add(new DataColumn("segundo_nombre"));
            dt.Columns.Add(new DataColumn("tercer_nombre"));
            dt.Columns.Add(new DataColumn("primer_apellido"));
            dt.Columns.Add(new DataColumn("segundo_apellido"));
            dt.Columns.Add(new DataColumn("apellido_casada"));
            dt.Columns.Add(new DataColumn("fecha_nacimiento"));
            dt.Columns.Add(new DataColumn("direccion"));
            dt.Columns.Add(new DataColumn("municipio"));
            dt.Columns.Add(new DataColumn("departamento"));
            dt.Columns.Add(new DataColumn("pais"));
            dt.Columns.Add(new DataColumn("genero"));
            dt.Columns.Add(new DataColumn("tipo_persona"));

            var persona = await Obtener(id);

            if (persona == null)
                return dt;

            DataRow dr = dt.NewRow();
            dr["id"] = persona.id;
            dr["primer_nombre"] = persona.primer_nombre;
            dr["segundo_nombre"] = persona.segundo_nombre;
            dr["tercer_nombre"] = persona.tercer_nombre;
            dr["primer_apellido"] = persona.primer_apellido;
            dr["segundo_apellido"] = persona.segundo_apellido;
            dr["apellido_casada"] = persona.apellido_casada;
            dr["fecha_nacimiento"] = persona.fecha_nacimiento.ToShortDateString();
            dr["direccion"] = persona.direccion;
            dr["municipio"] = persona.Ubicacion.municipio;
            dr["departamento"] = persona.Ubicacion.Departamento.departamento;
            dr["pais"] = persona.Ubicacion.Departamento.Pais.pais;
            dr["genero"] = persona.Genero.genero;
            dr["tipo_persona"] = persona.TipoPersona.tipo_persona;

            dt.Rows.Add(dr);

            return dt;

        }

    }
}
