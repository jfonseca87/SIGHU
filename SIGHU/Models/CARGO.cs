namespace SIGHU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("CARGO")]
    public partial class CARGO
    {
        public CARGO()
        {
            PERSONA_HAS_CARGO = new List<PERSONA_HAS_CARGO>();
        }

        [Key]
        public int IdCargo { get; set; }

        [Required(ErrorMessage="Debe ingresar el nombre del cargo")]
        [StringLength(100, ErrorMessage="No puede exceder los 100 caraceteres")]
        public string NombreC { get; set; }

        public int Activo { get; set; }

        public virtual ICollection<PERSONA_HAS_CARGO> PERSONA_HAS_CARGO { get; set; }

        public List<CARGO> listarCargos()
        {
            List<CARGO> lstCargo = new List<CARGO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstCargo = context.CARGO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstCargo;
        }

        public List<CARGO> ddCargos()
        {
            List<CARGO> lstCargos = new List<CARGO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstCargos = context.CARGO.Where(c => c.Activo == 1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstCargos;
        }

        public void crearCargo()
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

        public void editaCargo()
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

        public void desactivaCargo(int id)
        {
            CARGO cargo = new CARGO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    cargo = (from c in context.CARGO
                             where c.IdCargo == id
                             select c).FirstOrDefault();

                    cargo.Activo = 0;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void activaCargo(int id)
        {
            CARGO cargo = new CARGO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    cargo = (from c in context.CARGO
                             where c.IdCargo == id
                             select c).FirstOrDefault();

                    cargo.Activo = 1;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CARGO traeCargo(int id)
        {
            CARGO cargo = new CARGO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    cargo = (from c in context.CARGO
                             where c.IdCargo == id
                             select c).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cargo;
        }
    }
}
