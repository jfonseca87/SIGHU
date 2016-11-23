using SIGHU.Models;
using SIGHU.Models.Home;
using SIGHU.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class HomeController : Controller
    {
        USUARIO usuario = new USUARIO();
        UsuarioMostrar UsuarioMos = new UsuarioMostrar();
        MENU menu = new MENU();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Indexaf()
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Ingresar(ViewIngresar ingresar)
        {

            if (ModelState.IsValid == true)
            {
                UsuarioMos = usuario.Ingresar(ingresar.Usuario, ingresar.Password);

                if (UsuarioMos != null)
                {
                    Session["IdUsuario"] = UsuarioMos.IdUsuario;
                    Session["NomMostrar"] = UsuarioMos.NombresMostrar;
                    Session["IdPerfil"] = UsuarioMos.IdPerfil;
                    Session["Perfil"] = UsuarioMos.Perfil;
                    Session["FotoPerfil"] = UsuarioMos.FotoPerfil;
                    Session["Ruta"] = "http://localhost:52963/assets/images/userimages/";
                    Session["Rutac"] = "http://localhost:52963";

                    return RedirectToAction("Indexaf");
                }
                else
                {
                    ViewBag.Mensaje = "Usuario y/o Password incorrectos";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult cambiaPassword(int id)
        {
            ViewBag.IdUsuario = id;
            return View();
        }

        [HttpPost]
        public ActionResult cambiaPassword(ViewCambioPassword vcmbPassword)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid == true)
                {
                    usuario.cambiaPassword(vcmbPassword.IdUsuario, vcmbPassword.Password);

                    return RedirectToAction("Indexaf");
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

        public ActionResult Salir()
        {
            Session["IdUsuario"] = null;
            Session["NomMostrar"] = null;
            Session["IdPerfil"] = null;
            Session["Perfil"] = null;
            Session["FotoPerfil"] = null;
            Session["Ruta"] = null;
            Session["Rutac"] = null;

            return RedirectToAction("Index", "Home");
        }

    }
}
