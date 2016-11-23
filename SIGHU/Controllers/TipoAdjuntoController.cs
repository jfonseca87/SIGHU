using SIGHU.Models;
using SIGHU.Models.TipoAdjunto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class TipoAdjuntoController : Controller
    {
        MENU menu = new MENU();
        GRUPO_ADJUNTO grupo = new GRUPO_ADJUNTO();
        TIPO_ADJUNTO tipo = new TIPO_ADJUNTO();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(tipo.listarTipoAdjuntos());
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult NuevoTipoAdjunto()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                ViewBag.Grupos = grupo.ddGrupos();
                return View();
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult NuevoTipoAdjunto(ViewTipoAdjunto vTipoAdjunto)
        {
            if (ModelState.IsValid == true)
            {
                tipo.CodTitulo = vTipoAdjunto.CodTitulo;
                tipo.Nombre = vTipoAdjunto.Nombre;
                tipo.Activo = 1;
                tipo.IdGrupo = vTipoAdjunto.grupoAdjunto;

                tipo.creaTipoAdjunto();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult EditaTipoAdjunto(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                ViewBag.Grupos = grupo.ddGrupos();
                return View(tipo.traeTipoAdjunto(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaTipoAdjunto(ViewTipoAdjunto vTipoAdjunto)
        {
            if (ModelState.IsValid == true)
            {
                tipo.IdTAdjunto = vTipoAdjunto.IdTipo;
                tipo.CodTitulo = vTipoAdjunto.CodTitulo;
                tipo.Nombre = vTipoAdjunto.Nombre;
                tipo.Activo = 1;
                tipo.IdGrupo = vTipoAdjunto.grupoAdjunto;

                tipo.editaTipoAdjunto();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult ActTipoAdjunto(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                tipo.actTipoAdjunto(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult DesTipoAdjunto(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                tipo.desTipoAdjunto(id);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }
    }
}
