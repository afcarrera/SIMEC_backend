using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace app.api.DTOs
{
    public partial class DetallefacturaDTO
    {
        [Display(Name = "Id")]
        public int Iddetalle { get; set; }
        [Display(Name = "Producto")]
        public int Idproducto { get; set; }
        [Display(Name = "Factura")]
        public int Idfactura { get; set; }
        [Display(Name = "Cantidad")]
        public double? Cantidad { get; set; }
        [Display(Name = "Subotal")]
        public double? Subtotal { get; set; }
    }
}
