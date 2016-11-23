using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIGHU.Models.TipoAdjunto
{
    public class ViewTipoAdjunto
    {

        public int IdTipo { get; set; }

        [Required(ErrorMessage="Debe seleccionar un grupo")]
        public int? grupoAdjunto { get; set; }

        [Required(ErrorMessage = "Debe ingresar un código para el tipo de adjunto")]
        public string CodTitulo { get; set; }

        [Required(ErrorMessage = "Debe asignar un nombre al tipo de adjunto")]
        public string Nombre { get; set; }

    }
}