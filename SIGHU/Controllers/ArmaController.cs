using SIGHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class ArmaController : Controller
    {
        MENU menu = new MENU();
        ARMA arma = new ARMA();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(arma.listarArmas());
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult NuevaArma()
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
        public ActionResult NuevaArma(ARMA arma)
        {
            if (ModelState.IsValid == true)
            {
                arma.crearArma();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult EditaArma(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(arma.traeArma(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaArma(ARMA arma)
        {
            if (ModelState.IsValid == true)
            {
                arma.editaArma();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }
    }
}
