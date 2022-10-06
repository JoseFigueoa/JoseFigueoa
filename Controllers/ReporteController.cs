using AspNetCore.Reporting;
using Gestor2._0.Data.DB_BASE;
using Gestor2._0.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Controllers
{
    public class ReporteController : Controller
    {
        private IWebHostEnvironment _webHostEnvironmet;
        private readonly GestorDeActasNetContext _context;

        public int extension { get { return 1; } }
        public string mimetype { get { return ""; } }


        public ReporteController(GestorDeActasNetContext context, IWebHostEnvironment webHostEnvironmet)
        {
            _context = context;
            _webHostEnvironmet = webHostEnvironmet;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Departamento()
        {

            var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptDepartamentos.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "");

            DepartamentoServices services = new DepartamentoServices(_context);
            DataTable dt = await services.ObtenerDT();

            LocalReport local = new LocalReport(path);
            local.AddDataSource("dsReporte", dt);

            var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
            return File(result.MainStream, "application/pdf");

        }

        public async Task<IActionResult> Municipio()
        {

            var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptMunicipio.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "");

            MunicipioServices services = new MunicipioServices(_context);
            DataTable dt = await services.ObtenerDT();

            LocalReport local = new LocalReport(path);
            local.AddDataSource("dsReporte", dt);

            var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
            return File(result.MainStream, "application/pdf");

        }

        public async Task<IActionResult> TipoPersona()
        {

            var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptTipoPersona.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "");

            TipoPersonaServices services = new TipoPersonaServices(_context);
            DataTable dt = await services.ObtenerDT();

            LocalReport local = new LocalReport(path);
            local.AddDataSource("dsReporte", dt);

            var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
            return File(result.MainStream, "application/pdf");

        }

        public async Task<IActionResult> Persona()
        {

            var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptPersona.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "");

            PersonaServices services = new PersonaServices(_context);
            DataTable dt = await services.ObtenerDT();

            LocalReport local = new LocalReport(path);
            local.AddDataSource("dsReporte", dt);

            var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
            return File(result.MainStream, "application/pdf");

        }

        public async Task<IActionResult> PersonaDetalle(int id)
        {

            var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptPersonaDetalle.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "");

            PersonaServices services = new PersonaServices(_context);
            DataTable dt = await services.ObtenerDT(id);

            LocalReport local = new LocalReport(path);
            local.AddDataSource("dsReporte", dt);

            var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
            return File(result.MainStream, "application/pdf");

        }

        //public async Task<IActionResult> Bautizo()
        //{

        //    var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptBautizo.rdlc";

        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "");

        //    EventoServices services = new EventoServices(_context);
        //    DataTable dt = await services.ObtenerBautizoDT();

        //    LocalReport local = new LocalReport(path);
        //    local.AddDataSource("dsReporte", dt);

        //    var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}

        //public async Task<IActionResult> BautizoDetalle(int id)
        //{

        //    var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptBautizoDetalle.rdlc";

        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "");

        //    EventoServices services = new EventoServices(_context);
        //    DataTable dt = await services.ObtenerBautizoDT(id);

        //    LocalReport local = new LocalReport(path);
        //    local.AddDataSource("dsReporte", dt);

        //    var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}

        //public async Task<IActionResult> Matrimonio()
        //{

        //    var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptMatrimonio.rdlc";

        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "");

        //    EventoServices services = new EventoServices(_context);
        //    DataTable dt = await services.ObtenerMatrimonioDT();

        //    LocalReport local = new LocalReport(path);
        //    local.AddDataSource("dsReporte", dt);

        //    var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}

        //public async Task<IActionResult> MatrimonioDetalle(int id)
        //{

        //    var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptMatrimonioDetalle.rdlc";

        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "");

        //    EventoServices services = new EventoServices(_context);
        //    DataTable dt = await services.ObtenerMatrimonioDT(id);

        //    LocalReport local = new LocalReport(path);
        //    local.AddDataSource("dsReporte", dt);

        //    var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}

        //public async Task<IActionResult> Confirmacion()
        //{

        //    var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptConfirmacion.rdlc";

        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "");

        //    EventoServices services = new EventoServices(_context);
        //    DataTable dt = await services.ObtenerConfirmacionDT();

        //    LocalReport local = new LocalReport(path);
        //    local.AddDataSource("dsReporte", dt);

        //    var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}

        //public async Task<IActionResult> ConfirmacionDetalle(int id)
        //{

        //    var path = $"{this._webHostEnvironmet.WebRootPath}\\reports\\rptConfirmacionDetalle.rdlc";

        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "");

        //    EventoServices services = new EventoServices(_context);
        //    DataTable dt = await services.ObtenerConfirmacionDT(id);

        //    LocalReport local = new LocalReport(path);
        //    local.AddDataSource("dsReporte", dt);

        //    var result = local.Execute(RenderType.Pdf, extension, null, mimetype);
        //    return File(result.MainStream, "application/pdf");

        //}

    }



}
