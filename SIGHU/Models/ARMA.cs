namespace SIGHU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("ARMA")]
    public partial class ARMA
    {
        public ARMA()
        {
            PERSONA_HAS_CARGO = new List<PERSONA_HAS_CARGO>();
        }

        [Key]
        public int IdArma { get; set; }

        [Required(ErrorMessage="Debe ingresar el tipo de arma")]
        [StringLength(50)]
        public string TipoArma { get; set; }

        [Required(ErrorMessage = "Debe ingresar el serial del arma")]
        [StringLength(50)]
        public string SerieArma { get; set; }

        [Required(ErrorMessage = "Debe ingresar la marca del arma")]
        [StringLength(100)]
        public string MarcaArma { get; set; }

        public virtual ICollection<PERSONA_HAS_CARGO> PERSONA_HAS_CARGO { get; set; }

        public List<ARMA> listarArmas()
        {
            List<ARMA> lstArmas = new List<ARMA>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstArmas = context.ARMA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstArmas;
        }

        public List<ARMA> ddArmas()
        {
            List<ARMA> lstArmas = new List<ARMA>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstArmas = context.ARMA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstArmas;
        }

        public void crearArma()
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

        public void editaArma()
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

        public ARMA traeArma(int id)
        {
            ARMA arma = new ARMA();

            try
            {
                using (var context = new SIGHUContext())
                {
                    arma = context.ARMA.Where(a => a.IdArma == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return arma;
        }
    }
}
