using System;
using System.Collections.Generic;

#nullable disable

namespace app.api.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public int Idfactura { get; set; }
        public string Idcliente { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Total { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
