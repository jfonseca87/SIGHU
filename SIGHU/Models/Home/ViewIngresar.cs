using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SIGHU.Models.Home
{
    public class ViewIngresar
    {
        [Required(ErrorMessage="Debe ingresar un Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage="Debe ingresar un Password")]
        public string Password { get; set; }
    }
}