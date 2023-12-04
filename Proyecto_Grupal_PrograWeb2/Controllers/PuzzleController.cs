using Proyecto_Grupal_PrograWeb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class PuzzleController : Controller
    {
        private usuario objUsuario = new usuario();
        // GET: Puzzle
        public ActionResult Puzzle1()
        {
            var juego = new
            {
                Id = 1, // Supongamos que el ID del juego es 1
                Nivel = 1 // Supongamos que es el nivel 1
            };

            return View(juego);
        }

        [HttpPost]
        public JsonResult GuardarPuntaje(int nivel, double puntos, int juegoid)
        {
            try
            {
                Console.WriteLine($"Recibida solicitud para guardar puntaje. Nivel: {nivel}, Puntos: {puntos}");

              


                objUsuario.GuardarPuntajeEnBD(puntos, nivel, juegoid);

                Console.WriteLine("Puntaje guardado exitosamente.");
                
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar guardar el puntaje: {ex.Message}");
                // Maneja las excepciones según tus necesidades
                return Json(new { success = false, message = ex.Message });
            }
        }




        public ActionResult Puzzle2()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPuzzle()
        {
            return View();
        }


    }
}