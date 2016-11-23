using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SIGHU.Models.Usuario
{
    public class ViewUsuario
    {
        [Required(ErrorMessage="Debe seleccionar una persona")]
        public int Persona { get; set; }

        [Required(ErrorMessage="Debe seleccionar un perfil")]
        public int Perfil { get; set; }

        [Required(ErrorMessage="Debe ingresar un usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage="Debe ingresar un password para el usuario")]
        public string Password { get; set; }
    }
}