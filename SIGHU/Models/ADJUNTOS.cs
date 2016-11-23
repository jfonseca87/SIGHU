namespace SIGHU.Models
{
    using SIGHU.Models.Adjunto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class ADJUNTOS
    {
        [Key]
        public int IdAdjunto { get; set; }

        [Required(ErrorMessage="Debe seleccionar el tipo de adjunto")]
        public int IdTipoAdjunto { get; set; }

        [Required(ErrorMessage="Debe adjuntar un archivo en formato PDF")]
        public string RutaAdjunto { get; set; }

        public int? IdPersona { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual TIPO_ADJUNTO TIPO_ADJUNTO { get; set; }


        public List<ViewListAdjuntos> listarAdjuntos(int id)
        {
            List<ViewListAdjuntos> lstAdjuntos = new List<ViewListAdjuntos>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstAdjuntos = (from la in context.ADJUNTOS
                                   where la.IdPersona == id
                                   orderby la.TIPO_ADJUNTO.CodTitulo
                                   select new ViewListAdjuntos
                                   {
                                       idAdjunto = la.IdAdjunto,
                                       Codigo = la.TIPO_ADJUNTO.CodTitulo,
                                       Tipo = la.TIPO_ADJUNTO.Nombre,
                                       Nombre = la.RutaAdjunto
                                   }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstAdjuntos;
        }

        public void guardaAdjunto()
        {
            try
            {
                var context = new SIGHUContext();
                context.Entry(this).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ADJUNTOS traeNomArchivo(int id)
        {
            ADJUNTOS adjunto = new ADJUNTOS();

            try
            {
                using (var context = new SIGHUContext())
                {
                    adjunto = (from a in context.ADJUNTOS
                               where a.IdAdjunto == id
                               select a).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return adjunto;
        }

        public void delAdjunto(int id)
        {
            try
            {
                var context = new SIGHUContext();
                context.Database.ExecuteSqlCommand("DELETE FROM ADJUNTOS WHERE IdAdjunto = " + id);
                context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
