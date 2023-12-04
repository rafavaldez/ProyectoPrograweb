using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Grupal_PrograWeb2.Models;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class UsuarioController : Controller
    {
        private usuario objUsuario = new usuario();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(objUsuario.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(objUsuario.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            //ViewBag.Empleado = objEmpleado.Listar();
            return View(
                id == 0 ? new usuario() // Nuevo objeto
                : objUsuario.Obtener(id) // Devuelve el objeto encontrado
                );
        }

        public ActionResult Guardar(usuario objAdmin)
        {
            if (ModelState.IsValid)
            {
                objUsuario.Guardar();
                return Redirect("~/USUARIO");
            }
            else
            {
                return View("~/Views/USUARIO/AgregarEditar.cshtml", objAdmin);
            }
        }

        public ActionResult ELiminar(int id)
        {
            //objUsuario.IDEMPLEADO = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}