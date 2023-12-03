using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Grupal_PrograWeb2.Models;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class GameSopaLetrasController : Controller
    {
        usuario objUsuario = new usuario();

        // GET: GameSopaLetras

        public int n = 0;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NivelFacil()
        {
            string[] palabras = { "LEON", "MONO", "GATO", "PERRO", "ELEFANTE" };
            List<string[]> letrasSeparadas = new List<string[]>();
            Random random = new Random();
            HashSet<Tuple<int, int>> posicionesOcupadas = new HashSet<Tuple<int, int>>();

            for (int i = 0; i < 12; i++)
            {
                letrasSeparadas.Add(new string[12]);
            }

            foreach (var palabra in palabras)
            {
                int fila, columna, direccion;

                do
                {
                    fila = random.Next(12);
                    columna = random.Next(12);
                    direccion = random.Next(3);
                } while (!EsPosicionValida(letrasSeparadas, palabra, fila, columna, direccion, 12));

                string[] letras = palabra.Select(c => c.ToString()).ToArray();

                if (direccion == 0) // horizontal
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila][columna + i] = letras[i];
                    }
                }
                else if (direccion == 1) // vertical
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila + i][columna] = letras[i];
                    }
                }
                else // diagonal
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila + i][columna + i] = letras[i];
                    }
                }
            }

            // Rellena el resto de las celdas con letras aleatorias
            for (int fila = 0; fila < 12; fila++)
            {
                for (int columna = 0; columna < 12; columna++)
                {
                    if (string.IsNullOrEmpty(letrasSeparadas[fila][columna]))
                    {
                        letrasSeparadas[fila][columna] = ((char)('A' + random.Next(26))).ToString();
                    }
                }
            }

            ViewBag.LetrasSeparadas = letrasSeparadas;
            ViewBag.Palabras = palabras;
            return View();
        }

        public ActionResult NivelNormal()
        {
            string[] palabras = { "TIGRE", "JIRAFA", "COCODRILO", "PINGÜINO", "CANGURO", "RINOCERONTE", "ZORRO" };
            List<string[]> letrasSeparadas = new List<string[]>();
            Random random = new Random();
            HashSet<Tuple<int, int>> posicionesOcupadas = new HashSet<Tuple<int, int>>();

            for (int i = 0; i < 14; i++)
            {
                letrasSeparadas.Add(new string[14]);
            }

            foreach (var palabra in palabras)
            {
                int fila, columna, direccion;

                do
                {
                    fila = random.Next(14);
                    columna = random.Next(14);
                    direccion = random.Next(3);
                } while (!EsPosicionValida(letrasSeparadas, palabra, fila, columna, direccion, 14));

                string[] letras = palabra.Select(c => c.ToString()).ToArray();

                if (direccion == 0) // horizontal
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila][columna + i] = letras[i];
                    }
                }
                else if (direccion == 1) // vertical
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila + i][columna] = letras[i];
                    }
                }
                else // diagonal
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila + i][columna + i] = letras[i];
                    }
                }
            }

            // Rellena el resto de las celdas con letras aleatorias
            for (int fila = 0; fila < 14; fila++)
            {
                for (int columna = 0; columna < 14; columna++)
                {
                    if (string.IsNullOrEmpty(letrasSeparadas[fila][columna]))
                    {
                        letrasSeparadas[fila][columna] = ((char)('A' + random.Next(26))).ToString();
                    }
                }
            }

            ViewBag.LetrasSeparadas = letrasSeparadas;
            ViewBag.Palabras = palabras;
            return View();
        }

        public ActionResult NivelDificil()
        {
            string[] palabras = { "MURCIELAGO", "PANTERA", "ORNITORRINCO", "GACELA", "OSO", "JAGUAR", "SURICATA", "CABALLO", "ORNITORRINCO", "ARMADILLO" };
            List<string[]> letrasSeparadas = new List<string[]>();
            Random random = new Random();
            HashSet<Tuple<int, int>> posicionesOcupadas = new HashSet<Tuple<int, int>>();

            for (int i = 0; i < 16; i++)
            {
                letrasSeparadas.Add(new string[16]);
            }

            foreach (var palabra in palabras)
            {
                int fila, columna, direccion;

                do
                {
                    fila = random.Next(16);
                    columna = random.Next(16);
                    direccion = random.Next(3);
                } while (!EsPosicionValida(letrasSeparadas, palabra, fila, columna, direccion, 16));

                string[] letras = palabra.Select(c => c.ToString()).ToArray();

                if (direccion == 0) // horizontal
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila][columna + i] = letras[i];
                    }
                }
                else if (direccion == 1) // vertical
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila + i][columna] = letras[i];
                    }
                }
                else // diagonal
                {
                    for (int i = 0; i < letras.Length; i++)
                    {
                        letrasSeparadas[fila + i][columna + i] = letras[i];
                    }
                }
            }

            // Rellena el resto de las celdas con letras aleatorias
            for (int fila = 0; fila < 16; fila++)
            {
                for (int columna = 0; columna < 16; columna++)
                {
                    if (string.IsNullOrEmpty(letrasSeparadas[fila][columna]))
                    {
                        letrasSeparadas[fila][columna] = ((char)('A' + random.Next(26))).ToString();
                    }
                }
            }

            ViewBag.LetrasSeparadas = letrasSeparadas;
            ViewBag.Palabras = palabras;
            return View();
        }

        private bool EsPosicionValida(List<string[]> letrasSeparadas, string palabra, int fila, int columna, int direccion, int nv)
        {
            string[] letras = palabra.Select(c => c.ToString()).ToArray();
            int tamaño = letras.Length;

            if (direccion == 0) // horizontal
            {
                if (columna + tamaño > nv) return false;

                for (int i = 0; i < tamaño; i++)
                {
                    if (!string.IsNullOrEmpty(letrasSeparadas[fila][columna + i]))
                    {
                        return false;
                    }
                }
            }
            else if (direccion == 1) // vertical
            {
                if (fila + tamaño > nv) return false;

                for (int i = 0; i < tamaño; i++)
                {
                    if (!string.IsNullOrEmpty(letrasSeparadas[fila + i][columna]))
                    {
                        return false;
                    }
                }
            }
            else // diagonal
            {
                if (fila + tamaño > nv || columna + tamaño > nv) return false;

                for (int i = 0; i < tamaño; i++)
                {
                    if (!string.IsNullOrEmpty(letrasSeparadas[fila + i][columna + i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Cambiar dependinedo del Usuario que entre
        public JsonResult ActualizarPuntaje(double puntaje)
        {
            try
            {
                objUsuario.GuardarPuntajeEnBD(puntaje, 1, 1);
                return Json(new { success = true, message = "Puntaje actualizado correctamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al actualizar el puntaje: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SeleccionarNivel(string nivel)
        {
            switch (nivel.ToUpper())
            {
                case "FACIL":
                    return RedirectToAction("NivelFacil");
                case "NORMAL":
                    return RedirectToAction("NivelNormal");
                case "DIFICIL":
                    return RedirectToAction("NivelDificil");
                default:
                    // Manejar un caso no reconocido, tal vez redirigir a una página de error
                    return RedirectToAction("Index");
            }
        }
    }
}