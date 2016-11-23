using SIGHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class CargoController : Controller
    {
        MENU menu = new MENU();
        CARGO cargo = new CARGO();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(cargo.listarCargos());
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult NuevoCargo()
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
        public ActionResult NuevoCargo(CARGO cargo)
        {
            if (ModelState.IsValid == true)
            {
                cargo.Activo = 1;
                cargo.crearCargo();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult EditaCargo(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(cargo.traeCargo(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaCargo(CARGO cargo)
        {
            if (ModelState.IsValid == true)
            {
                cargo.editaCargo();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult DesacCargo(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                cargo.desactivaCargo(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult ActCargo(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                cargo.activaCargo(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }
    }
}
