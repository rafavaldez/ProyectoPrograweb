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
        private admin admin = new admin();

        // GET: Perfil
        public ActionResult Index()
        {
            return View(admin.Obtener(SessionHelper.GetUser()));
        }

        public JsonResult Actualizar(admin model, HttpPostedFileBase Foto)
        {
            string clave = model.contra;
            //string FotoOriginal = model.AVATAR;
            //string rutaFotoAnterior = HttpContext.Current.Server.MapPath("~/Uploads/" + FotoOriginal);
            //string rutaFotoAnterior = Path.Combine(Server.MapPath("~/Uploads"), FotoOriginal);
            //File.Delete(rutaFotoAnterior);
            var rm = new ResponseModel();

            ModelState.Remove("id");
            ModelState.Remove("nombre");
            ModelState.Remove("apellido");
            //ModelState.Remove("user");
            //ModelState.Remove("contra");
            //ModelState.Remove("AVATAR");
            ModelState.Remove("estado");

            if (ModelState.IsValid)
            {
                //para la clave
                model.contra = !string.IsNullOrEmpty(model.contra) ? HashHelper.MD5(model.contra) : string.Empty;

                //para la imagen
                if (Foto != null && Foto.ContentLength > 0)
                {
                    // Ruta de la imagen actual basada en el nombre actual del avatar en el modelo
                    var currentAvatarPath = Server.MapPath("~/Uploads/" + model.avatar);

                    // Construye el nuevo nombre de archivo basado en el nombre de usuario y la fecha actual
                    string currentDate = DateTime.Now.ToString("yyyyMMdd");
                    string newFileName = $"{model.avatar}_{currentDate}{Path.GetExtension(Foto.FileName)}";
                    string newAvatarPath = Path.Combine(Server.MapPath("~/Uploads"), newFileName);

                    try
                    {
                        // Si existe una imagen anterior, elimínala
                        if (!string.IsNullOrWhiteSpace(model.avatar) && System.IO.File.Exists(currentAvatarPath))
                        {
                            System.IO.File.Delete(currentAvatarPath);
                        }

                        // Guardar la nueva imagen con el nombre compuesto por el nombre de usuario y la fecha actual
                        Foto.SaveAs(newAvatarPath);

                        // Actualizar la propiedad AVATAR del modelo con el nuevo nombre de archivo
                        model.avatar = newFileName;
                    }
                    catch (Exception ex)
                    {
                        // Si hay un error, configura la respuesta como falsa y devuelve el mensaje de error
                        rm.SetResponse(false, "Error al intentar subir la imagen: " + ex.Message);
                        return Json(rm);
                    }
                }

                // Llamar al método GuardarPerfil para guardar la imagen y actualizar la base de datos
                try
                {
                    rm = model.GuardarPerfil();
                }
                catch (Exception ex)
                {
                    rm.SetResponse(false, "Error al intentar actualizar el usuario: " + ex.Message + "\n" + ex.InnerException);
                    return Json(rm);
                }
            }
            else
            {
                rm.SetResponse(false, "Datos del modelo no son válidos.");
                return Json(rm);
            }
            rm.SetResponse(true, "Perfil actualizado correctamente.");
            rm.href = Url.Content("/Home/Index2");
            return Json(rm);
        }
    }
}