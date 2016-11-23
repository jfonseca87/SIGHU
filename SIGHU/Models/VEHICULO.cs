namespace SIGHU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("VEHICULO")]
    public partial class VEHICULO
    {
        public VEHICULO()
        {
            PERSONA_HAS_CARGO = new List<PERSONA_HAS_CARGO>();
        }

        [Key]
        public int IdVehiculo { get; set; }

        [Required(ErrorMessage="Debe ingresar que tipo de transporte es el vehiculo")]
        [StringLength(100)]
        public string MedioTransporte { get; set; }

        [Required(ErrorMessage="Debe ingresar la placa del vehiculo")]
        [StringLength(10)]
        public string PlacaVehiculo { get; set; }

        [Required(ErrorMessage="Debe ingresar el modelo del vehiculo")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "El módelo debe ser númerico")]
        public int ModeloVehiculo { get; set; }

        [Required(ErrorMessage="Debe ingresar la marca del vehiculo")]
        [StringLength(50)]
        public string MarcaVehiculo { get; set; }

        public virtual ICollection<PERSONA_HAS_CARGO> PERSONA_HAS_CARGO { get; set; }

        public List<VEHICULO> listarVehiculos()
        {
            List<VEHICULO> lstVehiculos = new List<VEHICULO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstVehiculos = context.VEHICULO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstVehiculos;
        }

        public List<VEHICULO> ddVehiculos()
        {
            List<VEHICULO> lstVehiculos = new List<VEHICULO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstVehiculos = context.VEHICULO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstVehiculos;
        }

        public void ingresaVehiculo()
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

        public void editaVehiculo()
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

        public VEHICULO traeVehiculo(int id)
        {
            VEHICULO vehiculo = new VEHICULO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    vehiculo = context.VEHICULO.Where(v => v.IdVehiculo == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return vehiculo;
        }
    }
}
