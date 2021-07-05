using app.api.DbContexts;
using app.api.DTOs;
using app.api.Models;
using app.api.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IMapper _mapper;
        private readonly DetalleFacturaRepository _detalleFacturaRepository;
        private readonly SIMECContext _dbContext;

        public DetalleFacturaService(IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = new SIMECContext();
            _detalleFacturaRepository = new DetalleFacturaRepository(_dbContext);
        }
        public String DeleteDetallefactura(int DetallefacturaID)
        {
            return _detalleFacturaRepository.DeleteDetallefactura(DetallefacturaID);
        }

        public DetallefacturaDTO GetDetallefacturaByID(int DetallefacturaID)
        {
            return _mapper.Map<DetallefacturaDTO>(_detalleFacturaRepository.GetDetallefacturaByID(DetallefacturaID));
        }

        public IEnumerable<DetallefacturaDTO> GetDetallefacturas()
        {
            return _mapper.Map<IEnumerable<DetallefacturaDTO>>(_detalleFacturaRepository.GetDetallefacturas());
        }

        public String InsertDetallefactura(DetallefacturaDTO detallefactura)
        {
            return _detalleFacturaRepository.InsertDetallefactura(_mapper.Map<Detallefactura>(detallefactura));
        }

        public String UpdateDetallefactura(int id, DetallefacturaDTO detallefactura)
        {
            return _detalleFacturaRepository.UpdateDetallefactura(id,_mapper.Map<Detallefactura>(detallefactura));
        }
    }
}
