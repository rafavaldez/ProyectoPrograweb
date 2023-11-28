using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Grupal_PrograWeb2.Models
{
    public class ClsCrucigrama
    {
        public char[,] Tabla { get; set; }
        public List<string> Palabras { get; set; }
    }
}