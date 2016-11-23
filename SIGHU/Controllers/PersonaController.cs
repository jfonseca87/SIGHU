using SIGHU.Helpers;
using SIGHU.Models;
using SIGHU.Models.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class PersonaController : Controller
    {
        MENU menu = new MENU();
        PERSONA persona = new PERSONA();
        ADJUNTOS adjunto = new ADJUNTOS();
        USUARIO usuario = new USUARIO();
        UDFile file = new UDFile();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(persona.listarPersonas());
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult NuevaPersona()
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
        public ActionResult NuevaPersona(PERSONA persona)
        {
            if (ModelState.IsValid == true)
            {
                persona.FotoPerfil = "Usuario.png";
                persona.creaPersona();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult EditaPersona(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                ViewBag.Adjuntos = adjunto.listarAdjuntos(id);
                return View(persona.traePersona(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaPersona(PERSONA persona)
        {
            if (ModelState.IsValid == true)
            {
                persona.editaPersona();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult VerPersona(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(persona.traePersona(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult CambiaFoto(int id)
        {
            ViewBag.IdPersona = id;
            return View();
        }

        [HttpPost]
        public ActionResult CambiaFoto(cambiarFoto cmbFoto, HttpPostedFileBase RImagen)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid == true)
                {
                    int IdPersona = usuario.traeIdPersona(cmbFoto.IdUsuario);
                    string Imagen = RImagen.FileName.ToLower();

                    persona.cambiaFoto(IdPersona, Imagen);
                    file.cargarImagen(RImagen);
                    Session["FotoPerfil"] = Imagen;

                    return RedirectToAction("Indexaf", "Home");

                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
