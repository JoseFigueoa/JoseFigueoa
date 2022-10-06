using Gestor2._0.Data.DB_BASE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Services
{
    public class EventoServices
    {
        //private readonly GestorDeActasNetContext _context;

        //public EventoServices(GestorDeActasNetContext context)
        //{
        //    _context = context;
        //}

        //public async Task<DataTable> ObtenerBautizoDT()
        //{

        //    DataTable dt = new DataTable();

        //    dt.Columns.Add(new DataColumn("id"));
        //    dt.Columns.Add(new DataColumn("nombre_bautizo"));
        //    dt.Columns.Add(new DataColumn("nombre_padre"));
        //    dt.Columns.Add(new DataColumn("nombre_madre"));
        //    dt.Columns.Add(new DataColumn("nombre_padrino"));
        //    dt.Columns.Add(new DataColumn("nombre_madrina"));
        //    dt.Columns.Add(new DataColumn("no_libro"));
        //    dt.Columns.Add(new DataColumn("no_folio"));
        //    dt.Columns.Add(new DataColumn("fecha_registro"));
        //    dt.Columns.Add(new DataColumn("fecha_evento"));
        //    dt.Columns.Add(new DataColumn("nota"));

        //    var bautizos = await (
        //            from _st in _context.Bautizos
        //            select _st
        //            ).ToListAsync();

        //    foreach (var item in bautizos)
        //    {

        //        DataRow dr = dt.NewRow();
        //        dr["id"] = item.Id;
        //        dr["nombre_bautizo"] = item.Nombres;
        //        dr["nombre_padre"] = item.NombrePadre;
        //        dr["nombre_madre"] = item.NombreMadre;
        //        dr["nombre_padrino"] = item.NombrePadrino;
        //        dr["nombre_madrina"] = item.NombreMadrina;
        //        dr["no_libro"] = item.NoLibro;
        //        dr["no_folio"] = item.NoFolio;
        //        dr["fecha_registro"] = Convert.ToDateTime(item.FechaRegistro).ToShortDateString();
        //        dr["fecha_evento"] = Convert.ToDateTime(item.FechaEvento).ToShortDateString();
        //        dr["nota"] = item.Nota;

        //        dt.Rows.Add(dr);
        //    }


        //    return dt;

        //}

        //public async Task<DataTable> ObtenerBautizoDT(int id)
        //{

        //    DataTable dt = new DataTable();

        //    dt.Columns.Add(new DataColumn("id"));
        //    dt.Columns.Add(new DataColumn("nombre_bautizo"));
        //    dt.Columns.Add(new DataColumn("nombre_padre"));
        //    dt.Columns.Add(new DataColumn("nombre_madre"));
        //    dt.Columns.Add(new DataColumn("nombre_padrino"));
        //    dt.Columns.Add(new DataColumn("nombre_madrina"));
        //    dt.Columns.Add(new DataColumn("no_libro"));
        //    dt.Columns.Add(new DataColumn("no_folio"));
        //    dt.Columns.Add(new DataColumn("fecha_registro"));
        //    dt.Columns.Add(new DataColumn("fecha_evento"));
        //    dt.Columns.Add(new DataColumn("nota"));

        //    var bautizos = await (
        //            from _st in _context.Bautizos
        //            where _st.Id == id
        //            select _st
        //            ).ToListAsync();

        //    foreach (var item in bautizos)
        //    {

        //        DataRow dr = dt.NewRow();
        //        dr["id"] = item.Id;
        //        dr["nombre_bautizo"] = item.Nombres;
        //        dr["nombre_padre"] = item.NombrePadre;
        //        dr["nombre_madre"] = item.NombreMadre;
        //        dr["nombre_padrino"] = item.NombrePadrino;
        //        dr["nombre_madrina"] = item.NombreMadrina;
        //        dr["no_libro"] = item.NoLibro;
        //        dr["no_folio"] = item.NoFolio;
        //        dr["fecha_registro"] = Convert.ToDateTime(item.FechaRegistro).ToShortDateString();
        //        dr["fecha_evento"] = Convert.ToDateTime(item.FechaEvento).ToShortDateString();
        //        dr["nota"] = item.Nota;

        //        dt.Rows.Add(dr);
        //    }


        //    return dt;

        //}

        //public async Task<DataTable> ObtenerConfirmacionDT()
        //{

        //    DataTable dt = new DataTable();

        //    dt.Columns.Add(new DataColumn("id"));
        //    dt.Columns.Add(new DataColumn("nombre_confirmacion"));
        //    dt.Columns.Add(new DataColumn("nombre_padrino"));
        //    dt.Columns.Add(new DataColumn("nombre_madrina"));
        //    dt.Columns.Add(new DataColumn("no_libro"));
        //    dt.Columns.Add(new DataColumn("no_folio"));
        //    dt.Columns.Add(new DataColumn("fecha_registro"));
        //    dt.Columns.Add(new DataColumn("fecha_evento"));
        //    dt.Columns.Add(new DataColumn("nota"));

        //    var confirmaciones = await (
        //            from _st in _context.Confirmaciones
        //            select _st
        //            ).ToListAsync();

        //    foreach (var item in confirmaciones)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["id"] = item.Id;
        //        dr["nombre_confirmacion"] = item.Nombres;
        //        dr["nombre_padrino"] = item.NombrePadrino;
        //        dr["nombre_madrina"] = item.NombreMadrina;
        //        dr["no_libro"] = item.NoLibro;
        //        dr["no_folio"] = item.NoFolio;
        //        dr["fecha_registro"] = Convert.ToDateTime(item.FechaRegistro).ToShortDateString();
        //        dr["fecha_evento"] = Convert.ToDateTime(item.FechaEvento).ToShortDateString();
        //        dr["nota"] = item.Nota;

        //        dt.Rows.Add(dr);

        //    }

        //    return dt;

        //}

        //public async Task<DataTable> ObtenerConfirmacionDT(int id)
        //{

        //    DataTable dt = new DataTable();

        //    dt.Columns.Add(new DataColumn("id"));
        //    dt.Columns.Add(new DataColumn("nombre_confirmacion"));
        //    dt.Columns.Add(new DataColumn("nombre_padrino"));
        //    dt.Columns.Add(new DataColumn("nombre_madrina"));
        //    dt.Columns.Add(new DataColumn("no_libro"));
        //    dt.Columns.Add(new DataColumn("no_folio"));
        //    dt.Columns.Add(new DataColumn("fecha_registro"));
        //    dt.Columns.Add(new DataColumn("fecha_evento"));
        //    dt.Columns.Add(new DataColumn("nota"));

        //    var confirmaciones = await (
        //            from _st in _context.Confirmaciones
        //            where _st.Id == id
        //            select _st
        //            ).ToListAsync();
            

        //    foreach (var item in confirmaciones)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["id"] = item.Id;
        //        dr["nombre_confirmacion"] = item.Nombres;
        //        dr["nombre_padrino"] = item.NombrePadrino;
        //        dr["nombre_madrina"] = item.NombreMadrina;
        //        dr["no_libro"] = item.NoLibro;
        //        dr["no_folio"] = item.NoFolio;
        //        dr["fecha_registro"] = Convert.ToDateTime(item.FechaRegistro).ToShortDateString();
        //        dr["fecha_evento"] = Convert.ToDateTime(item.FechaEvento).ToShortDateString();
        //        dr["nota"] = item.Nota;

        //        dt.Rows.Add(dr);

        //    }

        //    return dt;

        //}

        //public async Task<DataTable> ObtenerMatrimonioDT()
        //{

        //    DataTable dt = new DataTable();

        //    dt.Columns.Add(new DataColumn("id"));
        //    dt.Columns.Add(new DataColumn("nombre_esposo"));
        //    dt.Columns.Add(new DataColumn("nombre_esposa"));
        //    dt.Columns.Add(new DataColumn("no_libro"));
        //    dt.Columns.Add(new DataColumn("no_folio"));
        //    dt.Columns.Add(new DataColumn("fecha_registro"));
        //    dt.Columns.Add(new DataColumn("fecha_evento"));
        //    dt.Columns.Add(new DataColumn("nota"));

        //    var matrimonios = await (
        //            from _st in _context.Matrimonios
        //            select _st
        //            ).ToListAsync();

        //    foreach (var item in matrimonios)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["id"] = item.Id;
        //        dr["nombre_esposo"] = item.NombreEsposo;
        //        dr["nombre_esposa"] = item.NombreEsposa;
        //        dr["no_libro"] = item.NoLibro;
        //        dr["no_folio"] = item.NoFolio;
        //        dr["fecha_registro"] = Convert.ToDateTime(item.FechaRegistro).ToShortDateString();
        //        dr["fecha_evento"] = Convert.ToDateTime(item.FechaEvento).ToShortDateString();
        //        dr["nota"] = item.Nota;

        //        dt.Rows.Add(dr);
        //    }

        //    return dt;

        //}

        //public async Task<DataTable> ObtenerMatrimonioDT(int id)
        //{

        //    DataTable dt = new DataTable();

        //    dt.Columns.Add(new DataColumn("id"));
        //    dt.Columns.Add(new DataColumn("nombre_esposo"));
        //    dt.Columns.Add(new DataColumn("nombre_esposa"));
        //    dt.Columns.Add(new DataColumn("no_libro"));
        //    dt.Columns.Add(new DataColumn("no_folio"));
        //    dt.Columns.Add(new DataColumn("fecha_registro"));
        //    dt.Columns.Add(new DataColumn("fecha_evento"));
        //    dt.Columns.Add(new DataColumn("nota"));

        //    var matrimonios = await (
        //            from _st in _context.Matrimonios
        //            where _st.Id == id
        //            select _st
        //            ).ToListAsync();

        //    foreach (var item in matrimonios)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["id"] = item.Id;
        //        dr["nombre_esposo"] = item.NombreEsposo;
        //        dr["nombre_esposa"] = item.NombreEsposa;
        //        dr["no_libro"] = item.NoLibro;
        //        dr["no_folio"] = item.NoFolio;
        //        dr["fecha_registro"] = Convert.ToDateTime(item.FechaRegistro).ToShortDateString();
        //        dr["fecha_evento"] = Convert.ToDateTime(item.FechaEvento).ToShortDateString();
        //        dr["nota"] = item.Nota;

        //        dt.Rows.Add(dr);
        //    }

        //    return dt;

        //}


    }
}
