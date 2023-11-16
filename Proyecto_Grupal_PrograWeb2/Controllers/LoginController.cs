using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Grupal_PrograWeb2.Models;

namespace Proyecto_Grupal_PrograWeb2.Controllers
{
    public class LoginController : Controller
    {
        private usuario objUsuario = new usuario();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string Usuario, string Password)
        {
            var rm = objUsuario.ValidarLogin(Usuario, Password);
            if (rm.response)
            {
                rm.href = Url.Content("/Home/Index2.cshtml");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}