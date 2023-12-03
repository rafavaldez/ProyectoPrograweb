using Proyecto_Grupal_PrograWeb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class AdminController : Controller
    {
        private admin objAdmin = new admin();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(objAdmin.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(objAdmin.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            //ViewBag.Empleado = objEmpleado.Listar();
            return View(
                id == 0 ? new admin() // Nuevo objeto
                : objAdmin.Obtener(id) // Devuelve el objeto encontrado
                );
        }

        public ActionResult Guardar(admin objAdmin)
        {
            if (ModelState.IsValid)
            {
                objAdmin.Guardar();
                return Redirect("~/ADMIN");
            }
            else
            {
                return View("~/Views/ADMIN/AgregarEditar.cshtml", objAdmin);
            }
        }

        public ActionResult ELiminar(int id)
        {
            //objUsuario.IDEMPLEADO = id;
            objAdmin.Eliminar();
            return Redirect("~/Admin");
        }
    }
}