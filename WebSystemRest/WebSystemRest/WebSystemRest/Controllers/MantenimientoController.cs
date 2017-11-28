using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSystemRest.Entidades;
using System.Data;
using System.Data.SqlClient;
using WebSystemRest.Models;

namespace WebSystemRest.Controllers
{
    public class MantenimientoController : Controller
    {
        SqlConnection cn = new SqlConnection("server=.;database=BD_Belaa; uid= sa;pwd=sql");
        Metodos metodo = new Metodos();
        BD_BelaaEntities bd = new BD_BelaaEntities();
        tb_plato plato = new tb_plato();

        // GET: Mantenimiento
        public ActionResult Ingredientes()
        {
            return View();
        }

        public ActionResult Menus()
        {
            return View(metodo.ListarMenu());
        }

        public ActionResult ListarPlatos()
        {
            return View(metodo.ListarPlatos());
        }

        public ActionResult RegistrarPlatos(string cli)
        {
            ViewBag.tipos = new SelectList(bd.tb_tipo.ToList(), "id_tipo", "desc_tipo", cli);
            ViewBag.cli = cli;
            return View(new tb_plato());
        }
        [HttpPost] public ActionResult RegistrarPlatos(tb_plato reg)
        {
            string msg = metodo.RegistrarPlato(reg);
            return RedirectToAction("ListarPlatos");
        }

        public ActionResult Recetas()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(logueo user)
        {
            using (BD_BelaaEntities bd = new BD_BelaaEntities())
            {
                var usr = bd.logueo.Where(u => u.usuario == user.usuario && u.clave == user.clave).FirstOrDefault();
                if (usr != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrecta.");
                }
                return View();
            }
        }
    }
}