namespace SIGHU.Models
{
    using SIGHU.Models.Persona;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("PERSONA")]
    public partial class PERSONA
    {
        public PERSONA()
        {
            ADJUNTOS = new List<ADJUNTOS>();
            PERSONA_HAS_CARGO = new List<PERSONA_HAS_CARGO>();
            USUARIO = new List<USUARIO>();
        }

        [Key]
        public int IdPersona { get; set; }

        [Required(ErrorMessage="Debe ingresar los nombres de la persona")]
        [StringLength(50, ErrorMessage = "Los nombres no pueden sobrepasar los 50 caracteres")]
        public string NombreP { get; set; }

        [Required(ErrorMessage="Debe ingresar los apellidos de la persona")]
        [StringLength(50, ErrorMessage = "Los apellidos no pueden sobrepasar los 50 caracteres")]
        public string ApellidoP { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el tipo de documento")]
        [StringLength(2)]
        public string TipoDoc { get; set; }

        [Required(ErrorMessage = "Debe ingresar el número de documento de la persona")]
        [StringLength(15, ErrorMessage = "El número no puede sobrepasar los 15 caracteres")]
        public string NumeroDoc { get; set; }

        [Required(ErrorMessage = "Debe ingresar la dirección donde reside la persona")]
        [StringLength(100, ErrorMessage = "La dirección no puede sobrepasar los 100 caracteres")]
        public string Direccion { get; set; }

        [StringLength(10, ErrorMessage = "El número telefónico no puede exceder los 10 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el genero de la persona")]
        [StringLength(1)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Debe ingresar el número celular de la persona")]
        [StringLength(15, ErrorMessage = "Se permiten máximo 15 caracteres en el numero movil")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Debe ingresar el correo eletrónico de la persona")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail no es valido")]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required(ErrorMessage="Debe ingresar la edad de la persona")]
        public int Edad { get; set; }

        [StringLength(50, ErrorMessage = "Se permite máximo 50 caracteres para este campo")]
        public string LugarNac { get; set; }

        [StringLength(10, ErrorMessage = "Se permite máximo 10 caracteres para este campo")]
        public string EstadoCivil { get; set; }

        [StringLength(20, ErrorMessage = "Se permite máximo 20 caracteres para este campo")]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el RH")]
        [StringLength(3)]
        public string RH { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el nivel académico de la persona")]
        [StringLength(20)]
        public string NivelAcademico { get; set; }

        public string FotoPerfil { get; set; }

        public int UsuarioAsig { get; set; }

        public virtual ICollection<ADJUNTOS> ADJUNTOS { get; set; }

        public virtual ICollection<PERSONA_HAS_CARGO> PERSONA_HAS_CARGO { get; set; }

        public virtual ICollection<USUARIO> USUARIO { get; set; }

        public List<PERSONA> listarPersonas()
        {
            List<PERSONA> lstPersonas = new List<PERSONA>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstPersonas = context.PERSONA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstPersonas;
        }

        public List<ddPersona> ddPersonas()
        {
            List<ddPersona> lstPersonas = new List<ddPersona>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstPersonas = (from p in context.PERSONA
                                   where p.UsuarioAsig == 0
                                   select new ddPersona
                                   {
                                       IdPersona = p.IdPersona,
                                       Nombres = p.NombreP + " " + p.ApellidoP
                                   }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstPersonas;
        }

        public List<ddPersona> ddPersonasContrato()
        {
            List<ddPersona> lstPersonas = new List<ddPersona>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstPersonas = (from p in context.PERSONA
                                   select new ddPersona
                                   {
                                       IdPersona = p.IdPersona,
                                       Nombres = p.NombreP + " " + p.ApellidoP
                                   }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstPersonas;
        }

        public void creaPersona()
        {
            try
            {
                using (var context = new SIGHUContext())
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void editaPersona()
        {
            try
            {
                using (var context = new SIGHUContext())
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PERSONA traePersona(int id)
        {
            PERSONA persona = new PERSONA();

            try
            {
                using (var context = new SIGHUContext())
                {
                    persona = context.PERSONA.Where(p => p.IdPersona == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return persona;
        }

        public void asignaUsuario(int id)
        {
            PERSONA persona = new PERSONA();

            try
            {
                using (var context = new SIGHUContext())
                {
                    persona = (from p in context.PERSONA
                               where p.IdPersona == id
                               select p).FirstOrDefault();

                    persona.UsuarioAsig = 1;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void cambiaFoto(int id, string Foto)
        {
            PERSONA persona = new PERSONA();

            try
            {
                using (var context = new SIGHUContext())
                {
                    persona = (from p in context.PERSONA
                               where p.IdPersona == id
                               select p).FirstOrDefault();

                    persona.FotoPerfil = Foto;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
