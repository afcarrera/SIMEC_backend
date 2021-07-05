using System;
using System.Collections.Generic;

#nullable disable

namespace app.api.Models
{
    public partial class Detallefactura
    {
        public int Iddetalle { get; set; }
        public int Idproducto { get; set; }
        public int Idfactura { get; set; }
        public double? Cantidad { get; set; }
        public double? Subtotal { get; set; }

        public virtual Factura IdfacturaNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
    }
}
