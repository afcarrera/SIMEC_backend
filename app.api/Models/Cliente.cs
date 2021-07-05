using System;
using System.Collections.Generic;

#nullable disable

namespace app.api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public string Idcliente { get; set; }
        public string Nombrecompleto { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
