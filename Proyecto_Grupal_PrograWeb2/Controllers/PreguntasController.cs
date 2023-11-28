using MongoDB.Bson;
using MongoDB.Driver;
using Proyecto_Grupal_PrograWeb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class PreguntasController : Controller
    {
        private usuario objUsuario = new usuario();
        private IMongoCollection<BsonDocument> preguntasCollection;
        // GET: Preguntas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Facil()
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("apianimales");
            preguntasCollection = database.GetCollection<BsonDocument>("preguntas");

            var filter = Builders<BsonDocument>.Filter.Eq("difficulty", "easy");
            var mediumDifficultyDocuments = preguntasCollection.Find(filter).ToList();

            // Convertir ObjectId a cadena
            mediumDifficultyDocuments.ForEach(doc => doc["_id"] = doc["_id"].ToString());

            // Serializar a JSON con opciones de formato
            var jsonString = HttpUtility.JavaScriptStringEncode(mediumDifficultyDocuments.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));

            ViewBag.JsonData = jsonString;

            return View();
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






        public ActionResult Medio()
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("apianimales");
            preguntasCollection = database.GetCollection<BsonDocument>("preguntas");

            var filter = Builders<BsonDocument>.Filter.Eq("difficulty", "medium");
            var mediumDifficultyDocuments = preguntasCollection.Find(filter).ToList();

            // Convertir ObjectId a cadena
            mediumDifficultyDocuments.ForEach(doc => doc["_id"] = doc["_id"].ToString());

            // Serializar a JSON con opciones de formato
            var jsonString = HttpUtility.JavaScriptStringEncode(mediumDifficultyDocuments.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));

            ViewBag.JsonData = jsonString;

            return View();
        }

        public ActionResult Dificil()
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("apianimales");
            preguntasCollection = database.GetCollection<BsonDocument>("preguntas");

            var filter = Builders<BsonDocument>.Filter.Eq("difficulty", "hard");
            var mediumDifficultyDocuments = preguntasCollection.Find(filter).ToList();

            // Convertir ObjectId a cadena
            mediumDifficultyDocuments.ForEach(doc => doc["_id"] = doc["_id"].ToString());

            // Serializar a JSON con opciones de formato
            var jsonString = HttpUtility.JavaScriptStringEncode(mediumDifficultyDocuments.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));

            ViewBag.JsonData = jsonString;

            return View();
        }
    }
}