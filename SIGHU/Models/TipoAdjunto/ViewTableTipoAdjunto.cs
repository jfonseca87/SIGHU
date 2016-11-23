using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGHU.Models.TipoAdjunto
{
    public class ViewTableTipoAdjunto
    {
        public int IdTAdjunto { get; set; }
        public string CodTitulo { get; set; }
        public string Nombre { get; set; }
        public int Activo { get; set; }
        public string Grupo { get; set; }
    }
}