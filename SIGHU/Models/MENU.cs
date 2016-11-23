using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace SIGHU.Models
{
    [Table("MENU")]
    public partial class MENU
    {
        [Key]
        public int idMenu { get; set; }
        public string NMEnu { get; set; }
        public string url { get; set; }
        public int Activo { get; set; }
        public int Perfil { get; set; }

        public List<MENU> listarMenu(int id)
        {
            List<MENU> lstMenu = new List<MENU>();

            try
            {
                using (var context = new SIGHUContext())
                {
                    lstMenu = (from m in context.MENU
                               where m.Activo == 1 && m.Perfil == id
                               select m).ToList();
                }

                return lstMenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}