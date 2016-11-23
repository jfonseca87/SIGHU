using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGHU.Models.Home
{
    public class UsuarioMostrar
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string NombresMostrar { get; set; }
        public int? IdPerfil { get; set; }
        public string Perfil { get; set; }
        public string FotoPerfil { get; set; }
    }
}