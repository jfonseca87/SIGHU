using SIGHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SIGHU.Models.Adjunto;
using SIGHU.Helpers;
using System.Text;

namespace SIGHU.Controllers
{
    public class AdjuntoController : Controller
    {
        GRUPO_ADJUNTO grupo = new GRUPO_ADJUNTO();
        TIPO_ADJUNTO tipo = new TIPO_ADJUNTO();
        ADJUNTOS adjunto = new ADJUNTOS();
        UDFile udFile = new UDFile();

        public ActionResult NuevoAdjunto(int id)
        {
            ViewBag.Grupos = grupo.ddGrupos();
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult NuevoAdjunto(ViewNuevoAdjunto vAdjunto, HttpPostedFileBase RutaAdjunto)
        {
            if (Session["IdUsuario"] != null)
            {
                vAdjunto.RutaAdjunto = RutaAdjunto.FileName.ToString();

                if (ModelState.IsValid == true)
                {
                    adjunto.IdTipoAdjunto = Convert.ToInt16(vAdjunto.IdTipoAdjunto);
                    adjunto.RutaAdjunto = vAdjunto.RutaAdjunto;
                    adjunto.IdPersona = vAdjunto.IdPersona;
                    adjunto.guardaAdjunto();
                    udFile.cargarAdjunto(vAdjunto.IdPersona, RutaAdjunto);

                    return RedirectToAction("EditaPersona", "Persona", new { @id = vAdjunto.IdPersona });
                }
                else
                {
                    ViewBag.Grupos = grupo.ddGrupos();
                    return View();
                }
            }
            else 
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public JsonResult consTipoAdjuntos(int id)
        {
            return Json(tipo.ddTipoAdjunto(id), JsonRequestBehavior.AllowGet);
        }

        public FileResult DescargaAdjunto(int id)
        {
            adjunto = adjunto.traeNomArchivo(id);

            string ruta = Server.MapPath("~\\Adjuntos\\") + adjunto.IdPersona + "\\" + adjunto.RutaAdjunto;
            byte[] fileBytes = System.IO.File.ReadAllBytes(ruta);
            string fileName = adjunto.RutaAdjunto;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult EliminaAdjunto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                adjunto = adjunto.traeNomArchivo(id);
                int idPersona = Convert.ToInt16(adjunto.IdPersona);

                adjunto.delAdjunto(id);

                return RedirectToAction("EditaPersona", "Persona", new { @id = idPersona });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}
