namespace SIGHU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("EMPRESA")]
    public partial class EMPRESA
    {
        public EMPRESA()
        {
            PERSONA_HAS_CARGO = new List<PERSONA_HAS_CARGO>();
        }

        [Key]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage="Debe ingresar el NIT de la empresa")]
        [StringLength(12, ErrorMessage="El NIT no supera los 12 caracteres")]
        public string NIT { get; set; }

        [Required(ErrorMessage="Debe ingresar el nombre de la empresa")]
        [StringLength(100, ErrorMessage="El nombre no puede superar los 100 caracteres")]
        public string NombreEmpresa { get; set; }

        public int Activo { get; set; }

        public virtual ICollection<PERSONA_HAS_CARGO> PERSONA_HAS_CARGO { get; set; }

        public List<EMPRESA> listarEmpresa()
        {
            List<EMPRESA> lstEmpresa = new List<EMPRESA>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstEmpresa = context.EMPRESA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstEmpresa;
        }

        public List<EMPRESA> ddEmpresas()
        {
            List<EMPRESA> lstEmpresas = new List<EMPRESA>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstEmpresas = context.EMPRESA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstEmpresas;
        }

        public void creaEmpresa()
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

        public void editaEmpresa()
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

        public EMPRESA traeEmpresa(int id)
        {
            EMPRESA empresa = new EMPRESA();

            try
            {
                using (var context = new SIGHUContext())
                {
                    empresa = (from e in context.EMPRESA
                               where e.IdEmpresa == id
                               select e).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return empresa;
        }

        public void actEmpresa(int id)
        {
            EMPRESA empresa = new EMPRESA();

            try
            {
                using (var context = new SIGHUContext())
                {
                    empresa = (from e in context.EMPRESA
                               where e.IdEmpresa == id
                               select e).FirstOrDefault();

                    empresa.Activo = 1;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void desEmpresa(int id)
        {
            EMPRESA empresa = new EMPRESA();

            try
            {
                using (var context = new SIGHUContext())
                {
                    empresa = (from e in context.EMPRESA
                               where e.IdEmpresa == id
                               select e).FirstOrDefault();

                    empresa.Activo = 0;

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
