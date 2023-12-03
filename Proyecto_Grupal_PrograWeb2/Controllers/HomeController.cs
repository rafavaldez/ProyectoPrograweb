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
    public class HomeController : Controller
    {
        private usuario objUsuario = new usuario();
        private IMongoCollection<BsonDocument> preguntasCollection;
        // GET: Home
        public ActionResult Index()
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("apianimales");
            preguntasCollection = database.GetCollection<BsonDocument>("animales");

            // No hay filtro en esta versión
            var allDocuments = preguntasCollection.Find(new BsonDocument()).ToList();

            // Convertir ObjectId a cadena
            allDocuments.ForEach(doc => doc["_id"] = doc["_id"].ToString());

            // Serializar a JSON con opciones de formato
            var jsonString = HttpUtility.JavaScriptStringEncode(allDocuments.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));

            ViewBag.JsonData = jsonString;

            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }
    }
}