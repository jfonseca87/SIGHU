namespace SIGHU.Models
{
    using SIGHU.Models.TipoAdjunto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TIPO_ADJUNTO
    {
        public TIPO_ADJUNTO()
        {
            ADJUNTOS = new List<ADJUNTOS>();
        }

        [Key]
        public int IdTAdjunto { get; set; }

        [Required]
        [StringLength(15)]
        public string CodTitulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int Activo { get; set; }

        public int? IdGrupo { get; set; }

        public virtual ICollection<ADJUNTOS> ADJUNTOS { get; set; }

        public virtual GRUPO_ADJUNTO GRUPO_ADJUNTO { get; set; }

        public List<ViewTableTipoAdjunto> listarTipoAdjuntos()
        {
            List<ViewTableTipoAdjunto> lstTAdjuntos = new List<ViewTableTipoAdjunto>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstTAdjuntos = (from a in context.TIPO_ADJUNTO
                                    select new ViewTableTipoAdjunto
                                    {
                                        IdTAdjunto = a.IdTAdjunto,
                                        CodTitulo = a.CodTitulo,
                                        Nombre = a.Nombre,
                                        Activo = a.Activo,
                                        Grupo = a.GRUPO_ADJUNTO.NombreGrupo
                                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstTAdjuntos;
        }

        public List<TIPO_ADJUNTO> ddTipoAdjunto(int id)
        {
            List<TIPO_ADJUNTO> lstTipoAdjunto = new List<TIPO_ADJUNTO>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstTipoAdjunto = (from t in context.TIPO_ADJUNTO
                                      where t.Activo == 1 && t.IdGrupo == id
                                      orderby t.Nombre 
                                      select t).ToList();
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return lstTipoAdjunto;
        }

        public void creaTipoAdjunto()
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

        public void editaTipoAdjunto()
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

        public ViewTipoAdjunto traeTipoAdjunto(int id)
        {
            ViewTipoAdjunto tipo = new ViewTipoAdjunto();

            try
            {
                using (var context = new SIGHUContext())
                {
                    tipo = (from t in context.TIPO_ADJUNTO
                            where t.IdTAdjunto == id
                            select new ViewTipoAdjunto
                            {
                                IdTipo = t.IdTAdjunto,
                                grupoAdjunto = t.IdGrupo,
                                CodTitulo = t.CodTitulo,
                                Nombre = t.Nombre
                            }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tipo;
        }

        public void actTipoAdjunto(int id)
        {
            TIPO_ADJUNTO tipo = new TIPO_ADJUNTO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    tipo = (from t in context.TIPO_ADJUNTO
                            where t.IdTAdjunto == id
                            select t).FirstOrDefault();

                    tipo.Activo = 1;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void desTipoAdjunto(int id)
        {
            TIPO_ADJUNTO tipo = new TIPO_ADJUNTO();

            try
            {
                using (var context = new SIGHUContext())
                {
                    tipo = (from t in context.TIPO_ADJUNTO
                            where t.IdTAdjunto == id
                            select t).FirstOrDefault();

                    tipo.Activo = 0;

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
