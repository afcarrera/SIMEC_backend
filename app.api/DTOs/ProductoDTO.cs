using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace app.api.DTOs
{
    public partial class ProductoDTO
    {
        [Display(Name = "Id")]
        public int Idproducto { get; set; }
        [Display(Name = "Descripcion del producto")]
        public string Descripcion { get; set; }
    }
}
