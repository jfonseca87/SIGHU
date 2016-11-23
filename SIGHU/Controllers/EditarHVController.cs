using SIGHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGHU.Controllers
{
    public class EditarHVController : Controller
    {
        USUARIO usuario = new USUARIO();

        public ActionResult Index()
        {
            int idPersona = usuario.traeIdPersona(Convert.ToInt16(Session["IdUsuario"]));
            return RedirectToAction("EditaPersona", "Persona", new { @id = idPersona });
        }

    }
}
