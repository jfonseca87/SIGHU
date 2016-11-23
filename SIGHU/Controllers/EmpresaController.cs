using SIGHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class EmpresaController : Controller
    {
        MENU menu = new MENU();
        EMPRESA empresa = new EMPRESA();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(empresa.listarEmpresa());
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult NuevaEmpresa()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult NuevaEmpresa(EMPRESA empresa)
        {
            if (ModelState.IsValid == true)
            {
                empresa.Activo = 1;
                empresa.creaEmpresa();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult EditaEmpresa(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(empresa.traeEmpresa(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaEmpresa(EMPRESA empresa)
        {
            if (ModelState.IsValid == true)
            {
                empresa.editaEmpresa();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult ActEmpresa(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                empresa.actEmpresa(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult DesEmpresa(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                empresa.desEmpresa(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }
    }
}
