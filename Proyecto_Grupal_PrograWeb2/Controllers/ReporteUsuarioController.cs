using Proyecto_Grupal_PrograWeb2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class ReporteUsuarioController : Controller
    {
        private score objscore = new score();
        // GET: ReporteUsuario
        public ActionResult Index()
        {
            return View(objscore.ObtenerScoresPorUsuario());
        }

        public ActionResult IndexReporteTotal()
        {
            return View(objscore.ObtenerScoresTodos());
        }
        [HttpGet]
        public ActionResult reportU(string juegoNombre)
        {
            Debug.WriteLine($"Valor de juegoNombre: {juegoNombre}");
            ViewBag.JuegoNombre = juegoNombre;
            return View(objscore.ObtenerScoresPorUsuario());
        }
    }
}