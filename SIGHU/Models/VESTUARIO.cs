namespace SIGHU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("VESTUARIO")]
    public partial class VESTUARIO
    {
        public VESTUARIO()
        {
            PERSONA_HAS_CARGO = new List<PERSONA_HAS_CARGO>();
        }

        [Key]
        public int IdVestuario { get; set; }

        [Required(ErrorMessage="Debe indicar un nombre para el vestuario")]
        public string NVestuario { get; set; }

        [Required(ErrorMessage = "Debe indicar la talla de la gorra")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "La talla de la gorra debe ser númerica")]
        public int TGorra { get; set; }

        [Required(ErrorMessage = "Debe indicar la talla de la camisa")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "La talla de la camisa debe ser númerica")]
        public int TCamisa { get; set; }

        [Required(ErrorMessage = "Debe indicar la talla del pantalon")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "La talla del pantalon debe ser númerica")]
        public int TPantalon { get; set; }

        [Required(ErrorMessage = "Debe indicar la talla de la chaqueta")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "La talla de la chaqueta debe ser númerica")]
        public int TChaqueta { get; set; }

        [Required(ErrorMessage = "Debe indicar la talla de los zapatos")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "La talla de los zapatos debe ser númerica")]
        public int TZapatos { get; set; }

        public virtual ICollection<PERSONA_HAS_CARGO> PERSONA_HAS_CARGO { get; set; }

        public List<VESTUARIO> listarVestuario()
        {
            List<VESTUARIO> lstVestuario = new List<VESTUARIO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstVestuario = context.VESTUARIO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstVestuario;
        }

        public List<VESTUARIO> ddVestuario()
        {
            List<VESTUARIO> lstVestuario = new List<VESTUARIO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstVestuario = context.VESTUARIO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstVestuario;
        }

        public VESTUARIO traeVestuario(int id)
        {
            VESTUARIO vestuario = new VESTUARIO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    vestuario = context.VESTUARIO.Where(v => v.IdVestuario == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return vestuario;
        }

        public void creaVestuario()
        {
            try
            {
                using(var context = new SIGHUContext())
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

        public void editaVestuario()
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
    }
}
