using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SIGHU.Models.Persona
{
    public class cambiarFoto
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage="Debe seleccionar una imagen")]
        public string RImagen { get; set; }
    }
}