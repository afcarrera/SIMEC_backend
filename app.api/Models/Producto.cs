using System;
using System.Collections.Generic;

#nullable disable

namespace app.api.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public int Idproducto { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
