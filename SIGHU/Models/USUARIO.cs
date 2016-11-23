namespace SIGHU.Models
{
    using SIGHU.Models.Home;
    using SIGHU.Models.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginUsuario { get; set; }

        [Required]
        public string PasswordUsuario { get; set; }

        public int Activo { get; set; }

        public int? IdPersona { get; set; }

        public int? IdPerfil { get; set; }

        public virtual PERFILES PERFILES { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public UsuarioMostrar Ingresar(string usuario, string password)
        {
            UsuarioMostrar user = new UsuarioMostrar();

            try
            {
                using (var context = new SIGHUContext())
                {
                    user = (from u in context.USUARIO
                            where u.LoginUsuario == usuario && u.PasswordUsuario == password && u.Activo == 1
                            select new UsuarioMostrar {
                                IdUsuario = u.IdUsuario,
                                NombresMostrar = u.PERSONA.NombreP +" "+ u.PERSONA.ApellidoP,
                                IdPerfil = u.IdPerfil,
                                Perfil = u.PERFILES.Perfil,
                                FotoPerfil = u.PERSONA.FotoPerfil
                            }).FirstOrDefault();

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ViewTableUsuario> listarUsuarios()
        {
            List<ViewTableUsuario> lstUsuarios = new List<ViewTableUsuario>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstUsuarios = (from u in context.USUARIO
                                   select new ViewTableUsuario
                                   {
                                       IdUsuario = u.IdUsuario,
                                       NumDoc = u.PERSONA.NumeroDoc,
                                       Nombres = u.PERSONA.NombreP + " " + u.PERSONA.ApellidoP,
                                       Usuario = u.LoginUsuario,
                                       Activo = u.Activo
                                   }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstUsuarios;
        }

        public void creaUsuario()
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

        public void desactivaUsuario(int id)
        {
            USUARIO usuario = new USUARIO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    usuario = context.USUARIO.Where(u => u.IdUsuario == id).FirstOrDefault();

                    usuario.Activo = 0;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void activaUsuario(int id)
        {
            USUARIO usuario = new USUARIO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    usuario = context.USUARIO.Where(u => u.IdUsuario == id).FirstOrDefault();

                    usuario.Activo = 1;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void cambiaPassword(int id, string password)
        {
            USUARIO usuario = new USUARIO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    usuario = (from u in context.USUARIO
                               where u.IdUsuario == id
                               select u).FirstOrDefault();

                    usuario.PasswordUsuario = password;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int traeIdPersona(int id)
        {
            int IdPersona = 0;

            try
            {
                using (var context = new SIGHUContext())
                {
                    IdPersona = Convert.ToInt16((from u in context.USUARIO
                                                 where u.IdUsuario == id
                                                 select u.IdPersona).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return IdPersona;
        }
    }
}
