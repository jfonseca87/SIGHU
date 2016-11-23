namespace SIGHU.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class PERFILES
    {
        public PERFILES()
        {
            USUARIO = new List<USUARIO>();
        }

        [Key]
        public int IdPerfil { get; set; }

        [Required]
        [StringLength(50)]
        public string Perfil { get; set; }

        public int Activo { get; set; }

        public virtual ICollection<USUARIO> USUARIO { get; set; }

        public List<PERFILES> ddPerfiles()
        {
            List<PERFILES> lstPerfiles = new List<PERFILES>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstPerfiles = context.PERFILES.Where(p => p.Activo == 1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstPerfiles;
        }
    }
}
