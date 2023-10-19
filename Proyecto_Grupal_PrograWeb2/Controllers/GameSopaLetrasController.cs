using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class GameSopaLetrasController : Controller
    {
        // GET: GameSopaLetras
        public ActionResult Index()
        {
            string[] palabras = { "LEON", "MONO", "GATO", "PERRO", "ELEFANTE" };
            List<string[]> letrasSeparadas = new List<string[]>();
            Random random = new Random();
            HashSet<Tuple<int, int>> posicionesOcupadas = new HashSet<Tuple<int, int>>();

            for (int i = 0; i < 10; i++)
            {
                letrasSeparadas.Add(new string[10]);
            }

            foreach (var palabra in palabras)
            {
                int fila, columna, direccion;

                do
                {
                    fila = random.Next(10);
                    columna = random.Next(10);
                    direccion = random.Next(3);
                } while (!EsPosicionValida(letrasSeparadas, palabra, fila, columna, direccion));

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
            for (int fila = 0; fila < 10; fila++)
            {
                for (int columna = 0; columna < 10; columna++)
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

        private bool EsPosicionValida(List<string[]> letrasSeparadas, string palabra, int fila, int columna, int direccion)
        {
            string[] letras = palabra.Select(c => c.ToString()).ToArray();
            int tamaño = letras.Length;

            if (direccion == 0) // horizontal
            {
                if (columna + tamaño > 10) return false;

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
                if (fila + tamaño > 10) return false;

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
                if (fila + tamaño > 10 || columna + tamaño > 10) return false;

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
    }
}