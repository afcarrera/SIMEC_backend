using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace app.api.DTOs
{
    public class ClienteDTO
    {
        [Required(ErrorMessage ="El identificador es requerido")]
        [Display(Name ="Identificador")]
        public string Idcliente { get; set; }
        [Required(ErrorMessage = "El Nombre Completo es requerido")]
        [Display(Name = "Nombre Completo")]
        public string Nombrecompleto { get; set; }
        [Display(Name = "Estado")]
        public bool? Estado { get; set; }


    }
}
