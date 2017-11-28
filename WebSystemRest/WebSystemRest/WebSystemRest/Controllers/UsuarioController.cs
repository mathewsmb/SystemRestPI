using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSystemRest.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Usuario()
        {
            return View();
        }
        public ActionResult Contraseña()
        {
            return View();
        }
    }
}