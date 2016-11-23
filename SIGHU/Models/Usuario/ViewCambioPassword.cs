using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SIGHU.Models.Usuario
{
    public class ViewCambioPassword
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage="Debe ingresar un password")]
        [Compare("ConfPassword", ErrorMessage="Los password no coinciden verifique")]
        public string Password { get; set; }

        [Required(ErrorMessage="Debe confirmar el password")]
        public string ConfPassword { get; set; }
    }
}