using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Grupal_PrograWeb2.Models;
using System.IO;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class PerfilController : Controller
    {
        private usuario Usuario = new usuario();

        // GET: Perfil
        public ActionResult Index()
        {
            return View(Usuario.Obtener(SessionHelper.GetUser()));
        }

        public JsonResult Actualizar(usuario model, HttpPostedFileBase Foto)
        {
            string clave = model.password;
            //string FotoOriginal = model.AVATAR;
            //string rutaFotoAnterior = HttpContext.Current.Server.MapPath("~/Uploads/" + FotoOriginal);
            //string rutaFotoAnterior = Path.Combine(Server.MapPath("~/Uploads"), FotoOriginal);
            //File.Delete(rutaFotoAnterior);
            var rm = new ResponseModel();

            ModelState.Remove("id");
            ModelState.Remove("nombre");
            ModelState.Remove("apellido");
            //ModelState.Remove("email");
            //ModelState.Remove("password");
            //ModelState.Remove("AVATAR");
            ModelState.Remove("estado");

            if (ModelState.IsValid)
            {
                rm = model.GuardarPerfil(Foto, clave);
                //ViewBag.Ruta = rutaFotoAnterior;
            }

            rm.href = Url.Content("/Home/Index2");


            return Json(rm);
        }
    }
}