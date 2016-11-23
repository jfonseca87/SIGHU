using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SIGHU.Models.Adjunto
{
    public class ViewNuevoAdjunto
    {
        
        public int IdPersona { get; set; }
        
        [Required(ErrorMessage="Debe seleccionar un tipo de adjunto")]
        public string IdTipoAdjunto { get; set; }

        [Required(ErrorMessage="Debe adjuntar un archivo")]
        public string RutaAdjunto { get; set; }

    }
}