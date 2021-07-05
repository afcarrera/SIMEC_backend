using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace app.api.DTOs
{
    public partial class FacturaDTO
    {
        [Display(Name = "Id")]
        public int Idfactura { get; set; }
        [Display(Name = "Cliente")]
        public string Idcliente { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? Fecha { get; set; }
        [Display(Name = "Total")]
        public double? Total { get; set; }
    }
}
