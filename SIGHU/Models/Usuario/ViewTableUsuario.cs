using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGHU.Models.Usuario
{
    public class ViewTableUsuario
    {
        public int IdUsuario { get; set; }
        public string NumDoc { get; set; }
        public string Nombres { get; set; }
        public string Usuario { get; set; }
        public int Activo { get; set; }
    }
}