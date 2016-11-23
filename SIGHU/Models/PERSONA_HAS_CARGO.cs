namespace SIGHU.Models
{
    using System;
    using SIGHU.Models.Contratos;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class PERSONA_HAS_CARGO
    {
        [Key]
        public int IdPersonaHasCargo { get; set; }

        public int? IdPersona { get; set; }

        public int? IdCargo { get; set; }

        public int? IdArma { get; set; }

        public int? IdVestuario { get; set; }

        public int? IdVehiculo { get; set; }

        public int? IdEmpresa { get; set; }

        public int? AniosExpLab { get; set; }

        public int? actual { get; set; }

        public virtual ARMA ARMA { get; set; }

        public virtual CARGO CARGO { get; set; }

        public virtual EMPRESA EMPRESA { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual VEHICULO VEHICULO { get; set; }

        public virtual VESTUARIO VESTUARIO { get; set; }

        public List<viewListContratos> listarContratos()
        {
            List<viewListContratos> lstContratos = new List<viewListContratos>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstContratos = (from c in context.PERSONA_HAS_CARGO
                                    orderby c.IdPersona
                                    select new viewListContratos
                                    {
                                        NumDoc = c.PERSONA.NumeroDoc,
                                        Nombres = c.PERSONA.NombreP +" "+ c.PERSONA.ApellidoP,
                                        Cargo = c.CARGO.NombreC,
                                        Contrato = c.IdPersonaHasCargo,
                                        Actual = c.actual
                                    }).ToList();
                }
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }

            return lstContratos;
        }

        public ViewContratos traeContrato(int id)
        {
            ViewContratos contrato = new ViewContratos();

            try
            {
                using (var context = new SIGHUContext())
                {
                    var cont = (from c in context.PERSONA_HAS_CARGO
                                  where c.IdPersonaHasCargo == id
                                  select c).FirstOrDefault();

                    contrato.IdContrato = cont.IdPersonaHasCargo;
                    contrato.IdPersona = Convert.ToInt16(cont.IdPersona);
                    contrato.IdCargo = Convert.ToInt16(cont.IdCargo);
                    contrato.IdArma = cont.IdArma;
                    contrato.IdVestuario = Convert.ToInt16(cont.IdVestuario);
                    contrato.IdVehiculo = cont.IdVehiculo;
                    contrato.IdEmpresa = Convert.ToInt16(cont.IdEmpresa);
                    contrato.AniosExpLab = cont.AniosExpLab;
                    if (cont.actual == 1)
                    {
                        contrato.Actual = true;
                    }
                    else
                    {
                        contrato.Actual = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return contrato;
        }

        public void creaContrato()
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

        public void EditaContrato()
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
