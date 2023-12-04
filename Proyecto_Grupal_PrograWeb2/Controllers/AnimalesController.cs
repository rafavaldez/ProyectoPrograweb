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
    public class AnimalesController : Controller
    {
        private usuario objUsuario = new usuario();
        private IMongoCollection<BsonDocument> preguntasCollection;
        // GET: Animales
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

        public ActionResult About(string id)
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("apianimales");
            preguntasCollection = database.GetCollection<BsonDocument>("animales");

            // ID específico que deseas buscar
            string targetId = id;

            // Construir un filtro para encontrar documentos con el ID específico
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(targetId));

            // Obtener documentos que coinciden con el filtro
            var filteredDocuments = preguntasCollection.Find(filter).ToList();

            // Convertir ObjectId a cadena
            filteredDocuments.ForEach(doc => doc["_id"] = doc["_id"].ToString());

            // Serializar a JSON con opciones de formato
            var jsonString = HttpUtility.JavaScriptStringEncode(filteredDocuments.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));

            ViewBag.JsonData = jsonString;

            // Puedes realizar operaciones con el ID aquí, como obtener detalles del animal desde la base de datos.
            // En este ejemplo, simplemente lo pasaremos a la vista.
            ViewBag.AnimalId = id;

            return View();
        }
        public ActionResult About2(string id)
        {
            const string connectionUri = "mongodb://usuario:usuario@ac-svtdsgs-shard-00-00.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-01.ovcij6h.mongodb.net:27017,ac-svtdsgs-shard-00-02.ovcij6h.mongodb.net:27017/?ssl=true&replicaSet=atlas-zjq6ae-shard-0&authSource=admin&retryWrites=true&w=majority";
            var client = new MongoClient(connectionUri);

            var database = client.GetDatabase("apianimales");
            preguntasCollection = database.GetCollection<BsonDocument>("animales");

            // ID específico que deseas buscar
            string targetId = id;

            // Construir un filtro para encontrar documentos con el ID específico
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(targetId));

            // Obtener documentos que coinciden con el filtro
            var filteredDocuments = preguntasCollection.Find(filter).ToList();

            // Convertir ObjectId a cadena
            filteredDocuments.ForEach(doc => doc["_id"] = doc["_id"].ToString());

            // Serializar a JSON con opciones de formato
            var jsonString = HttpUtility.JavaScriptStringEncode(filteredDocuments.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));

            ViewBag.JsonData = jsonString;

            // Puedes realizar operaciones con el ID aquí, como obtener detalles del animal desde la base de datos.
            // En este ejemplo, simplemente lo pasaremos a la vista.
            ViewBag.AnimalId = id;

            return View();
        }


    }
}