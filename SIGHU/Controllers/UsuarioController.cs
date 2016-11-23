using SIGHU.Models;
using SIGHU.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class UsuarioController : Controller
    {
        MENU menu = new MENU();
        USUARIO usuario = new USUARIO();
        PERSONA persona = new PERSONA();
        PERFILES perfil = new PERFILES();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {

            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
            ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
            return View( usuario.listarUsuarios() );
        }

        public ActionResult NuevoUsuario()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {

            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
            ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
            ViewBag.Personas = persona.ddPersonas();
            ViewBag.Perfiles = perfil.ddPerfiles();
            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario(ViewUsuario vUsuario)
        {
            if (ModelState.IsValid == true)
            {
                usuario.LoginUsuario = vUsuario.Usuario;
                usuario.PasswordUsuario = vUsuario.Password;
                usuario.IdPersona = vUsuario.Persona;
                usuario.IdPerfil = vUsuario.Perfil;
                usuario.creaUsuario();
                persona.asignaUsuario(Convert.ToInt16(vUsuario.Persona));

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                ViewBag.Personas = persona.ddPersonas();
                ViewBag.Perfiles = perfil.ddPerfiles();
                return View();
            }
        }

        public ActionResult desUsuario(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {

            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
            usuario.desactivaUsuario(id);

            return RedirectToAction("Index");
        }

        public ActionResult actUsuario(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {

            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
            usuario.activaUsuario(id);

            return RedirectToAction("Index");
        }

        public ActionResult cambiaPassword(int id)
        {
            ViewBag.IdUsuario = id;
            return View();
        }

        [HttpPost]
        public ActionResult cambiaPassword(ViewCambioPassword vcmbPassword)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                if (ModelState.IsValid == true)
                {
                    usuario.cambiaPassword(vcmbPassword.IdUsuario, vcmbPassword.Password);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }
    }
}
