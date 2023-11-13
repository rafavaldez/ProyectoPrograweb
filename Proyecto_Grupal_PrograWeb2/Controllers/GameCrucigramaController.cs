using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Grupal_PrograWeb2.Models;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class GameCrucigramaController : Controller
    {
        private ClsCrucigrama crucigrama;

        public GameCrucigramaController()
        {
            crucigrama = new ClsCrucigrama
            {
                Tabla = new char[15, 15], // Inicializa la tabla como necesites
                Palabras = new List<string> { "LEON", "MONO", "GATO", "PERRO", "ELEFANTE" }
            };

            // Lógica para llenar la tabla y ocultar ciertas casillas
            LlenarTabla();
        }

        private void LlenarTabla()
        {
            // Aquí implementa la lógica para llenar la tabla y ocultar ciertas casillas
            // Puedes acceder a la instancia crucigrama para hacerlo
        }

        // GET: GameCrucigrama
        public ActionResult Index()
        {
            return View(crucigrama);
        }
    }
}