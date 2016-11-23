using SIGHU.Models;
using SIGHU.Models.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class ContratoController : Controller
    {
        MENU menu = new MENU();
        PERSONA_HAS_CARGO phc = new PERSONA_HAS_CARGO();
        PERSONA persona = new PERSONA();
        CARGO cargo = new CARGO();
        ARMA arma = new ARMA();
        VESTUARIO vestuario = new VESTUARIO();
        VEHICULO vehiculo = new VEHICULO();
        EMPRESA empresa = new EMPRESA();
        ViewContratos contrato = new ViewContratos();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View(phc.listarContratos());
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        public ActionResult NuevoContrato()
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                ViewBag.Personas = persona.ddPersonasContrato();
                ViewBag.Cargos = cargo.ddCargos();
                ViewBag.Armas = arma.ddArmas();
                ViewBag.Vestuario = vestuario.ddVestuario();
                ViewBag.Vehiculos = vehiculo.ddVehiculos();
                ViewBag.Empresa = empresa.ddEmpresas();
                return View();
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult NuevoContrato(ViewContratos contrato)
        {
            if (ModelState.IsValid == true)
            {
                phc.IdPersona = contrato.IdPersona;
                phc.IdCargo = contrato.IdCargo;
                phc.IdArma = contrato.IdArma;
                phc.IdVestuario = contrato.IdVestuario;
                phc.IdVehiculo = contrato.IdVehiculo;
                phc.IdEmpresa = contrato.IdEmpresa;
                phc.AniosExpLab = contrato.AniosExpLab;
                if (contrato.Actual == true)
                {
                    phc.actual = 1;
                }
                phc.creaContrato();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                return View();
            }
        }

        public ActionResult EditaContrato(int id)
        {
            if (Session["IdUsuario"] != null && Convert.ToInt16(Session["IdPerfil"]) == 1)
            {
                ViewBag.MenuPage = menu.listarMenu(Convert.ToInt16(Session["IdPerfil"]));
                ViewBag.Personas = persona.ddPersonasContrato();
                ViewBag.Cargos = cargo.ddCargos();
                ViewBag.Armas = arma.ddArmas();
                ViewBag.Vestuario = vestuario.ddVestuario();
                ViewBag.Vehiculos = vehiculo.ddVehiculos();
                ViewBag.Empresa = empresa.ddEmpresas();
                return View(phc.traeContrato(id));
            }
            else
            {
                return RedirectToAction("Indexaf", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditaContrato(ViewContratos contrato)
        {
            if (ModelState.IsValid == true)
            {
                phc.IdPersonaHasCargo = Convert.ToInt16(contrato.IdContrato);
                phc.IdPersona = contrato.IdPersona;
                phc.IdCargo = contrato.IdCargo;
                phc.IdArma = contrato.IdArma;
                phc.IdVestuario = contrato.IdVestuario;
                phc.IdVehiculo = contrato.IdVehiculo;
                phc.IdEmpresa = contrato.IdEmpresa;
                phc.AniosExpLab = contrato.AniosExpLab;
                if (contrato.Actual == true)
                {
                    phc.actual = 1;
                }
                phc.EditaContrato();

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
