using Proyecto_Grupal_PrograWeb2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;

using MongoDB.Bson;
using System.Diagnostics;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class GameVozController : Controller
    {

        private IMongoCollection<BsonDocument> musicasCollection;
        private static string nombreCancionSeleccionada; // Variable para almacenar el nombre de la canción seleccionada

        // GET: GameVoz
        public ActionResult Index()
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            var client = new MongoClient(settings);

            // Obtén la base de datos y la colección.
            var database = client.GetDatabase("bd_web_music");
            musicasCollection = database.GetCollection<BsonDocument>("musicas");

            var filter = new BsonDocument();
            var musicas = musicasCollection.Find(filter).ToList();

            // Selecciona aleatoriamente 5 canciones
            var random = new Random();
            var cancionesAleatorias = new List<BsonDocument>();

            for (int i = 0; i < 5; i++)
            {
                int randomIndex = random.Next(0, musicas.Count);
                cancionesAleatorias.Add(musicas[randomIndex]);
                musicas.RemoveAt(randomIndex);
            }

            // Selecciona aleatoriamente una de las canciones como la canción a adivinar
            int cancionSeleccionadaIndex = random.Next(0, 5);
            var cancionSeleccionada = cancionesAleatorias[cancionSeleccionadaIndex];

            // Almacena el nombre de la canción seleccionada en la variable de clase
            nombreCancionSeleccionada = cancionSeleccionada["nombre"].AsString;

            // Almacena el nombre y el enlace de la canción seleccionada en ViewBag
            ViewBag.NombreCancionSeleccionada = cancionSeleccionada["nombre"].AsString;
            ViewBag.EnlaceCancionSeleccionada = cancionSeleccionada["link"].AsString;

            // Extrae los nombres y los enlaces de las canciones aleatorias
            var nombres = cancionesAleatorias.Select(m => m["nombre"].AsString);
            var enlaces = cancionesAleatorias.Select(m => m["link"].AsString);

            // Pasa los nombres y enlaces a la vista utilizando ViewBag
            ViewBag.Nombres = nombres.ToList();
            ViewBag.Enlaces = enlaces.ToList();

            // Inicializa el puntaje y el nivel en la sesión
            if (Session["Puntuacion"] == null)
            {
                Session["Puntuacion"] = 0;
                Session["Nivel"] = 1;
            }

            ViewBag.Puntuacion = Session["Puntuacion"];
            ViewBag.Nivel = Session["Nivel"];

            // Retorna la vista HTML
            return View();
        }



        public JsonResult ComprobarCancion(string nombre)
        {
            Debug.WriteLine("opcioncacncion: " + nombre);
            Debug.WriteLine("ganad: " + nombreCancionSeleccionada);
            bool esCorrecto = (nombreCancionSeleccionada == nombre);
            if (esCorrecto)
            {
                // Incrementa el puntaje en 20 puntos
                int puntuacion = (int)Session["Puntuacion"];
                puntuacion += 20;
                Session["Puntuacion"] = puntuacion;

                // Pasa al siguiente nivel
                int nivel = (int)Session["Nivel"];
                Session["Nivel"] = nivel + 1;
            }

            return Json(new { esCorrecto = esCorrecto });
        }

        public ActionResult JuegoVoz()
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            var client = new MongoClient(settings);

            // Obtén la base de datos y la colección.
            var database = client.GetDatabase("bd_web_music");
            musicasCollection = database.GetCollection<BsonDocument>("musicas");
            var filter = new BsonDocument();
            var musicas = musicasCollection.Find(filter).ToList();

            // Obtén 5 documentos aleatorios.
            var random = new Random();
            var randomMusicas = new List<BsonDocument>();
            for (int i = 0; i < 5; i++)
            {
                var randomIndex = random.Next(0, musicas.Count);
                randomMusicas.Add(musicas[randomIndex]);
                musicas.RemoveAt(randomIndex);
            }

            return View(randomMusicas);

        }




    }
}