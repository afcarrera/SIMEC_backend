using app.api.DTOs;
using app.api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<FacturaDTO, Factura>();
            CreateMap<Factura, FacturaDTO>();
            CreateMap<DetallefacturaDTO, Detallefactura>();
            CreateMap<Detallefactura, DetallefacturaDTO>();
            CreateMap<ProductoDTO, Producto>();
            CreateMap<Producto, ProductoDTO>();
        }
    }
}