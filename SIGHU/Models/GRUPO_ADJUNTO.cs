namespace SIGHU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class GRUPO_ADJUNTO
    {
        public GRUPO_ADJUNTO()
        {
            TIPO_ADJUNTO = new List<TIPO_ADJUNTO>();
        }

        [Key]
        public int IdGrupo { get; set; }

        [Required(ErrorMessage="Debe ingresar un nombre para el grupo")]
        [StringLength(50, ErrorMessage="No puede superar los 50 caracteres")]
        public string NombreGrupo { get; set; }

        public int Activo { get; set; }

        public virtual ICollection<TIPO_ADJUNTO> TIPO_ADJUNTO { get; set; }

        public List<GRUPO_ADJUNTO> listarGrupos()
        {
            List<GRUPO_ADJUNTO> lstGrupos = new List<GRUPO_ADJUNTO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstGrupos = context.GRUPO_ADJUNTO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstGrupos;
        }

        public List<GRUPO_ADJUNTO> ddGrupos()
        {
            List<GRUPO_ADJUNTO> lstGrupos = new List<GRUPO_ADJUNTO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstGrupos = context.GRUPO_ADJUNTO.Where(g => g.Activo == 1).OrderBy(g => g.NombreGrupo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstGrupos;
        }

        public void crearGrupo()
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

        public void editarGrupo()
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

        public GRUPO_ADJUNTO traeGrupo(int id)
        {
            GRUPO_ADJUNTO grupo = new GRUPO_ADJUNTO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    grupo = (from g in context.GRUPO_ADJUNTO
                             where g.IdGrupo == id
                             select g).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return grupo;
        }

        public void ActGrupo(int id)
        {
            GRUPO_ADJUNTO grupo = new GRUPO_ADJUNTO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    grupo = (from g in context.GRUPO_ADJUNTO
                             where g.IdGrupo == id
                             select g).FirstOrDefault();

                    grupo.Activo = 1;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void desGrupo(int id)
        {
            GRUPO_ADJUNTO grupo = new GRUPO_ADJUNTO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    grupo = (from g in context.GRUPO_ADJUNTO
                             where g.IdGrupo == id
                             select g).FirstOrDefault();

                    grupo.Activo = 0;

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
