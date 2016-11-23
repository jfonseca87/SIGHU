using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Net;
using System.Web.Mvc;

namespace SIGHU.Helpers
{
    public class UDFile
    {
        public void cargarAdjunto(int id, HttpPostedFileBase file)
        {
            string DirRelativo = HttpContext.Current.Server.MapPath("~/Adjuntos");
            string DirUsuario = id.ToString();
            string archivo = file.FileName.ToLower();
            string rutaFull = "";

            if (!Directory.Exists(DirRelativo + "/" + DirUsuario))
            {
                Directory.CreateDirectory(DirRelativo + "/" + DirUsuario);
            }

            rutaFull = DirRelativo + "/" + DirUsuario + "/" + archivo;

            if (!Directory.Exists(rutaFull))
            {
                file.SaveAs(rutaFull);
            }
        }

        public void cargarImagen(HttpPostedFileBase file)
        {
            string DirRelativo = HttpContext.Current.Server.MapPath("~/Assets/Images/UserImages");
            string archivo = file.FileName.ToLower();
            string rutaFull = "";

            rutaFull = DirRelativo + "/" + archivo;

            if (!Directory.Exists(rutaFull))
            {
                file.SaveAs(rutaFull);
            }
        }

    }
}