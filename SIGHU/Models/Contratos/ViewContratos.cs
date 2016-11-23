using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SIGHU.Models.Contratos
{
    public class ViewContratos
    {
        public int? IdContrato { get; set; }

        [Required(ErrorMessage="Debe seleccionar una persona")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el cargo")]
        public int IdCargo { get; set; }

        public int? IdArma { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un vestuario")]
        public int IdVestuario { get; set; }

        public int? IdVehiculo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una empresa")]
        public int IdEmpresa { get; set; }

        public int? AniosExpLab { get; set; }

        public bool Actual { get; set; }
    }
}