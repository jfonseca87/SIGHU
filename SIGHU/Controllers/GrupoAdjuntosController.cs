using SIGHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class GrupoAdjuntosController : Controller
    {
        MENU menu = new MENU();
        GRUPO_ADJUNTO grupo = new GRUPO_ADJUNTO();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(grupo.listarGrupos());
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult NuevoGrupo()
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
        public ActionResult NuevoGrupo(GRUPO_ADJUNTO grupo)
        {
            if (ModelState.IsValid == true)
            {
                grupo.Activo = 1;
                grupo.crearGrupo();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult EditaGrupo(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(grupo.traeGrupo(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaGrupo(GRUPO_ADJUNTO grupo)
        {
            if (ModelState.IsValid == true)
            {
                grupo.editarGrupo();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult ActGrupo(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                grupo.ActGrupo(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult DesGrupo(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                grupo.desGrupo(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }
    }
}
