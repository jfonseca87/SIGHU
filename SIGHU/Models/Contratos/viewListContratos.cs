using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGHU.Models.Contratos
{
    public class viewListContratos
    {
        public string NumDoc { get; set; }
        public string Nombres { get; set; }
        public string Cargo { get; set; }
        public int Contrato { get; set; }
        public int? Actual { get; set; }
    }
}